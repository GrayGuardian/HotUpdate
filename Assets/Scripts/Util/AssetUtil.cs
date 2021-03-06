using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
public class AssetUtil : Singleton<AssetUtil>
{

    private Dictionary<string, byte[]> _bundleBytesMap = new Dictionary<string, byte[]>();

    private Dictionary<string, AssetBundle> _bundleMap = new Dictionary<string, AssetBundle>();

    private JObject _relyJObject;
    private VModel _vModel;

    /// <summary>
    /// 开发环境使用 记录所有ab包资源路径
    /// </summary>
    /// <returns></returns>
    private Dictionary<string, Dictionary<string, string>> _abAssetFileMap = new Dictionary<string, Dictionary<string, string>>();
    public AssetUtil()
    {
        // 开发环境缓存ab包资源路径
#if UNITY_EDITOR
        if (GameConst.PRO_ENV == ENV_TYPE.DEV)
        {
            foreach (var abName in UnityEditor.AssetDatabase.GetAllAssetBundleNames())
            {
                _abAssetFileMap.Add(abName, new Dictionary<string, string>());
                foreach (var assetFilePath in UnityEditor.AssetDatabase.GetAssetPathsFromAssetBundle(abName))
                {
                    string assetName = Path.GetFileNameWithoutExtension(assetFilePath);
                    string dirPath = Path.GetDirectoryName(assetFilePath);
                    dirPath = dirPath.Replace("Assets\\Resources\\", "");
                    dirPath = dirPath.Replace("\\", "/");
                    string path = dirPath + "/" + assetName;
                    _abAssetFileMap[abName].Add(assetName, path);
                }
            }
        }
#endif

    }

    /// <summary>
    /// 查找资源文件字节集
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public byte[] getAssetFileBytes(string name)
    {
        // 从本地资源文件读取
        string filePath = Path.Combine(GameConst.Asset_ROOT, name);
        if (File.Exists(filePath))
        {
            return FileUtil.Instance.ReadBytes(filePath);
        }
        // 从StreamingAssetsPath调用
        WWW www = new WWW(Path.Combine(GameConst.StreamingAssetsPath, name));
        while (!www.isDone) { }
        if (www.bytes.Length > 0)
        {
            return www.bytes;
        }

        // 通过版本文件查找携带md5的名字 递归回调
        string fileName = Path.GetFileNameWithoutExtension(name);
        if (_vModel == null)
        {
            string json = EncryptUtil.Instance.AesDecrypt(System.Text.Encoding.UTF8.GetString(getAssetFileBytes("Version")));
            _vModel = JsonConvert.DeserializeObject<VModel>(json);
        }
        foreach (var asset in _vModel.Assets)
        {
            if (asset.name.IndexOf(fileName) != -1)
            {
                return getAssetFileBytes(asset.fileName);
            }
        }
        return new byte[] { };
    }

    /// <summary>
    /// 获取资源依赖关系
    /// </summary>
    /// <param name="key"></param>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public string[] getRelyBundleKeys(string key, string assetName)
    {
        _relyJObject = _relyJObject ?? JObject.Parse(EncryptUtil.Instance.AesDecrypt(System.Text.Encoding.UTF8.GetString(getAssetFileBytes("AssetBundleRely"))));
        List<string> bundleNameList = new List<string> { key };
        JToken jToken;
        if (_relyJObject.TryGetValue(key, out jToken))
        {
            JToken jArray = jToken[assetName];
            if (jArray != null)
            {
                foreach (var ab in jArray.Values<string>())
                {
                    bundleNameList.Add(ab);
                }
            }
        }
        return bundleNameList.ToArray();
    }

    /// <summary>
    /// 获得解密AB包bytes，并保存到缓存
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public byte[] DecryptBundleBytes(string key)
    {
        if (_bundleBytesMap.ContainsKey(key))
        {
            return _bundleBytesMap[key];
        }
        byte[] data = EncryptUtil.Instance.AesDecrypt(getAssetFileBytes("AssetBundles/" + key));
        _bundleBytesMap.Add(key, data);
        return data;
    }

