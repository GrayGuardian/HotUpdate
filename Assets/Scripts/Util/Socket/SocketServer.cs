using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

public class SocketInfo
{
    public Socket Client;
    public Thread ReceiveThread;
    public long HeadTime;
}

/// <summary>
/// Socket服务端
/// </summary>
public class SocketServer
{

    public string IP;
    public int Port;

    private const int HEAD_TIMEOUT = 5000;    // 心跳超时 毫秒
    private const int HEAD_CHECKTIME = 5000;   // 心跳包超时检测 毫秒

    public Dictionary<Socket, SocketInfo> ClientInfoDic = new Dictionary<Socket, SocketInfo>();

    private Socket _server;
    private Thread _connectThread;
    private System.Timers.Timer _headCheckTimer;
    private DataBuffer _dataBuffer = new DataBuffer();

    public event Action<Socket> OnConnect;  //客户端建立连接回调
    public event Action<Socket> OnDisconnect;  // 客户端断开连接回调
    public event Action<Socket, SocketDataPack> OnReceive;  // 接收报文回调
    public event Action<SocketException> OnError;   // 异常捕获回调

    private bool _isValid = true;

    public SocketServer(string ip, int port)
    {
        IP = ip;
        Port = port;

        _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress ipAddress = IPAddress.Parse(IP);//解析IP地址
        _server.Bind(new IPEndPoint(ipAddress, Port));  //绑定IP地址：端口  

        _server.Listen(10);    //设定最多10个排队连接请求

        // 启动线程监听连接
        _connectThread = new Thread(ListenClientConnect);
        _connectThread.Start();

        // 心跳包定时检测
        _headCheckTimer = new System.Timers.Timer(HEAD_CHECKTIME);
        _headCheckTimer.AutoReset = true;
        _headCheckTimer.Elapsed += delegate (object sender, ElapsedEventArgs args)
        {
            CheckHeadTimeOut();
        };
        _headCheckTimer.Start();
    }
    /// <summary>  
    /// 监听客户端连接  
    /// </summary>  
    private void ListenClientConnect()
    {
        while (true)
        {
            try
            {
                if (!_isValid) break;
                Socket client = _server.Accept();
                Thread receiveThread = new Thread(ReceiveEvent);
                ClientInfoDic.Add(client, new SocketInfo() { Client = client, ReceiveThread = receiveThread, HeadTime = GetNowTime() });
                receiveThread.Start(client);

                GameConst.PostMainThreadAction<Socket>(OnConnect, client);
            }
            catch
            {
                break;
            }

        }

    }
    /// <summary>
    /// 获取当前时间戳
    /// </summary>
    /// <returns></returns>
    private long GetNowTime()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalMilliseconds);
    }

    public void Send(Socket client, UInt16 e, byte[] buff = null, Action<SocketDataPack> onTrigger = null)
    {
        buff = buff ?? new byte[] { };
        var dataPack = new SocketDataPack(e, buff);
        var data = dataPack.Buff;
        try
        {
            client.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback((asyncSend) =>
            {
                Socket c = (Socket)asyncSend.AsyncState;
                c.EndSend(asyncSend);
                if (onTrigger != null) onTrigger(dataPack);
            }), client);
        }
        catch (SocketException ex)
        {
            onError(ex);
        }

    }
    /// <summary>
    /// 线程内接收数据的函数
    /// </summary>
    private void ReceiveEvent(object client)
    {
        Socket tsocket = (Socket)client;
        while (true)
        {
            if (!_isValid) break;
            if (!ClientInfoDic.ContainsKey(tsocket))
            {
                break;
            }
            try
            {
                if (tsocket.Available <= 0) continue;
                byte[] rbytes = new byte[8 * 1024];
                int len = tsocket.Receive(rbytes);
                if (len > 0)
                {
                    _dataBuffer.AddBuffer(rbytes, len); // 将收到的数据添加到缓存器中
                    var dataPack = new SocketDataPack();
                    if (_dataBuffer.TryUnpack(out dataPack)) // 尝试解包
                    {

                        if (dataPack.Type == (UInt16)SocketEvent.sc_head)
                        {
                            // 接收到心跳包
                            ReceiveHead(tsocket);
                        }
                        else if (dataPack.Type == (UInt16)SocketEvent.sc_disconn)
                        {
                            // 客户端断开连接
                            CloseClient(tsocket);
                        }
                        else
                        {
                            // 收到消息
                            GameConst.PostMainThreadAction<Socket, SocketDataPack>(OnReceive, tsocket, dataPack);
                        }

                    }
                }
            }
            catch (SocketException ex)
            {
                onError(ex);
            }
        }
    }
    /// <summary>
    /// 接收到心跳包
    /// </summary>
    private void ReceiveHead(Socket client)
    {
        SocketInfo info;
        if (ClientInfoDic.TryGetValue(client, out info))
        {
            long now = GetNowTime();
            long offset = now - info.HeadTime;
            UnityEngine.Debug.Log("更新心跳时间戳 >>>" + now + "  间隔>>>" + offset);
            if (offset > HEAD_TIMEOUT)
            {
                // 心跳包收到但超时逻辑
            }
            info.HeadTime = now;
        }
    }
    /// <summary>
    /// 检测心跳包超时
    /// </summary>
    private void CheckHeadTimeOut()
    {
        var tempList = new List<Socket>();
        foreach (var socket in ClientInfoDic.Keys)
        {
            tempList.Add(socket);
        }
        foreach (var socket in tempList)
        {
            var info = ClientInfoDic[socket];
            long now = GetNowTime();
            long offset = now - info.HeadTime;
            if (offset > HEAD_TIMEOUT)
            {
                // 心跳包超时
                KickOut(socket);
            }
        }
    }
    public void KickOut(Socket client)
    {
        // 踢出连接
        Send(client, (UInt16)SocketEvent.sc_kickout, null, (dataPack) =>
        {
            CloseClient(client);
        });
    }
    public void KickOutAll()
    {
        var tempList = new List<Socket>();
        foreach (var socket in ClientInfoDic.Keys)
        {
            tempList.Add(socket);
        }
        foreach (var socket in tempList)
        {
            KickOut(socket);
        }
    }
    /// <summary>
    /// 清理客户端连接
    /// </summary>
    /// <param name="client"></param>
    private void CloseClient(Socket client)
    {
        GameConst.PostMainThreadAction<Socket>((socket) =>
        {
            if (OnDisconnect != null) OnDisconnect(socket);
            ClientInfoDic.Remove(socket);
            client.Close();
        }, client);

    }
    /// <summary>
    /// 关闭
    /// </summary>
    public void Close()
    {
        if (!_isValid) return;
        _isValid = false;
        // if (_connectThread != null) _connectThread.Abort();
        var tempList = new List<Socket>();
        foreach (var socket in ClientInfoDic.Keys)
        {
            tempList.Add(socket);
        }
        foreach (var socket in tempList)
        {
            CloseClient(socket);
        }
        if (_headCheckTimer != null)
        {
            _headCheckTimer.Stop();
            _headCheckTimer = null;
        }
        _server.Close();
    }

    /// <summary>
    /// 错误回调
    /// </summary>
    /// <param name="e"></param>
    private void onError(SocketException ex)
    {
        GameConst.PostMainThreadAction<SocketException>(OnError, ex);
    }



}
