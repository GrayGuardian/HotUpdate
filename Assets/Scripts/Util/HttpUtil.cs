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
public class HttpUtil : Singleton<HttpUtil>
{
    /// <summary>
    /// 主线程
    /// </summary>
    private SynchronizationContext _mainThreadSynContext;

    public HttpUtil()
    {
        System.Net.ServicePointManager.DefaultConnectionLimit = 512;
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
            // throw;
        }
        return new HttpResult() { code = -1, bytes = new byte[] { }, content = "", response = null };
    }

    public void GetAsyn(HttpWebRequest request, Action<HttpResult> cb = null, Action<Exception> error = null, Encoding encode = null)
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
            request.Method = "POST";
            request.ContentLength = body.Length;
            request.ContentType = request.ContentType ?? "text/plain";
            request.Accept = request.Accept ?? "*/*";
            request.UserAgent = request.UserAgent ?? "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; InfoPath.1)";

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
            // throw;
        }
        return new HttpResult() { code = -1, bytes = new byte[] { }, content = "", response = null };
    }

    public void PostAsyn(HttpWebRequest request, byte[] body, Action<HttpResult> cb = null, Action<Exception> error = null, Encoding encode = null)
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
}