    /// <summary>
    /// 异步获得解密AB包bytes，并保存到缓存
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool DecryptBundleBytesAsync(string key, Action<byte[]> cb)
    {
        if (_bundleBytesMap.ContainsKey(key))
        {
            cb(_bundleBytesMap[key]);
            return true;
        }
        EncryptUtil.Instance.AesDecryptAsync(getAssetFileBytes("AssetBundles/" + key), (data) =>
        {
            _bundleBytesMap.Add(key, data);
            cb(data);
        });
        return true;
    }
    /// <summary>
    /// AB包加载完毕
    /// </summary>
    /// <param name="key"></param>
    /// <param name="bundle"></param>
    private void _loadBundleOver(string key, AssetBundle bundle)
    {
        Debug.LogFormat("AssetBundle加载完毕>>>{0}", key);
        _bundleMap.Add(key, bundle);
    }
    /// <summary>
    /// AB包卸载完毕
    /// </summary>
    /// <param name="key"></param>
    private void _unloadBundleOver(string key)
    {
        Debug.LogFormat("AssetBundle卸载完毕>>>{0}", key);
        _bundleMap.Remove(key);
    }
    /// <summary>
    /// 加载AB包
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public AssetBundle LoadBundle(string key)
    {
        if (_bundleMap.ContainsKey(key))
        {
            return _bundleMap[key];
        }
        byte[] data = DecryptBundleBytes(key);
        if (data == null) return null;
        AssetBundle bundle = AssetBundle.LoadFromMemory(data);

        _loadBundleOver(key, bundle);

        return bundle;
    }
    /// <summary>
    /// 异步加载AB包
    /// </summary>
    /// <param name="key"></param>
    /// <param name="cb"></param>
    /// <returns></returns>
    public void LoadBundleAsync(string key, Action<AssetBundle> cb = null)
    {
        MonoUtil.Instance.StartCoroutine(_loadBundleAsync(key, cb));
    }
    System.Collections.IEnumerator _loadBundleAsync(string key, Action<AssetBundle> cb = null)
    {
        if (_bundleMap.ContainsKey(key))
        {
            if (cb != null) cb(_bundleMap[key]);
            yield break;
        }
        byte[] data = null;
        bool flag = DecryptBundleBytesAsync(key, (d) =>
        {
            data = d;
        });
        if (!flag)
        {
            if (cb != null) cb(null);
            yield break;
        }
        yield return new WaitUntil(() => { return data != null; });
        var assetLoadRequest = AssetBundle.LoadFromMemoryAsync(data);
        yield return assetLoadRequest;
        AssetBundle bundle = assetLoadRequest.assetBundle;

        _loadBundleOver(key, bundle);

        if (cb != null) cb(bundle);
    }
    /// <summary>
    /// 卸载AB包
    /// </summary>
    /// <param name="key"></param>
    /// <param name="unloadAllLoadedObjects"></param>
    public void UnloadBundle(string key, bool unloadAllLoadedObjects = false)
    {
        if (!_bundleMap.ContainsKey(key))
        {
            return;
        }
        _bundleMap[key].Unload(unloadAllLoadedObjects);
        _unloadBundleOver(key);
    }
    private void _loadAssetFromBundleOver(string key, UnityEngine.Object asset)
    {
        Debug.LogFormat("从AssetBundle加载资源 - key：【{0}】 assetName：【{1}】", key, asset.name);
    }
    /// <summary>
    /// 从AB包中加载资源
    /// </summary>
    /// <param name="key"></param>
    /// <param name="assetName"></param>
    /// <param name="isClose">加载完毕是否卸载AB包</param>
    public UnityEngine.Object LoadAssetFromBundle(Type type, string key, string assetName, bool isClose = true)
    {
        // 加载AB包 包括依赖AB包
        string[] bundleKeys = getRelyBundleKeys(key, assetName);
        List<AssetBundle> bundles = new List<AssetBundle>();
        for (int i = 0; i < bundleKeys.Length; i++)
        {
            var bundle = LoadBundle(bundleKeys[i]);
            if (bundle != null)
            {
                bundles.Add(bundle);
            }
        }
        if (bundles.Count == 0) return null;
        // 加载资源
        var asset = bundles[0].LoadAsset(assetName, type);
        if (asset != null)
        {
            _loadAssetFromBundleOver(key, asset);
        }
        if (isClose)
        {
            foreach (var bundle in bundles)
            {
                UnloadBundle(bundle.name);
            }
        }
        return asset;
    }
    /// <summary>
    /// 从AB包中异步加载资源
    /// </summary>
    /// <param name="type"></param>
    /// <param name="key"></param>
    /// <param name="assetName"></param>
    /// <param name="cb"></param>
    /// <param name="isClose"></param>
    public void LoadAssetFromBundleAsync(Type type, string key, string assetName, Action<UnityEngine.Object> cb, bool isClose = true)
    {
        MonoUtil.Instance.StartCoroutine(_loadAssetFromBundleAsync(type, key, assetName, cb, isClose));
    }
    System.Collections.IEnumerator _loadAssetFromBundleAsync(Type type, string key, string assetName, Action<UnityEngine.Object> cb, bool isClose = true)
    {
        // 加载AB包 包括依赖AB包
        string[] bundleKeys = getRelyBundleKeys(key, assetName);
        List<AssetBundle> bundles = new List<AssetBundle>();
        int sum = 0;
        for (int i = 0; i < bundleKeys.Length; i++)
        {
            LoadBundleAsync(bundleKeys[i], (bundle) =>
            {
                sum += 1;
                if (bundle != null)
                {
                    bundles.Add(bundle);
                }
            });
        }
        yield return new WaitUntil(() => { return bundleKeys.Length <= sum; });
        if (bundles.Count == 0) yield break;
        var assetRequest = bundles[0].LoadAssetAsync(assetName, type);
        yield return assetRequest;
        var asset = assetRequest.asset;
        if (asset != null)
        {
            _loadAssetFromBundleOver(key, asset);
        }
        if (isClose)
        {
            foreach (var bundle in bundles)
            {
                UnloadBundle(bundle.name);
            }
        }
        cb(asset);
    }

