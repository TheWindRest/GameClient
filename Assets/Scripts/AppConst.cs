using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class AppConst {
    public const bool DebugMode = true;                               //调试模式-用于内部测试
    public const bool LuaByteMode = false;                           //Lua字节码模式-默认关闭 
    public const bool LuaBundleMode = true;                        //Lua代码AssetBundle模式

    public const int TimerInterval = 1;
    public const int GameFrameRate = 30;                            //游戏帧频

    public const string ManifestName = "StreamingAssets"; //资源信息文件名称
    public const string LuaTempDir = "TempLua/";                //临时目录
    public const string LuaDir = "Lua";                                   //lua目录
    public const string LuaSourceDir = "ToLua/Lua";             //tolua的lua目录
    public const string ExtName = ".unity3d";                         //素材扩展名
    public const string WebUrl = "http://192.168.1.180:6688/";      //更新地址              http://192.168.0.102:6688

    /// <summary>
    /// 取得数据存放目录
    /// </summary>
    public static string DataPath
    {
        get
        {
            return Application.streamingAssetsPath + "/";
        }
    }

    public static string RelativePath
    {
        get
        {
            string path = string.Empty;
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    path = Application.persistentDataPath + "/";
                    break;
                case RuntimePlatform.IPhonePlayer:
                    path = Application.persistentDataPath + "/";
                    break;
                default:
                    path = Application.dataPath + "/" + "PersistentData" + "/";
                    break;
            }
            return path;
        }        
    }

    /// <summary>
    /// 计算文件的MD5值
    /// </summary>
    public static string md5file(string file)
    {
        try
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(fs);
            fs.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("md5file() fail, error:" + ex.Message);
        }
    }
}
