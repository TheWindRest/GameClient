using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class PacketResources : EditorWindow
{
    static List<string> paths = new List<string>();
    static List<string> files = new List<string>();
    private static bool SingleOrAll = false;
    bool m_IsDoing = false;
    static List<string> m_SelectFiles = new List<string>();    //选中目标文件
    static List<AssetBundleBuild> m_AseetBundleNames = new List<AssetBundleBuild>();    //需要打包的文件

    [MenuItem("Build Resources/Build Resource", false, 90)]
    public static void Menu_CleanGamePackets()
    {
        //创建窗口
        Rect wr = new Rect(0, 0, 300, 100);
        PacketResources window = (PacketResources)EditorWindow.GetWindowWithRect(typeof(PacketResources), wr, true, "打包资源");
        SingleOrAll = true;
        window.Show();
    }

    [MenuItem("Assets/打包选中资源", false, 222)]
    public static void MakeResPack()
    {
        UnityEngine.Object[] seldObjs = Selection.GetFiltered<UnityEngine.Object>(SelectionMode.Assets);
        if (seldObjs != null && seldObjs.Length > 0)
        {
            foreach (UnityEngine.Object seldObj in seldObjs)
            {
                string path = AssetDatabase.GetAssetPath(seldObj);
                path = Application.dataPath.Substring(0, Application.dataPath.Length - 6) + path;
                Debug.Log(path);
                m_SelectFiles.Add(path);
            }
        }
        //创建窗口
        Rect wr = new Rect(0, 0, 300, 100);
        PacketResources window = (PacketResources)EditorWindow.GetWindowWithRect(typeof(PacketResources), wr, true, "打包单个资源");
        SingleOrAll = false;
        window.Show();
    }

    //绘制窗口时调用
    void OnGUI()
    {
        //选择目标平台
        EditorGUILayout.LabelField(string.Format("当前平台:{0}", EditorUserBuildSettings.activeBuildTarget.ToString()));
        GUILayout.Space(25);

        if (GUILayout.Button("制作资源包", GUILayout.Width(100)))
        {
            if (!m_IsDoing)
            {
                m_IsDoing = true;
                m_SelectFiles.Clear();
                m_AseetBundleNames.Clear();

                EditorCoroutineRunner.StartEditorCoroutine(coMakePackets());
            }
        }
    }

    IEnumerator coMakePackets()
    {
        using (new MonoEX.SafeCall(() => { }, () => m_IsDoing = false))
        {
            _MakePackets(SingleOrAll);
            Close();
        }
        yield return null;
    }

    public static void _MakePackets(bool AllPacket)
    {        
        var targetDir = AppConst.DataPath;
        if (!Directory.Exists(targetDir))
        {
            Directory.CreateDirectory(targetDir);
        }

        SetAssetBundleName(AllPacket);
        BuildPipeline.BuildAssetBundles(targetDir, m_AseetBundleNames.ToArray<AssetBundleBuild>(), BuildAssetBundleOptions.DeterministicAssetBundle, EditorUserBuildSettings.activeBuildTarget);
        BuildFileIndex();

        string streamDir = Application.dataPath + "/" + AppConst.LuaTempDir;
        if (Directory.Exists(streamDir)) Directory.Delete(streamDir, true);

        var currentPath = new DirectoryInfo(AppConst.DataPath);
        DeletateFilesByType(currentPath);

        AssetDatabase.Refresh();
        Debug.Log("资源打包完成.");
    }

    public static void BuildFileIndex()
    {
        string resPath = Application.dataPath.ToLower() + "/StreamingAssets/";
        ///----------------------创建文件列表-----------------------
        string newFilePath = resPath + "/files.txt";
        if (File.Exists(newFilePath)) File.Delete(newFilePath);

        paths.Clear(); files.Clear();
        Recursive(resPath);

        FileStream fs = new FileStream(newFilePath, FileMode.CreateNew);
        StreamWriter sw = new StreamWriter(fs);
        for (int i = 0; i < files.Count; i++)
        {
            string file = files[i];
            if (file.EndsWith(".meta") || file.Contains(".DS_Store")) continue;

            string md5 = AppConst.md5file(file);
            string value = file.Replace(resPath, string.Empty);
            sw.WriteLine(value + "|" + md5);
        }
        sw.Close(); fs.Close();
    }

    /// <summary>
    /// 遍历目录及其子目录
    /// </summary>
    static void Recursive(string path)
    {
        string[] names = Directory.GetFiles(path);
        string[] dirs = Directory.GetDirectories(path);
        foreach (string filename in names)
        {
            string ext = Path.GetExtension(filename);
            if (ext.Equals(".meta")) continue;
            files.Add(filename.Replace('\\', '/'));
        }
        foreach (string dir in dirs)
        {
            paths.Add(dir.Replace('\\', '/'));
            Recursive(dir);
        }
    }

    static void SetAssetBundleName(bool AllPacket)
    {
        AssetDatabase.Refresh();
        if (AllPacket)
        {
            string resourcesDir = Application.dataPath + "/Resources";
            {
                DirectoryInfo dirObj = new DirectoryInfo(resourcesDir);
                _SetAssetBundleName(dirObj);
            }

            AddLuaFiles();
        }
        else
        {
            foreach (String curr in m_SelectFiles)
            {
                Debug.Log(curr);
                DirectoryInfo currdir = new DirectoryInfo(curr);
                if (currdir.Name.Length > 1 && currdir.Name[0] == '@')
                {
                    SetAssetBundleName(currdir.Name.Substring(1, currdir.Name.Length - 1), currdir);
                }
                else
                {
                    Debug.LogError("资源包必须以@开头：" + currdir.FullName);
                    AssetDatabase.Refresh();
                    break;
                }
            }
        }
        AssetDatabase.Refresh();
        UnityEngine.Debug.Log("SetAssetBundleName 完成");
    }

    static void AddLuaFiles()
    {
        string streamDir = Application.dataPath + "/" + AppConst.LuaTempDir;
        if (!Directory.Exists(streamDir)) Directory.CreateDirectory(streamDir);

        string[] srcDirs = { Application.dataPath + "/" + AppConst.LuaDir, Application.dataPath + "/" + AppConst.LuaSourceDir };
        for (int i = 0; i < srcDirs.Length; i++)
        {
            ToLuaMenu.CopyLuaBytesFiles(srcDirs[i], streamDir);
        }
        string[] dirs = Directory.GetDirectories(streamDir, "*", SearchOption.AllDirectories);
        for (int i = 0; i < dirs.Length; i++)
        {
            string name = dirs[i].Replace(streamDir, string.Empty);
            name = name.Replace('\\', '_').Replace('/', '_');
            name = "lua/lua_" + name.ToLower() + AppConst.ExtName;
            string path = "Assets" + dirs[i].Replace(Application.dataPath, "");
            AddBuildMap(name, "*.bytes", path);
        }
        AddBuildMap("lua/lua" + AppConst.ExtName, "*.bytes", "Assets/" + AppConst.LuaTempDir);
    }

    static void AddBuildMap(string bundleName, string pattern, string path)
    {
        string[] files = Directory.GetFiles(path, pattern);
        if (files.Length == 0) return;

        for (int i = 0; i < files.Length; i++)
        {
            files[i] = files[i].Replace('\\', '/');
        }
        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = bundleName;
        build.assetNames = files;
        m_AseetBundleNames.Add(build);
    }

    static void SetPacketName(string path, string packetName)
    {
        string dataPath = Application.dataPath.Substring(0, Application.dataPath.Length - 6);
        string prePath = path.Substring(dataPath.Length, path.Length - dataPath.Length);

        AssetImporter importer = AssetImporter.GetAtPath(prePath);
        if (string.IsNullOrEmpty(importer.assetBundleName) || importer.assetBundleName != packetName)
        {
            importer.assetBundleName = packetName;
            importer.SaveAndReimport();
        }

        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = packetName + AppConst.ExtName;
        build.assetNames = new string[] { prePath };
        m_AseetBundleNames.Add(build);
    }

    static void _SetAssetBundleName(DirectoryInfo dir)
    {
        DirectoryInfo[] alldirs = dir.GetDirectories();
        foreach (DirectoryInfo currdir in alldirs)
        {
            if (currdir.Name.Length > 1 && currdir.Name[0] == '@')
            {
                SetAssetBundleName(currdir.Name.Substring(1, currdir.Name.Length - 1), currdir);
            }
            else
            {
                _SetAssetBundleName(currdir);
            }            
        }
    }

    static void DeletateFilesByType(DirectoryInfo dir, string FileType = ".manifest")
    {
        FileInfo[] allFiles = dir.GetFiles();
        foreach (FileInfo _currFile in allFiles)
        {
            if (_currFile.Extension.ToLower() == FileType)
            {
                _currFile.Delete();
            }
        }

        DirectoryInfo[] alldirs = dir.GetDirectories();
        foreach (DirectoryInfo d in alldirs)
        {
            DeletateFilesByType(d, FileType);
        }
    }

    static void SetAssetBundleName(string _packetName, DirectoryInfo dir)
    {
        FileInfo[] allFiles = dir.GetFiles();
        foreach (FileInfo _currFile in allFiles)
        {
            if (_currFile.Extension.ToLower() == ".meta") continue;
            string packetName = _packetName;
            SetPacketName(_currFile.FullName,packetName);
        }

        DirectoryInfo[] alldirs = dir.GetDirectories();
        foreach (DirectoryInfo d in alldirs)
        {
            SetAssetBundleName(_packetName, d);
        }
    }
}
