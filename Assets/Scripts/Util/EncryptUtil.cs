using System.Text;
using System.IO;
using System.Security.Cryptography;
using System;
using System.Threading;

public class EncryptUtil : Singleton<EncryptUtil>
{
    const string DEFAULT_KEY = "21232f297a57a5a743894a0e4a801fc3";
    /// <summary>
    /// 读取文件 字节流
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <returns></returns>
    public byte[] ReadBytes(string path)
    {
        byte[] data = FileUtil.Instance.ReadBytes(path);
        return AesDecrypt(data);
    }
    public void ReadBytesAsync(string path, Action<byte[]> cb)
    {
        byte[] data = FileUtil.Instance.ReadBytes(path);
        AesDecryptAsync(data, cb);
    }
    /// <summary>
    /// 读取文件 字符串
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <param name="encoding">编码</param>
    /// <returns></returns>
    public string ReadString(string path)
    {
        string str = FileUtil.Instance.ReadString(path);
        return AesDecrypt(str);
    }
    public void ReadStringAsync(string path, Action<string> cb)
    {
        string str = FileUtil.Instance.ReadString(path);
        AesDecryptAsync(str, cb);
    }
    /// <summary>
    /// 写到文件 字节流
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <param name="data">数据</param>
    /// <returns></returns>
    public void WriteBytes(string path, byte[] data)
    {
        data = AesEncrypt(data);
        File.WriteAllBytes(path, data);
    }
    public void WriteBytesAsync(string path, byte[] data, Action cb = null)
    {
        AesEncryptAsync(data, (d) =>
        {
            File.WriteAllBytes(path, d);
            if (cb != null) cb();
        });
    }
    /// <summary>
    /// 写到文件 字符串
    /// </summary>
    /// <param name="key">密钥</param>
    /// <param name="path">文件路径</param>
    /// <param name="data">数据</param>
    /// <param name="encoding">编码</param>
    /// <returns></returns>
    public void WriteString(string path, string data)
    {
        data = AesEncrypt(data, null);
        File.WriteAllText(path, data);
    }
    public void WriteStringAsync(string path, string data, Action cb = null)
    {
        AesEncryptAsync(data, (d) =>
       {
           File.WriteAllText(path, d);
           if (cb != null) cb();
       });
    }
    /// <summary>
    ///  AES 加密
    /// </summary>
    /// <param name="data">明文（待加密）</param>
    /// <param name="key">密钥 32位</param>
    /// <returns></returns>
    public byte[] AesEncrypt(byte[] data, string key = null)
    {
        try
        {
            if (data.Length == 0) return data;
            key = key == null ? DEFAULT_KEY : key;
            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            return cTransform.TransformFinalBlock(data, 0, data.Length);
        }
        catch
        {
            return new byte[] { };
        }
    }
    /// <summary>
    ///  AES 解密
    /// </summary>
    /// <param name="data">密文（待解密）</param>
    /// <param name="key">密钥 32位</param>
    /// <returns></returns>
    public byte[] AesDecrypt(byte[] data, string key = null)
    {
        try
        {
            if (data.Length == 0) return data;
            key = key == null ? DEFAULT_KEY : key;
            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateDecryptor();
            return cTransform.TransformFinalBlock(data, 0, data.Length);
        }
        catch
        {
            return new byte[] { };
        }
    }
    /// <summary>
    ///  AES 加密
    /// </summary>
    /// <param name="str">明文（待加密）</param>
    /// <param name="key">密钥</param>
    /// <returns></returns>
    public string AesEncrypt(string str, string key = null)
    {
        try
        {
            if (str == "") return str;
            key = key == null ? DEFAULT_KEY : key;
            byte[] data;
            data = Encoding.UTF8.GetBytes(str);
            data = AesEncrypt(data, key);
            return Convert.ToBase64String(data, 0, data.Length);
        }
        catch
        {
            return "";
        }
    }
    /// <summary>
    ///  AES 解密
    /// </summary>
    /// <param name="data">明文（待解密）</param>
    /// <param name="key">密钥</param>
    /// <returns></returns>
    public string AesDecrypt(string str, string key = null)
    {
        try
        {
            if (str == "") return str;
            key = key == null ? DEFAULT_KEY : key;
            byte[] data;
            data = Convert.FromBase64String(str);
            data = AesDecrypt(data, key);
            return Encoding.UTF8.GetString(data);
        }
        catch
        {
            return "";
        }
    }


    public void AesEncryptAsync(byte[] data, Action<byte[]> cb, string key = null)
    {
        Thread thread = null;
        thread = new Thread(new ThreadStart(() =>
        {
            var bytes = AesEncrypt(data, key);
            GameConst.PostMainThreadAction<byte[]>(cb, bytes);
        }));
        thread.Start();
    }
    public void AesDecryptAsync(byte[] data, Action<byte[]> cb, string key = null)
    {
        Thread thread = null;
        thread = new Thread(new ThreadStart(() =>
        {
            var bytes = AesDecrypt(data, key);
            GameConst.PostMainThreadAction<byte[]>(cb, bytes);
        }));
        thread.Start();
    }
    public void AesEncryptAsync(string data, Action<string> cb, string key = null)
    {
        Thread thread = null;
        thread = new Thread(new ThreadStart(() =>
        {
            var str = AesEncrypt(data, key);
            GameConst.PostMainThreadAction<string>(cb, str);
        }));
        thread.Start();
    }
    public void AesDecryptAsync(string data, Action<string> cb, string key = null)
    {
        Thread thread = null;
        thread = new Thread(new ThreadStart(() =>
        {
            var str = AesDecrypt(data, key);
            GameConst.PostMainThreadAction<string>(cb, str);
        }));
        thread.Start();
    }
}