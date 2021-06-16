
using UnityEngine;
public class Step : MonoBehaviour
{
    private void Awake()
    {
        MonoSingleton.Instance.MonoGo.AddComponent<TestConsole>().Show();

        MonoSingleton.Instance.MonoGo.AddComponent<LuaClient>();

    }


    private void Update()
    {

    }
}
