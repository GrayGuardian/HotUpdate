using System;
/// <summary>
/// Socket传输过程的缓冲区，尝试拆包获得数据
/// </summary>
public class DataBuffer
{
    // 缓存区长度
    private const int MIN_BUFF_LEN = 1024;

    private byte[] _buff;
    private int _buffLength = 0;

    public DataBuffer(int minBuffLen = MIN_BUFF_LEN)
    {
        if (minBuffLen <= 0)
        {
            minBuffLen = MIN_BUFF_LEN;
        }
        _buff = new byte[minBuffLen];
    }

    /// <summary>
    /// 添加缓存数据
    /// </summary>
    public void AddBuffer(byte[] data, int len)
    {
        byte[] buff = new byte[len];
        Array.Copy(data, buff, len);
        if (len > _buff.Length - _buffLength)  //超过当前缓存
        {
            byte[] temp = new byte[_buffLength + len];
            Array.Copy(_buff, 0, temp, 0, _buffLength);
            Array.Copy(buff, 0, temp, _buffLength, len);
            _buff = temp;
        }
        else
        {
            Array.Copy(data, 0, _buff, _buffLength, len);
        }
        _buffLength += len;//修改当前数据标记
    }

    public bool TryUnpack(out SocketDataPack dataPack)
    {
        dataPack = SocketDataPack.Unpack(_buff);
        if (dataPack == null)
        {
            return false;
        }
        // 清理旧缓存
        _buffLength -= dataPack.BuffLength;
        byte[] temp = new byte[_buffLength < MIN_BUFF_LEN ? MIN_BUFF_LEN : _buffLength];
        Array.Copy(_buff, dataPack.BuffLength, temp, 0, _buffLength);
        _buff = temp;
        return true;
    }
}