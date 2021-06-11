using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

public class HttpResult
{
    public int code;
    public byte[] bytes;
    public string content;
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
    private void MainCallBack(object param)
    {
        var tag = (string)param.GetType().GetProperty("tag").GetValue(param);
        switch (tag)
        {
            case "Get":
                var get = (Action)param.GetType().GetProperty("cb").GetValue(param);
                if (get != null) get();
                break;
            case "GetError":
                var getError = (Action)param.GetType().GetProperty("cb").GetValue(param);
                if (getError != null) getError();
                break;
            case "Post":
                var post = (Action)param.GetType().GetProperty("cb").GetValue(param);
                if (post != null) post();
                break;
            case "PostError":
                var postError = (Action)param.GetType().GetProperty("cb").GetValue(param);
                if (postError != null) postError();
                break;
        }

    }
    /// <summary>
    /// GET方法
    /// </summary>
    public HttpResult Get(string url, Action<Exception> error = null)
    {
        HttpWebResponse res = null;
        HttpWebRequest req = null;
        try
        {
            req = (HttpWebRequest)WebRequest.Create(url);
            req.AllowAutoRedirect = false;
            req.Timeout = 1000;
            res = (HttpWebResponse)req.GetResponse();
            int code = (int)res.StatusCode;

            Stream sr = res.GetResponseStream();
            List<byte> byteArray = new List<byte>();
            while (true)
            {
                int b = sr.ReadByte();
                if (b == -1) break;
                byteArray.Add((byte)b);
            }
            sr.Close();
            res.Close();
            req.Abort();
            byte[] bytes = byteArray.ToArray();
            string content = Encoding.UTF8.GetString(bytes);
            if (bytes.Length > 0)
            {
                return new HttpResult() { code = code, bytes = bytes, content = content };
            }
        }
        catch (Exception ex)
        {
            if (error != null) error(ex);
        }
        return new HttpResult() { code = -1, bytes = new byte[] { }, content = "" };
    }

    public void Get_Asyn(string url, Action<HttpResult> cb = null, Action<Exception> error = null)
    {
        Thread thread = null;
        thread = new Thread(new ThreadStart(() =>
        {
            HttpResult result = Get(url, (ex) =>
            {
                Action t_error = () => { if (error != null) error(ex); };
                _mainThreadSynContext.Post(new SendOrPostCallback(MainCallBack), new { tag = "GetError", cb = t_error });
            });
            Action t_cb = () => { if (cb != null) cb(result); };
            if (result.bytes.Length > 0)
            {
                _mainThreadSynContext.Post(new SendOrPostCallback(MainCallBack), new { tag = "Get", cb = t_cb });
            }
        }));
        thread.Start();
    }


    /// <summary>
    /// Post方法
    /// </summary>s 
    public HttpResult Post(string url, byte[] body, HttpWebRequest req, Action<Exception> error = null)
    {
        HttpWebResponse res;
        Encoding encode = Encoding.Default;
        try
        {
            Stream newStream = req.GetRequestStream();
            newStream.Write(body, 0, body.Length);    //写入参数
            newStream.Close();
            res = (HttpWebResponse)req.GetResponse();
            int code = (int)res.StatusCode;

            Stream sr = res.GetResponseStream();
            List<byte> byteArray = new List<byte>();
            while (true)
            {
                int b = sr.ReadByte();
                if (b == -1) break;
                byteArray.Add((byte)b);
            }
            sr.Close();
            res.Close();
            req.Abort();
            byte[] bytes = byteArray.ToArray();
            string content = Encoding.UTF8.GetString(bytes);
            if (bytes.Length > 0)
            {
                return new HttpResult() { code = code, bytes = bytes, content = content };
            }
        }
        catch (Exception ex)
        {
            if (error != null) error(ex);
        }
        return new HttpResult() { code = -1, bytes = new byte[] { }, content = "" };
    }

    public void Post_Asyn(string url, byte[] body, HttpWebRequest req, Action<HttpResult> cb = null, Action<Exception> error = null)
    {
        Thread thread = null;
        thread = new Thread(new ThreadStart(() =>
        {
            HttpResult result = Post(url, body, req, (ex) =>
            {
                Action t_error = () => { if (error != null) error(ex); };
                _mainThreadSynContext.Post(new SendOrPostCallback(MainCallBack), new { tag = "PostError", cb = t_error });
            });
            Action t_cb = () => { if (cb != null) cb(result); };
            if (result.bytes.Length > 0)
            {
                _mainThreadSynContext.Post(new SendOrPostCallback(MainCallBack), new { tag = "Post", cb = t_cb });
            }
        }));
        thread.Start();
    }
}