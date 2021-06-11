
using UnityEngine;

public class Step : MonoBehaviour
{
    private void Awake()
    {
        // MonoSingleton.Instance.MonoGo.AddComponent<LuaClient>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Util.Http.Get_Asyn("https://etails/109255357", (HttpResult) =>
            {
                print(HttpResult.content);

            }, (ex) =>
            {
                print("出错" + ex.Message);

            });
        }
    }


}
