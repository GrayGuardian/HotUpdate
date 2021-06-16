

using System.IO;
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
}