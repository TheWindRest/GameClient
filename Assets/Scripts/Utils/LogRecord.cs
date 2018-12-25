using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class LogRecord : UnitySingleton<LogRecord>
{
    public struct LogLine
    {
        public LogType LogType;
        public string Content;
    }

    private bool openState = true;
    static List<LogLine> mLines = new List<LogLine>();
    static List<string> mWriteTxt = new List<string>();
    private string outpath;
    void Start()
    {
        if (!Directory.Exists(AppConst.RelativePath))
        {
            Directory.CreateDirectory(AppConst.RelativePath);
        }

        var filename = System.DateTime.Now.ToString("yyyy--MM--dd--HH--mm--ss") + ".txt";
        outpath = AppConst.RelativePath + filename;
        if(!File.Exists(outpath))
        {
            File.Create(outpath).Dispose();
        }
        
        Application.logMessageReceived += HandleLog;
        Debug.Log(outpath);
    }

    void OnApplicationQuit()
    {
        Debug.Log("Quit");
    }

    void Update()
    {
        //因为写入文件的操作必须在主线程中完成，所以在Update中给你写入文件。
        if (mWriteTxt.Count > 0)
        {
            string[] temp = mWriteTxt.ToArray();
            using (StreamWriter writer = new StreamWriter(outpath, true, Encoding.UTF8))
            {
                foreach (string t in temp)
                {
                    writer.WriteLine(t);
                }
                mWriteTxt.Clear();
                writer.Close();
            }
        }
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        mWriteTxt.Add(logString);
        mWriteTxt.Add(stackTrace);

        LogLine logLine = new LogLine();
        logLine.LogType = type;
        logLine.Content = logString;
        Log(logLine);
    }

    private void Log(LogLine Log)
    {
        if (Application.isPlaying)
        {
            if (mLines.Count > 20)
            {
                mLines.RemoveAt(0);
            }
            mLines.Add(Log);
        }
    }

    void OnGUI()
    {
        GUI.color = Color.white;
        GUIStyle bb = new GUIStyle();
        bb.normal.background = null;    //这是设置背景填充的
        bb.normal.textColor = Color.white;
        bb.fontSize = 11;       //当然，这是字体颜色
        for (int i = 0; i < mLines.Count; ++i)
        {
            LogLine newLine = mLines[i];
            switch (newLine.LogType)
            {
                case LogType.Log:
                    bb.normal.textColor = Color.green;
                    break;
                case LogType.Warning:
                    bb.normal.textColor = Color.yellow;
                    break;
                case LogType.Error:
                    bb.normal.textColor = Color.red;
                    break;
                default:
                    bb.normal.textColor = Color.white;
                    break;
            }
            GUILayout.Label(newLine.Content, bb);
        }
    }

    void OnDestory()
    {
        Application.logMessageReceived -= HandleLog;
    }

    public void ControlOpen()
    {
        if(openState)
        {
            mLines.Clear();
            Application.logMessageReceived -= HandleLog;            
        }
        else
        {
            Application.logMessageReceived += HandleLog;
        }
        openState = !openState;
    }
}