    /// <summary>
    /// 开发环境时使用的模拟AB包加载资源
    /// </summary>
    /// <param name="type"></param>
    /// <param name="key"></param>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public UnityEngine.Object LoadAssetFromEditorBundle(Type type, string key, string assetName)
    {
        if (!_abAssetFileMap.ContainsKey(key))
        {
            return null;
        }
        var map = _abAssetFileMap[key];
        if (!map.ContainsKey(assetName))
        {
            return null;
        }
        var path = map[assetName];
        var asset = Resources.Load(path, type);
        if (asset != null)
        {
            Debug.LogFormat("从模拟AssetBundle加载资源 - key：【{0}】 assetName：【{1}】", key, asset.name);
        }

        return asset;
    }
    public void LoadAssetFromEditorBundleAsync(Type type, string key, string assetName, Action<UnityEngine.Object> cb)
    {
        if (!_abAssetFileMap.ContainsKey(key))
        {
            cb(null);
            return;
        }
        var map = _abAssetFileMap[key];
        if (!map.ContainsKey(assetName))
        {
            cb(null);
            return;
        }
        var path = map[assetName];
        MonoUtil.Instance.StartCoroutine(_loadAssetFromResourcesAsync(type, path, (asset) =>
        {
            if (asset != null)
            {
                Debug.LogFormat("从模拟AssetBundle加载资源 - key：【{0}】 assetName：【{1}】", key, asset.name);
            }
            cb(asset);
        }));
    }
    /// <summary>
    /// 从本地资源Resources加载
    /// </summary>
    /// <param name="type"></param>
    /// <param name="key"></param>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public UnityEngine.Object LoadAssetFromResources(Type type, string key, string assetName)
    {
        string path = key + "/" + assetName;
        var asset = Resources.Load(path, type);
        if (asset != null)
        {
            Debug.LogFormat("从Resources加载资源 - key：【{0}】 assetName：【{1}】", key, asset.name);
        }
        return asset;
    }
    public void LoadAssetFromResourcesAsync(Type type, string key, string assetName, Action<UnityEngine.Object> cb)
    {
        string path = key + "/" + assetName;
        MonoUtil.Instance.StartCoroutine(_loadAssetFromResourcesAsync(type, path, (asset) =>
        {
            if (asset != null)
            {
                Debug.LogFormat("从Resources加载资源 - key：【{0}】 assetName：【{1}】", key, asset.name);
            }
            cb(asset);
        }));
    }
    System.Collections.IEnumerator _loadAssetFromResourcesAsync(Type type, string path, Action<UnityEngine.Object> cb)
    {
        ResourceRequest request = Resources.LoadAsync(path, type);
        yield return request;
        var asset = request.asset;
        cb(asset);
    }

    /// <summary>
    /// 资源加载汇总
    /// </summary>
    /// <param name="type"></param>
    /// <param name="key"></param>
    /// <param name="assetName"></param>
    /// <param name="isClose"></param>
    /// <returns></returns>
    public UnityEngine.Object LoadAsset(Type type, string key, string assetName, bool isClose = true)
    {
        UnityEngine.Object asset = null;
        if (GameConst.PRO_ENV == ENV_TYPE.MASTER)
        {
            // 正式环境通过AB包加载
            asset = LoadAssetFromBundle(type, key, assetName, isClose);
        }
        else
        {
            // 开发环境模拟AB包本地加载
            asset = LoadAssetFromEditorBundle(type, key, assetName);
        }
        if (asset == null)
        {
            // AB包方式无法加载，则尝试通过本地Resources加载
            asset = LoadAssetFromResources(type, key, assetName);
        }
        return asset;
    }
    /// <summary>
    /// 资源异步加载汇总
    /// </summary>
    /// <param name="type"></param>
    /// <param name="key"></param>
    /// <param name="assetName"></param>
    /// <param name="cb"></param>
    /// <param name="isClose"></param>
    public void LoadAssetAsync(Type type, string key, string assetName, Action<UnityEngine.Object> cb, bool isClose = true)
    {
        if (GameConst.PRO_ENV == ENV_TYPE.MASTER)
        {
            LoadAssetFromBundleAsync(type, key, assetName, (asset) =>
            {
                if (asset == null)
                {
                    // AB包方式无法加载，则参试通过本地Resources加载
                    LoadAssetFromResourcesAsync(type, key, assetName, cb);
                }
                else
                {
                    cb(asset);
                }
            }, isClose);
        }
        else
        {
            LoadAssetFromEditorBundleAsync(type, key, assetName, (asset) =>
            {
                if (asset == null)
                {
                    // AB包方式无法加载，则参试通过本地Resources加载
                    LoadAssetFromResourcesAsync(type, key, assetName, cb);
                }
                else
                {
                    cb(asset);
                }
            });
        }
    }


}