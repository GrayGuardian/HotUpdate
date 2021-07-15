using System.Collections;
using UnityEngine;

public class MonoUtil : Singleton<MonoUtil>
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

    [RuntimeInitializeOnLoadMethodAttribute(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    static void Init()
    {
        var go = new GameObject("MonoGo");
        MonoUtil.Instance.MonoGo = go;
        MonoUtil.Instance.MonoComponent = go.AddComponent<MonoComponent>();
        GameObject.DontDestroyOnLoad(go);
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