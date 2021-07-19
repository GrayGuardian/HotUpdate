

using System;
using System.IO;
using System.Threading;
using UnityEngine;

public enum ENV_TYPE
{
    // 正式环境
    MASTER = 0,
    // 开发环境
    DEV = 1,

}
public class GameConst
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        MainThreadSynContext = SynchronizationContext.Current;
    }

    /// <summary>
    /// Unity主线程
    /// </summary>
    public static SynchronizationContext MainThreadSynContext = System.Threading.SynchronizationContext.Current;

    /// <summary>
    /// 运行环境
    /// </summary>
#if UNITY_EDITOR
    public static ENV_TYPE PRO_ENV = ENV_TYPE.DEV;
#else
    public static ENV_TYPE PRO_ENV = ENV_TYPE.MASTER;
#endif

    /// <summary>
    /// Resources文件夹
    /// </summary>
    /// <returns></returns>
    public static string RESOURCES = Path.Combine(Application.dataPath, "./Resources");
    /// <summary>
    /// 资源存放根目录
    /// </summary>
    /// <returns></returns>
    public static string Asset_ROOT = Path.Combine(Application.persistentDataPath, "./Asset");
    /// <summary>
    /// 打包根目录
    /// </summary>
    /// <returns></returns>
    public static string BUILD_ROOT = Path.Combine(Application.dataPath, "../Build");
    /// <summary>
    /// AB包根目录
    /// </summary>
    /// <returns></returns>
    public static string AssetBundles_ROOT = Path.Combine(Application.dataPath, "../AssetBundles");

    /// <summary>
    /// StreamingAssetsPath目录
    /// </summary>
    public static string StreamingAssetsPath = Application.streamingAssetsPath;


    /// <summary>
    /// 通知主线程回调
    /// </summary>
    public static void PostMainThreadAction(Action action)
    {
        MainThreadSynContext.Post(new SendOrPostCallback((o) =>
        {
            Action e = (Action)o.GetType().GetProperty("action").GetValue(o);
            if (e != null) e();
        }), new { action = action });
    }
    public static void PostMainThreadAction<T>(Action<T> action, T arg1)
    {
        MainThreadSynContext.Post(new SendOrPostCallback((o) =>
        {
            Action<T> e = (Action<T>)o.GetType().GetProperty("action").GetValue(o);
            T t1 = (T)o.GetType().GetProperty("arg1").GetValue(o);
            if (e != null) e(t1);
        }), new { action = action, arg1 = arg1 });
    }
    public static void PostMainThreadAction<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2)
    {
        MainThreadSynContext.Post(new SendOrPostCallback((o) =>
         {
             Action<T1, T2> e = (Action<T1, T2>)o.GetType().GetProperty("action").GetValue(o);
             T1 t1 = (T1)o.GetType().GetProperty("arg1").GetValue(o);
             T2 t2 = (T2)o.GetType().GetProperty("arg2").GetValue(o);
             if (e != null) e(t1, t2);
         }), new { action = action, arg1 = arg1, arg2 = arg2 });
    }
    public static void PostMainThreadAction<T1, T2, T3>(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
    {
        MainThreadSynContext.Post(new SendOrPostCallback((o) =>
         {
             Action<T1, T2, T3> e = (Action<T1, T2, T3>)o.GetType().GetProperty("action").GetValue(o);
             T1 t1 = (T1)o.GetType().GetProperty("arg1").GetValue(o);
             T2 t2 = (T2)o.GetType().GetProperty("arg2").GetValue(o);
             T3 t3 = (T3)o.GetType().GetProperty("arg3").GetValue(o);
             if (e != null) e(t1, t2, t3);
         }), new { action = action, arg1 = arg1, arg2 = arg2, arg3 = arg3 });
    }
    public static void PostMainThreadAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        MainThreadSynContext.Post(new SendOrPostCallback((o) =>
         {
             Action<T1, T2, T3, T4> e = (Action<T1, T2, T3, T4>)o.GetType().GetProperty("action").GetValue(o);
             T1 t1 = (T1)o.GetType().GetProperty("arg1").GetValue(o);
             T2 t2 = (T2)o.GetType().GetProperty("arg2").GetValue(o);
             T3 t3 = (T3)o.GetType().GetProperty("arg3").GetValue(o);
             T4 t4 = (T4)o.GetType().GetProperty("arg4").GetValue(o);
             if (e != null) e(t1, t2, t3, t4);
         }), new { action = action, arg1 = arg1, arg2 = arg2, arg3 = arg3, arg4 = arg4 });
    }
}