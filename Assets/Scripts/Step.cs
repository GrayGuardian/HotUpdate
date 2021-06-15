
using UnityEngine;
public class Step : MonoBehaviour
{
    private void Awake()
    {
        MonoSingleton.Instance.MonoGo.AddComponent<TestConsole>().Show();
        // UnityEngine.Debug.Log(Util.Asset.getAssetFileBytes("AssetBundleRely").Length);
        MonoSingleton.Instance.MonoGo.AddComponent<LuaClient>();
    }



}
