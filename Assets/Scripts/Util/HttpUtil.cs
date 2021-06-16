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
            throw;
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
            throw;
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
    public long GetDownloadSize(string url, Action<Exception> error = null, int timeOut = 2000)
    {
        HttpWebRequest request;
        HttpWebResponse response;
        try
        {
            request = (HttpWebRequest)HttpWebRequest.CreateHttp(new Uri(url));
            request.Method = "HEAD";
            request.Timeout = timeOut;
            response = (HttpWebResponse)request.GetResponse();
            // 获得文件长度
            long contentLength = response.ContentLength;

            response.Close();
            request.Abort();

            return contentLength;
        }
        catch (Exception ex)
        {
            if (error != null) error(ex);
            throw;
        }
    }
    public void GetDownloadSizeAsyn(string url, Action<long> cb, Action<Exception> error = null, int timeOut = 2000)
    {
        ThreadStart threadStart = new ThreadStart(() =>
        {
            _mainThreadSynContext.Post(new SendOrPostCallback((obj) =>
            {
                cb(GetDownloadSize(url, error, timeOut));
            }), null);
        });

        Thread thread = new Thread(threadStart);
        thread.Start();
    }



    /// <summary>
    /// 线程下载 支持断点续传
    /// </summary>
    /// <param name="url">url</param>
    /// <param name="savePath">保存路径</param>
    /// <param name="cb">下载完成回调</param>
    /// <param name="downloading">下载过程回调</param>
    /// <param name="error">错误回调</param>
    /// <param name="minRange">文件读取范围最小值</param>
    /// <param name="maxRange">文件读取范围最大值</param>
    /// <param name="timeOut">超时</param>
    /// <param name="rlen">单次读取长度</param>
    public void Download(string url, string savePath, Action<long> cb = null, Action<long, long> downloading = null, Action<Exception> error = null, long minRange = 0, long maxRange = -1, int timeOut = 2000, int rlen = 8 * 1024)
    {
        Thread thread = null;
        ThreadStart threadStart = new ThreadStart(() =>
        {
            Action<long> t_cb = (size) =>
            {
                _mainThreadSynContext.Post(new SendOrPostCallback((obj) =>
                {
                    if (cb != null) cb(size);
                }), null);
            };
            Action<long, long> t_downloading = (size, count) =>
            {
                _mainThreadSynContext.Post(new SendOrPostCallback((obj) =>
                {
                    if (downloading != null) downloading(size, count);
                }), null);
            };
            Action<Exception> t_error = (ex) =>
            {
                _mainThreadSynContext.Post(new SendOrPostCallback((obj) =>
                {
                    if (error != null) error(ex);
                }), null);
            };

            _threadDownload(url, savePath, t_cb, t_downloading, t_error, minRange, maxRange, timeOut, rlen);
            thread.Abort();
        });

        thread = new Thread(threadStart);
        thread.Start();
    }

    public void _threadDownload(string url, string savePath, Action<long> cb = null, Action<long, long> downloading = null, Action<Exception> error = null, long minRange = 0, long maxRange = -1, int timeOut = 2000, int rlen = 8 * 1024)
    {
        // 格式化文件路径
        savePath = new FileInfo(savePath).FullName;
        // 记录文件名及路径
        string fileName = Path.GetFileName(savePath);
        string dirPath = Path.GetDirectoryName(savePath);
        if (!Directory.Exists(dirPath))
        {
            // 目录不存在则创建
            Directory.CreateDirectory(dirPath);
        }
        // 断点续传起始尺寸
        long startSize = 0;
        // 文件流
        FileStream fs;
        if (File.Exists(savePath))
        {
            // 存在则断点续传
            fs = System.IO.File.OpenWrite(savePath);
            fs.Seek(fs.Length, System.IO.SeekOrigin.Current); //移动文件流中的当前指针
            startSize = fs.Length;
        }
        else
        {
            // 不存在则新建
            fs = new System.IO.FileStream(savePath, FileMode.Create);
            startSize = 0;
        }

        try
        {
            var request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(new System.Uri(url));

            request.Timeout = timeOut;
            // 设置range值
            minRange += startSize;

            if (minRange > maxRange)
            {

                cb(startSize);
                return;
            }
            if (maxRange < minRange)
            {
                request.AddRange(minRange);
            }
            else
            {
                request.AddRange(minRange, maxRange);
            }
            // 开始读取文件流
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.Stream ns = response.GetResponseStream();

            byte[] nbytes = new byte[rlen];
            int nReadSize;
            long size = 0 + startSize;
            long count = response.ContentLength + startSize;
            do
            {
                nReadSize = ns.Read(nbytes, 0, nbytes.Length);
                size += nReadSize;
                fs.Write(nbytes, 0, nReadSize);
                if (downloading != null)
                {
                    downloading(size, count);
                }

            } while (nReadSize > 0);
            fs.Flush();
            fs.Close();
            ns.Close();
            response.Close();
            request.Abort();

            cb(size);
        }
        catch (Exception ex)
        {
            if (error != null) error(ex);
            throw;
        }

    }
}