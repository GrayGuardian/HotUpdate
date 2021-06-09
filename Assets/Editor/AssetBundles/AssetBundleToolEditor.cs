using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

public class AssetBundleEditor : MonoBehaviour
{ 
    /// <summary>
    /// 打开文件夹
    /// </summary>
    /// <param name="path"></param>
    static void OpenFolder(string path)
    {
        path = new DirectoryInfo(path).FullName;
        if (!Directory.Exists(path))
        {
            if (UnityEditor.EditorUtility.DisplayDialog("提示", "文件夹不存在 是否创建？\n Url:" + path, "确定", "取消"))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                return;
            }
        }
        string arg = string.Format(@"/open,{0}", path);
        System.Diagnostics.Process.Start("explorer.exe", arg);
    }
    /// <summary>
    /// 复制资源到指定文件夹
    /// </summary>
    /// <param name="rootDir"></param>
    static void CopyResToRoot(DirectoryInfo rootDir)
    {
        string path;
        var rootBuildDir = new DirectoryInfo(GameConst.BUILD_ROOT);
        var rootABDir = new DirectoryInfo(Path.Combine(rootBuildDir.FullName, "./AssetBundles"));
        var versionFile = new FileInfo(Path.Combine(rootBuildDir.FullName, "./Version"));
        if (!Directory.Exists(rootDir.FullName))
        {
            Debug.Log("创建资源文件夹");
            Directory.CreateDirectory(rootDir.FullName);
        }
        if (!Directory.Exists(rootBuildDir.FullName))
        {
            UnityEditor.EditorUtility.DisplayDialog("提示", "Build文件夹不存在,请重新构建\n Url:" + rootBuildDir.FullName, "确定");
            return;
        }


        if (!File.Exists(versionFile.FullName))
        {
            UnityEditor.EditorUtility.DisplayDialog("提示", "Build - Version文件不存在,请重新构建\n Url:" + versionFile.FullName, "确定");
        }
        else
        {
            path = Path.Combine(rootDir.FullName, "./Version");
            versionFile.CopyTo(path, true);
            Debug.Log(string.Format("[{0}] Copy To >>> Path:{1}", "Version", path));
        }

        if (!Directory.Exists(rootABDir.FullName))
        {
            UnityEditor.EditorUtility.DisplayDialog("提示", "Build - AB文件夹不存在,请重新构建\n Url:" + rootABDir.FullName, "确定");
        }
        else
        {
            path = Path.Combine(rootDir.FullName, "./AssetBundles");
            if (!Directory.Exists(path))
            {
                Debug.Log("创建资源文件夹 - AB包");
                Directory.CreateDirectory(path);
            }
            else
            {
                foreach (var fileInfo in new DirectoryInfo(path).GetFiles())
                {
                    //清空导出AB包文件
                    fileInfo.Delete();
                }
            }
            foreach (var file in rootABDir.GetFiles())
            {
                file.CopyTo(Path.Combine(path, file.Name), true);
                Debug.Log(string.Format("AB - [{0}] Copy To >>> Path:{1}", file.Name, path));
            };

        }

    }
    /// <summary>
    /// 获取资源AB包依赖信息(AB包形式)
    /// </summary>
    /// <returns></returns>
    static string getRelyJson(){        
        JObject abInfoJObject = new JObject();

        // 遍历AB包
        foreach (var abName in AssetDatabase.GetAllAssetBundleNames()){
            JObject abRelyInfoJObject = new JObject();;
            // 遍历AB包内包含的资源路径
            foreach (var assetFilePath in AssetDatabase.GetAssetPathsFromAssetBundle(abName))
            {
                string assetName = Path.GetFileNameWithoutExtension(assetFilePath);
                string extName = Path.GetExtension(assetFilePath);
                if (".mat|.anim|.prefab|.unity|.asset|.guiskin|.fontsettings|.controller".IndexOf(extName) != -1)
                {
                    // 查找依赖关系
                    var relyAssetFilePaths = GetRelyAssetFilePaths(assetFilePath);
                    if (relyAssetFilePaths.Length > 0){
                        // 存在依赖关系
                        // 获得依赖AB包名数组
                        List<string> relyABs = new List<string>();
                        foreach (var path in relyAssetFilePaths)
                        {
                            string ab = AssetDatabase.GetImplicitAssetBundleName(path);
                            if (ab != abName)
                            {
                                if (relyABs.IndexOf(ab) == -1)
                                {
                                    relyABs.Add(ab);
                                }
                            }
                        }
                        // 构建Json
                        if (relyABs.Count > 0)
                        {
                            JArray abRelyJArr = new JArray();
                            foreach (var ab in relyABs)
                            {
                                abRelyJArr.Add(ab);
                            }
                            abRelyInfoJObject.Add(assetName,abRelyJArr);
                        }
                    }
                }
            }
            abInfoJObject.Add(abName,abRelyInfoJObject);
        }
        // JObject jObject = new JObject();
        // jObject.Add("AssetBundles",abInfoJObject);
        string json = abInfoJObject.ToString();
        return json;
    }
    /// <summary>
    /// 获取依赖资源文件路径集
    /// </summary>
    /// <returns></returns>
    static string[] GetRelyAssetFilePaths(string filePath, List<string> filePathList = null)
    {
        if (filePathList == null)
        {
            filePathList = new List<string>();
        }

        if (filePath.IndexOf("Assets/Resources/AssetBundles/") != -1 && filePathList.IndexOf(filePath) == -1)
        {
            filePathList.Add(filePath);
        }
        if (".mat|.anim|.prefab|.unity|.asset|.guiskin|.fontsettings|.controller".IndexOf(Path.GetExtension(filePath)) == -1)
        {
            return filePathList.ToArray();
        }


        string str = Util.File.ReadString(filePath);
        foreach (Match match in Regex.Matches(str, @"guid: (.+),"))
        {
            if (match.Groups.Count > 1)
            {
                string guid = match.Groups[1].Value;

                GetRelyAssetFilePaths(AssetDatabase.GUIDToAssetPath(guid), filePathList);
            }
        }

        return filePathList.ToArray();
    }

    [MenuItem("Tools/AssetBundle/Open Folder/AssetBundles Folder")]
    static void OpenABFolder()
    {
        OpenFolder(GameConst.AssetBundles_ROOT);
    }
    [MenuItem("Tools/AssetBundle/Open Folder/Build Folder")]
    static void OpenBuildFolder()
    {
        OpenFolder(GameConst.BUILD_ROOT);
    }
    [MenuItem("Tools/AssetBundle/Open Folder/Res Folder")]
    static void OpenResFolder()
    {
        OpenFolder(GameConst.RES_ROOT);
    }

    [MenuItem("Tools/AssetBundle/Build/Build")]
    static void Build(){
        // 准备工作 创建需要用到的文件夹
        var rootDir = new DirectoryInfo(GameConst.BUILD_ROOT);
        var rootABDir = new DirectoryInfo(Path.Combine(rootDir.FullName, "./AssetBundles"));
        var versionFile = new FileInfo(Path.Combine(rootDir.FullName, "./Version"));
        var relyFile = new FileInfo(Path.Combine(rootABDir.FullName, "./Rely"));
        if(!Directory.Exists(GameConst.AssetBundles_ROOT)){
            Directory.CreateDirectory(GameConst.AssetBundles_ROOT);
            Debug.Log("AssetBundles文件夹不存在，重新创建");
        }
        if (!Directory.Exists(rootDir.FullName))
        {
            Directory.CreateDirectory(rootDir.FullName);
            Debug.Log("Build文件夹不存在，重新创建");
        }
        if (!Directory.Exists(rootABDir.FullName))
        {
            Directory.CreateDirectory(rootABDir.FullName);
            Debug.Log("Build中的AssetBundles文件夹不存在，重新创建");
        }
        foreach (var fileInfo in rootABDir.GetFiles())
        {
            //清空导出AB包文件
            fileInfo.Delete();
        }
        // 构建资源
        // 导出AB包
        BuildPipeline.BuildAssetBundles(GameConst.AssetBundles_ROOT, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
        // 二次加密导出AB包
        List<ABVModel> abVModelList = new List<ABVModel>();
        string[] blackFilesName = new string[] { "AssetBundles" };
        foreach (var file in new DirectoryInfo(GameConst.AssetBundles_ROOT).GetFiles())
        {
            //Debug.Log(string.Format("文件路径：{0} 后缀名：{1} 文件名{2}",VARIABLE,Path.GetExtension(VARIABLE),Path.GetFileNameWithoutExtension(VARIABLE)) );
            //存在后缀名则跳过
            if (Path.GetExtension(file.FullName) == ".manifest")
            {
                continue;
            }
            //黑名单存在则跳过
            if (Array.IndexOf(blackFilesName, Path.GetFileName(file.FullName)) != -1)
            {
                continue;
            }
            var bytes = Util.Encrypt.AesEncrypt(Util.File.ReadBytes(file.FullName));
            var name = Path.GetFileNameWithoutExtension(file.FullName);
            var size = bytes.Length;
            var hash = Util.File.ComputeHash(bytes);

            //build AB File
            Util.File.WriteBytes(Path.Combine(rootABDir.FullName, name), bytes);
            Debug.Log(string.Format("Build AB Res >>>> name:{0} size:{1} hash:{2}", name, size, hash));
            
            //build version File
            abVModelList.Add(new ABVModel() { name = name, size = size, hash = hash });
        }
        // 导出AB包依赖信息
        string json = getRelyJson();
        Debug.Log("Rely Json:" + json);

        Util.Encrypt.WriteString(relyFile.FullName,json);
        // 导出版本信息
        // 此处后期可做成可视化视图
        VModel vModel = new VModel();
        vModel.Version = "1.0.0";
        vModel.ClientVersion = Application.version;
        vModel.IsRestart = true;
        vModel.Content = "我是更新描述!";
        vModel.ABs = abVModelList.ToArray();
        json = vModel.toString();
        Debug.Log("Version Json:" + json);

        Util.Encrypt.WriteString(versionFile.FullName, json);

        // 复制部分默认文件到StreamingAssetsPath
        string[] defaultFiles = new string[]{ "./Version","./AssetBundles/Rely" }; 
         if(!Directory.Exists(GameConst.StreamingAssetsPath)){
            Directory.CreateDirectory(GameConst.StreamingAssetsPath);
            Debug.Log("StreamingAssetsPath文件夹不存在，重新创建");
        }
        foreach (var fileName in defaultFiles)
        {
            string filePath = Path.Combine(GameConst.StreamingAssetsPath,fileName);
            FileInfo file = new FileInfo(Path.Combine(GameConst.BUILD_ROOT,fileName));
            if(File.Exists(file.FullName)){
                // 复制默认资源至StreamingAssetsPath
                Util.File.CopyTo(file.FullName,filePath,true);
                Debug.Log("复制默认资源至StreamingAssetsPath >>> "+ filePath);
            }
        }
    }
    [MenuItem("Tools/AssetBundle/Build/Build ＆ CopyTo ResRoot")]
    static void BuildAndCopy1(){
        Build();
        CopyResToRoot(new DirectoryInfo(GameConst.RES_ROOT));
    }
}
