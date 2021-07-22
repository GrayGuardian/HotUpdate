using System;
using System.IO;
/// <summary>
/// Socket通信过程中的数据包 处理具体拆包装包逻辑
/// </summary>
public class SocketDataPack
{
    // 消息：数据总长度(4byte) + 数据类型(2byte) + 数据(N byte)
    public static int HEAD_DATA_LEN = 4;
    public static int HEAD_TYPE_LEN = 2;
    public static int HEAD_LEN
    {
        get { return HEAD_DATA_LEN + HEAD_TYPE_LEN; }
    }

    /// <summary>
    /// 数据包类型
    /// </summary>
    public UInt16 Type;
    /// <summary>
    /// 数据包数据
    /// </summary>
    public byte[] Data;
    public byte[] Buff;

    public int BuffLength
    {
        get { return Buff.Length; }
    }
    public int DataLength
    {
        get { return Data.Length; }
    }

    public SocketDataPack()
    {

    }
    public SocketDataPack(UInt16 type, byte[] data)
    {
        Type = type;
        Data = data;

        Buff = GetBuff(Type, Data);
    }

    public static byte[] GetBuff(UInt16 type, byte[] data)
    {
        byte[] buff = new byte[data.Length + HEAD_LEN];
        byte[] temp;
        temp = BitConverter.GetBytes(buff.Length);
        Array.Copy(temp, 0, buff, 0, HEAD_DATA_LEN);
        temp = BitConverter.GetBytes(type);
        Array.Copy(temp, 0, buff, HEAD_DATA_LEN, HEAD_TYPE_LEN);

        Array.Copy(data, 0, buff, HEAD_LEN, data.Length);

        return buff;
    }

    public static SocketDataPack Unpack(byte[] buff)
    {
        try
        {
            if (buff.Length < HEAD_LEN)
            {
                // 头部没取完则返回
                return null;
            }
            byte[] temp;
            // 取数据长度
            temp = new byte[HEAD_DATA_LEN];
            Array.Copy(buff, 0, temp, 0, HEAD_DATA_LEN);
            int buffLength = BitConverter.ToInt32(temp, 0);
            if (buffLength <= 0) return null;
            if (buffLength > buff.Length)
            {
                // 数据没取完
                return null;
            }
            int dataLength = buffLength - HEAD_LEN;
            // 取数据类型
            temp = new byte[HEAD_TYPE_LEN];
            Array.Copy(buff, HEAD_DATA_LEN, temp, 0, HEAD_TYPE_LEN);
            UInt16 dataType = BitConverter.ToUInt16(temp, 0);
            // 取数据
            byte[] data = new byte[dataLength];
            Array.Copy(buff, HEAD_LEN, data, 0, dataLength);

            var dataPack = new SocketDataPack(dataType, data);
            // UnityEngine.Debug.LogFormat("buffLen:{0} type:{1} dataLength:{2}", buffLength, dataType, data.Length);

            return dataPack;

        }
        catch
        {
            // 存在不完整数据解包 则返回null
            return null;
        }


    }
}