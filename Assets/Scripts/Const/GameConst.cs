

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
    /// 下载临时文件夹 (断点传续用)
    /// </summary>
    public static string DOWNLOAD_TEMPFILE_ROOT = Path.Combine(Application.persistentDataPath, "./Temp");

    /// <summary>
    /// 不同平台的StreamingAssetsPath可能不同 所以写在这里 如果会不同 到时候通过预处理修改
    /// </summary>
    public static string StreamingAssetsPath = Application.streamingAssetsPath;
}