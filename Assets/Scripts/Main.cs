
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main
{
    // 总逻辑入口
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void main()
    {
        // MonoSingleton.Instance.MonoGo.AddComponent<TestConsole>().Show();

        SceneManager.LoadScene("Step");
        MonoUtil.Instance.MonoGo.AddComponent<LuaClient>();
    }
}
