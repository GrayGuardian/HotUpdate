
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main
{
    // 总逻辑入口
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void main()
    {
        MonoUtil.Instance.MonoGo.AddComponent<LuaClient>();
    }
}
