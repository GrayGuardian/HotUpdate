
using UnityEngine;

public class Step : MonoBehaviour
{
    private void Awake()
    {
        MonoSingleton.Instance.MonoGo.AddComponent<LuaClient>();

        GameObject prefab = Util.Asset.LoadAsset(typeof(GameObject),"prefabs","Cube") as GameObject;
        
        GameObject.Instantiate(prefab);


        Debug.Log( Util.Asset.LoadAsset(typeof(UnityEngine.Object),"lua","main.lua"));

    }
}
