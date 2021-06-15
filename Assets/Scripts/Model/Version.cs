using Newtonsoft.Json;

public class AssetVModel
{
    /// <summary>
    /// 资源名
    /// </summary>
    public string name;
    /// <summary>
    /// 资源文件名
    /// </summary>
    public string fileName;
    /// <summary>
    /// 资源文件大小
    /// </summary>
    public long size;
    /// <summary>
    /// 资源文件Hash值
    /// </summary>
    public string hash;

    public string toString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
public class VModel
{
    /// <summary>
    /// 版本号
    /// </summary>
    public string Version;
    /// <summary>
    /// 客户端版本号（不一致则提示下载安装包更新）
    /// </summary>
    public string ClientVersion;
    /// <summary>
    /// 是否需要重启
    /// </summary>
    public bool IsRestart;
    /// <summary>
    /// 更新内容
    /// </summary>
    public string Content;
    /// <summary>
    /// AB包版本信息
    /// </summary>
    public AssetVModel[] Assets;

    public string toString()
    {
        return JsonConvert.SerializeObject(this);
    }
}