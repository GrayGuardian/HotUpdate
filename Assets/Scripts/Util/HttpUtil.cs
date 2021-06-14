using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

public class HttpResult
{
    public int code;
    public byte[] bytes;
    public string content;
    public HttpWebResponse response;
}
public class HttpUtil
{
    /// <summary>
    /// 主线程
    /// </summary>
    private SynchronizationContext _mainThreadSynContext;

    public HttpUtil()
    {
        _mainThreadSynContext = SynchronizationContext.Current;
    }

    /// <summary>
    /// GET方法
    /// </summary>
    public HttpResult Get(HttpWebRequest request, Action<Exception> error = null, Encoding encode = null)
    {
        HttpWebResponse response = null;
        encode = encode ?? Encoding.UTF8;
        try
        {
            response = (HttpWebResponse)request.GetResponse();
            int code = (int)response.StatusCode;

            Stream stream = response.GetResponseStream();
            List<byte> byteArray = new List<byte>();
            while (true)
            {
                int b = stream.ReadByte();
                if (b == -1) break;
                byteArray.Add((byte)b);
            }
            stream.Close();
            response.Close();
            request.Abort();
            byte[] bytes = byteArray.ToArray();
            string content = encode.GetString(bytes);
            if (bytes.Length > 0)
            {
                return new HttpResult() { code = code, bytes = bytes, content = content, response = response };
            }
        }
        catch (Exception ex)
        {
            if (error != null) error(ex);
        }
        return new HttpResult() { code = -1, bytes = new byte[] { }, content = "", response = null };
    }

    public void Get_Asyn(HttpWebRequest request, Action<HttpResult> cb = null, Action<Exception> error = null, Encoding encode = null)
    {
        Thread thread = null;
        thread = new Thread(new ThreadStart(() =>
        {
            HttpResult result = Get(request, (ex) =>
            {
                _mainThreadSynContext.Post(new SendOrPostCallback((obj) =>
                {
                    if (error != null) error(ex);
                }), null);
            }, encode);
            if (result.bytes.Length > 0)
            {
                _mainThreadSynContext.Post(new SendOrPostCallback((obj) =>
                {
                    if (cb != null) cb(result);
                }), null);
            }
        }));
        thread.Start();
    }


    /// <summary>
    /// Post方法
    /// </summary>s 
    public HttpResult Post(HttpWebRequest request, byte[] body, Action<Exception> error = null, Encoding encode = null)
    {
        HttpWebResponse response;
        encode = encode ?? Encoding.UTF8;
        try
        {
            Stream stream = request.GetRequestStream();
            stream.Write(body, 0, body.Length);
            stream.Close();

            response = (HttpWebResponse)request.GetResponse();
            int code = (int)response.StatusCode;

            stream = response.GetResponseStream();
            List<byte> byteArray = new List<byte>();
            while (true)
            {
                int b = stream.ReadByte();
                if (b == -1) break;
                byteArray.Add((byte)b);
            }
            stream.Close();
            response.Close();
            request.Abort();
            byte[] bytes = byteArray.ToArray();
            string content = encode.GetString(bytes);
            if (bytes.Length > 0)
            {
                return new HttpResult() { code = code, bytes = bytes, content = content, response = response };
            }
        }
        catch (Exception ex)
        {
            if (error != null) error(ex);
        }
        return new HttpResult() { code = -1, bytes = new byte[] { }, content = "", response = null };
    }

    public void Post_Asyn(HttpWebRequest request, byte[] body, Action<HttpResult> cb = null, Action<Exception> error = null, Encoding encode = null)
    {
        Thread thread = null;
        thread = new Thread(new ThreadStart(() =>
        {
            HttpResult result = Post(request, body, (ex) =>
            {
                _mainThreadSynContext.Post(new SendOrPostCallback((obj) =>
                {
                    if (error != null) error(ex);
                }), null);
            }, encode);
            if (result.bytes.Length > 0)
            {
                _mainThreadSynContext.Post(new SendOrPostCallback((obj) =>
                {
                    if (cb != null) cb(result);
                }), null);
            }
        }));
        thread.Start();
    }

    public void Download(HttpWebRequest request, Action<HttpWebResponse, byte[]> cb, Action<HttpWebResponse, byte[], byte[]> downloading = null, Action<Exception> error = null, int rlen = 8 * 1024)
    {
        ThreadStart threadStart = new ThreadStart(() =>
        {
            _download(request, cb, downloading, error, rlen);
        });

        Thread thread = new Thread(threadStart);
        thread.Start();
    }
    void _download(HttpWebRequest request, Action<HttpWebResponse, byte[]> cb, Action<HttpWebResponse, byte[], byte[]> downloading = null, Action<Exception> error = null, int rlen = 8 * 1024)
    {

        List<byte> data = new List<byte>();

        HttpWebResponse response;
        try
        {
            response = (HttpWebResponse)request.GetResponse();

            // 向服务器请求，获得服务器回应数据流 
            System.IO.Stream stream = response.GetResponseStream();
            // 获得文件长度
            long contentLength = stream.Length;

            // 从流中读取到的单次数据
            byte[] nbytes = new byte[rlen];
            int nReadSize = 0;
            do
            {
                // 读取下一段数据
                nReadSize = stream.Read(nbytes, 0, rlen);
                // 读取不到则跳出
                if (nReadSize <= 0) break;

                // 获取单次读取到的数据
                byte[] rbytes = nbytes.Skip(0).Take(nbytes.Length).ToArray();
                // 若缓存内读取的文件大小超过上限，则不读取超过限制的部分
                if (data.Count + rbytes.Length > contentLength)
                {
                    rbytes = nbytes.Skip(0).Take((int)(contentLength - (long)data.Count)).ToArray();
                }
                // 将读取到数据加入缓存
                data.AddRange(rbytes);

                // 与主线程通信，回调loding函数
                _mainThreadSynContext.Post(new SendOrPostCallback((obj) =>
                {
                    var response = (HttpWebResponse)obj.GetType().GetProperty("response").GetValue(obj);
                    var data = (byte[])obj.GetType().GetProperty("data").GetValue(obj);
                    var rbytes = (byte[])obj.GetType().GetProperty("rbytes").GetValue(obj);
                    if (downloading != null) downloading(response, data, rbytes);
                }), new { response = response, data = data.ToArray(), rbytes = rbytes });

            } while (true);

            stream.Close();
            response.Close();
            request.Abort();

            // 与主线程通信，回调完成loding函数
            _mainThreadSynContext.Post(new SendOrPostCallback((obj) =>
            {
                cb(response, data.ToArray());
            }), null);
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.Log("捕获下载异常>>>" + ex.Message);
            if (error != null) error(ex);
        }


    }
}