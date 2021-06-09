using System.Collections;
using UnityEngine;

public class MonoSingleton : Singleton<MonoSingleton>
{
    public GameObject MonoGo;
    public Transform MonoNode
    {
        get
        {
            return MonoGo.transform;
        }
    }
    public MonoComponent MonoComponent;

    public MonoSingleton()
    {
        MonoGo = new GameObject("MonoGo");
        MonoComponent = MonoGo.AddComponent<MonoComponent>();
        GameObject.DontDestroyOnLoad(MonoGo);
    }
    public Coroutine StartCoroutine(IEnumerator routine)
    {
        return MonoComponent.StartCoroutine(routine);
    }
    public void StopCoroutine(Coroutine routine)
    {
        MonoComponent.StopCoroutine(routine);
    }
    public void StopAllCoroutine()
    {
        MonoComponent.StopAllCoroutines();
    }

}