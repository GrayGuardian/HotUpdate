
using UnityEngine;

public class Step : MonoBehaviour
{
    private void Awake()
    {
        MonoSingleton.Instance.MonoGo.AddComponent<LuaClient>();

    }
}
