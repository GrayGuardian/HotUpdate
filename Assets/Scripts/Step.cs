
using UnityEngine;
public class Step : MonoBehaviour
{
    private void Awake()
    {
        MonoSingleton.Instance.MonoGo.AddComponent<TestConsole>().Show();

        MonoSingleton.Instance.MonoGo.AddComponent<LuaClient>();

        // System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(new System.Uri("http://127.0.0.1:80"));
        // string data = "{a:123213123}";
        // request.ContentType = "text/plain";
        // request.Timeout = 1000;
        // UnityEngine.Debug.Log(Util.Http.Post(request, System.Text.Encoding.UTF8.GetBytes(data)).content);
    }



}
