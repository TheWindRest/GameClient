using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using LuaInterface;
using UObject = UnityEngine.Object;
using UnityEngine.SceneManagement;

public class ResourceManager : UnitySingleton<ResourceManager>
{
    string m_BaseDownloadingURL = "";
    AssetBundleManifest m_AssetBundleManifest = null;
    Dictionary<string, AssetBundle> m_LoadedAssetBundles = new Dictionary<string, AssetBundle>();

    public void Initialize(string manifestName, Action initOK)
    {
        m_BaseDownloadingURL = AppConst.RelativePath;
        m_AssetBundleManifest = LoadAssetSync(manifestName, "AssetBundleManifest") as AssetBundleManifest;
        if (initOK != null) initOK();
    }

    public GameObject LoadPrefab(string abName, string assetName)
    {
        return LoadAssetSync(abName, assetName) as GameObject;
    }

    public TextAsset LoadTextAsset(string abName, string assetName)
    {
        return LoadAssetSync(abName, assetName) as TextAsset;
    }

    public Sprite LoadSprite(string abName, string assetName)
    {
        return LoadAssetSync(abName, assetName) as Sprite;
    }

    public bool LoadScene(string abName)
    {
        AssetBundle ab = LoadAssetBundle(abName);
        return ab != null;
    }

    public void LoadPrefabAsync(string abName, string assetName, Action<GameObject> CSFunc = null, LuaFunction LuaFunc = null)
    {
        StartCoroutine(LoadAssetAsync(abName, assetName, delegate (UObject uObject) {
            if (CSFunc != null)
            {
                CSFunc(uObject as GameObject);
            }

            if (LuaFunc != null)
            {
                LuaFunc.Call(uObject as GameObject);
                LuaFunc.Dispose();
            }
        }));
    }

    public void LoadTextAsync(string abName, string assetName, Action<TextAsset> CSFunc = null, LuaFunction LuaFunc = null)
    {
        StartCoroutine(LoadAssetAsync(abName, assetName, delegate(UObject uObject) {
            if (CSFunc != null)
            {
                CSFunc(uObject as TextAsset);
            }

            if(LuaFunc != null)
            {
                LuaFunc.Call(uObject as TextAsset);
                LuaFunc.Dispose();
            }
        }));
    }

    private IEnumerator LoadAssetAsync(string abName, string assetName, Action<UObject> CSFunc)
    {
        UObject result;
        abName = abName.ToLower() + AppConst.ExtName;
        if (m_LoadedAssetBundles.ContainsKey(abName))
        {
            result  = m_LoadedAssetBundles[abName];
        }
        else
        {
            var path = AppConst.RelativePath + abName;
            WWW download = WWW.LoadFromCacheOrDownload(path, m_AssetBundleManifest.GetAssetBundleHash(abName), 0);
            yield return download;
            AssetBundle assetObj = download.assetBundle;
            m_LoadedAssetBundles.Add(abName, assetObj);
            result = assetObj.LoadAsset(assetName);
        }
        
        if (CSFunc != null)
        {
            CSFunc(result);
        }
    }

    public UObject LoadAssetSync(string abName, string assetName)
    {
        AssetBundle ab = LoadAssetBundle(abName);
        if (ab == null)
        {
            Debug.LogError("资源包不存在：" + abName);
            return null;
        }
        return ab.LoadAsset(assetName);
    }

    private AssetBundle LoadAssetBundle(string abName)
    {
        if (abName == AppConst.ManifestName)
        {
            return AssetBundle.LoadFromFile(AppConst.RelativePath + abName);
        }

        abName = abName.ToLower() + AppConst.ExtName;
        if (m_LoadedAssetBundles.ContainsKey(abName))
        {
            return m_LoadedAssetBundles[abName];
        }
        else
        {
            string[] dependencies = m_AssetBundleManifest.GetAllDependencies(abName);
            for (int i = 0; i < dependencies.Length; i++)
            {
                string depName = dependencies[i];
                if (!m_LoadedAssetBundles.ContainsKey(depName))
                {
                    AssetBundle ab = AssetBundle.LoadFromFile(AppConst.RelativePath + depName);
                    m_LoadedAssetBundles.Add(depName, ab);
                }
            }
            var bundle = AssetBundle.LoadFromFile(AppConst.RelativePath + abName);
            m_LoadedAssetBundles.Add(abName, bundle);
            return bundle;
        }
    }
}