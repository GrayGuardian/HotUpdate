
using UnityEngine;
public class Step : MonoBehaviour
{
    private void Awake()
    {
        MonoSingleton.Instance.MonoGo.AddComponent<LuaClient>();
    }

    // public System.Collections.Generic.List<byte> data1 = new System.Collections.Generic.List<byte>();
    // public System.Collections.Generic.List<byte> data2 = new System.Collections.Generic.List<byte>();

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.A))
    //     {
    //         // 下载测试
    //         string url = "http://127.0.0.1/Download/aaa.pdf";

    //         float time = Time.time;
    //         System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(new System.Uri(url));
    //         request.Timeout = 2000;
    //         Util.Http.Download(request, (response, data) =>
    //         {
    //             // foreach (var b in data)
    //             // {
    //             //     print(b);
    //             // }

    //             UnityEngine.Debug.LogFormat("all>>>下载完毕>>>size:{0} time:{1}", data.Length, Time.time - time);

    //             data1.AddRange(data);
    //             // System.IO.File.WriteAllBytes(System.IO.Path.Combine(GameConst.DOWNLOAD_TEMPFILE_ROOT, "./one.pdf"), data);
    //         });


    //         float time1 = Time.time;
    //         System.Net.HttpWebRequest request1 = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(new System.Uri(url));
    //         request1.Timeout = 2000;
    //         request1.AddRange(0, 2903712);
    //         Util.Http.Download(request1, (response, data) =>
    //          {
    //              //  foreach (var b in data)
    //              //  {
    //              //      print(b);
    //              //  }
    //              UnityEngine.Debug.LogFormat("1>>>下载完毕>>>size:{0} time:{1}", data.Length, Time.time - time1);

    //              data2.AddRange(data);
    //          }, null);

    //         float time2 = Time.time;
    //         System.Net.HttpWebRequest request2 = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(new System.Uri(url));
    //         request2.Timeout = 2000;
    //         request2.AddRange(2903713, 5807424);
    //         Util.Http.Download(request2, (response, data) =>
    //         {
    //             // foreach (var b in data)
    //             // {
    //             //     print(b);
    //             // }
    //             UnityEngine.Debug.LogFormat("2>>>下载完毕>>>size:{0} time:{1}", data.Length, Time.time - time2);

    //             data2.AddRange(data);
    //         }, null);
    //     }
    //     if (Input.GetKeyDown(KeyCode.S))
    //     {
    //         UnityEngine.Debug.LogFormat("size - all:{0} two:{1}", data1.Count, data2.Count);
    //     }
    //     if (Input.GetKeyDown(KeyCode.D))
    //     {
    //         System.IO.File.WriteAllBytes(System.IO.Path.Combine(GameConst.DOWNLOAD_TEMPFILE_ROOT, "./all.pdf"), data1.ToArray());
    //         System.IO.File.WriteAllBytes(System.IO.Path.Combine(GameConst.DOWNLOAD_TEMPFILE_ROOT, "./two.pdf"), data2.ToArray());
    //     }
    // }

}
