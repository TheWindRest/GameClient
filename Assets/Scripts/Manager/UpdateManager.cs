using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using System.Reflection;
using System.IO;
using System.Text;

public class UpdateManager : UnitySingleton<UpdateManager>
{
    public GameObject UpdateScene;
    public static readonly string VERSION_FILE = "files.txt";
    private Dictionary<String, String> LocalResVersion = new Dictionary<String, String>();
    private Dictionary<String, String> ServerResVersion = new Dictionary<String, String>();
    private List<String> NeedDownFiles = new List<string>();
    private bool NeedUpdateLocalVersionFile = false;

    private void Start()
    {
        UpdateScene.SetActive(true);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = AppConst.GameFrameRate;

        if (!AppConst.DebugMode)
        {
            UpdateResources();
        }
        else
        {
            StartCoroutine(ExtractResource(OnResourceInited));
        }
    }

    void UpdateResources()
    {
        var localVersion = File.ReadAllText(AppConst.DataPath + VERSION_FILE);
        ParseVersionFile(localVersion, LocalResVersion);                                                                                         //保存本地的version
        StartCoroutine(DownLoad(AppConst.WebUrl + VERSION_FILE, delegate (WWW serverVersion)            //加载服务端version配置
        {
            ParseVersionFile(serverVersion.text, ServerResVersion);                                                                          //保存服务端version
            CompareVersion();                                                                                                                                        //计算出需要重新加载的资源
            DownLoadRes();                                                                                                                                           //加载需要更新的资源
        }));
    }

    private void DownLoadRes()    //依次加载需要更新的资源  
    {
        if (NeedDownFiles.Count == 0)
        {
            UpdateLocalVersionFile();
            return;
        }

        string file = NeedDownFiles[0];
        NeedDownFiles.RemoveAt(0);

        StartCoroutine(this.DownLoad(AppConst.WebUrl + file, delegate (WWW w)
        {
            //将下载的资源替换本地就的资源  
            ReplaceLocalRes(file, w.bytes);
            DownLoadRes();
        }));
    }

    private void ReplaceLocalRes(string fileName, byte[] data)
    {
        string filePath = AppConst.DataPath + fileName;
        FileStream stream = new FileStream(AppConst.DataPath + fileName, FileMode.Create);
        stream.Write(data, 0, data.Length);
        stream.Flush();
        stream.Close();
    }

    //更新本地的version配置  
    private void UpdateLocalVersionFile()
    {
        if (NeedUpdateLocalVersionFile)
        {
            StringBuilder versions = new StringBuilder();
            foreach (var item in ServerResVersion)
            {
                versions.Append(item.Key).Append("|").Append(item.Value).Append("\n");
            }

            FileStream stream = new FileStream(AppConst.DataPath + VERSION_FILE, FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(versions.ToString());
            stream.Write(data, 0, data.Length);
            stream.Flush();
            stream.Close();
        }
        //加载显示对象
        StartCoroutine(ExtractResource(OnResourceInited));
    }

    IEnumerator ExtractResource(Action OnFinish)
    {
        String streamingAssetsPath = AppConst.DataPath;
        String persistentDataPath = AppConst.RelativePath;

        if (Directory.Exists(persistentDataPath))
        {
            Directory.Delete(persistentDataPath, true);
        }
        Directory.CreateDirectory(persistentDataPath);

        string infile = streamingAssetsPath + "files.txt";
        string outfile = persistentDataPath + "files.txt";

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW www = new WWW(infile);
            yield return www;

            if (www.isDone)
            {
                File.WriteAllBytes(outfile, www.bytes);
            }
            yield return 0;
        }
        else File.Copy(infile, outfile, true);
        yield return new WaitForEndOfFrame();

        string[] files = File.ReadAllLines(infile);
        foreach (var file in files)
        {
            string[] fs = file.Split('|');
            if (fs[0].EndsWith(".manifest"))
            {
                continue;
            }
            infile = streamingAssetsPath + fs[0];
            outfile = persistentDataPath + fs[0];

            Debug.Log("正在解包文件:>" + infile);
            string dir = Path.GetDirectoryName(outfile);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            if (Application.platform == RuntimePlatform.Android)
            {
                WWW www = new WWW(infile);
                yield return www;

                if (www.isDone)
                {
                    File.WriteAllBytes(outfile, www.bytes);
                }
                yield return 0;
            }
            else
            {
                if (File.Exists(outfile))
                {
                    File.Delete(outfile);
                }
                File.Copy(infile, outfile, true);
            }
            yield return new WaitForEndOfFrame();
        }
        if(OnFinish != null)
        {
            OnFinish();
        }        
    }
    
    private void CompareVersion()
    {
        foreach (var version in ServerResVersion)
        {
            string fileName = version.Key;
            string serverMd5 = version.Value;
            //新增的资源  
            if (!LocalResVersion.ContainsKey(fileName))
            {
                NeedDownFiles.Add(fileName);
            }
            else
            {
                //需要替换的资源  
                string localMd5;
                LocalResVersion.TryGetValue(fileName, out localMd5);
                if (!serverMd5.Equals(localMd5))
                {
                    NeedDownFiles.Add(fileName);
                }
            }
        }
        //本次有更新，同时更新本地的version.txt  
        NeedUpdateLocalVersionFile = NeedDownFiles.Count > 0;
    }

    private void ParseVersionFile(string content, Dictionary<String, String> dict)
    {
        if (content == null || content.Length == 0)
        {
            return;
        }
        string[] items = content.Split(new char[] { '\n' });
        foreach (string item in items)
        {
            string[] info = item.Split(new char[] { '|' });
            if (info != null && info.Length == 2)
            {
                dict.Add(info[0], info[1]);
            }
        }
    }

    private IEnumerator DownLoad(string url, Action<WWW> finishFun)
    {
        WWW www = new WWW(url);
        yield return www;
        if (finishFun != null)
        {
            finishFun(www);
        }
        www.Dispose();
    }

    /// <summary>
    /// 资源初始化结束
    /// </summary>
    public void OnResourceInited()
    {
        ResourceManager.Instance.Initialize(AppConst.ManifestName, delegate () {
            Debug.Log("Initialize OK!!!");
            OnInitialize();
        });
    }

    void OnInitialize()
    {
        LuaManager.Instance.InitStart();
        LuaManager.Instance.Require("GameInit");         //加载游戏
        Destroy(UpdateScene, 1f);
    }

    /// <summary>
    /// 析构函数
    /// </summary>
    void OnDestroy()
    {
        if (LuaManager.Instance != null)
        {
            LuaManager.Instance.Close();
        }
        Debug.Log("~GameManager was destroyed");
    }
}
