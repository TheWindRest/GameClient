using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


class _Type
{
    public _Type(string[] reader, int row)
    {
        string read = reader[row];
        string[] re = read.Split(';');
        ID = Int32.Parse(re[0]);
        Type = re[1];
    }

    public readonly int ID;
    public readonly string Type;
}
public class SData_Type
{
    public SData_Type(string dataname)
    {
        try
        {
            string[] reader = File.ReadAllLines(Application.dataPath + "\\MapEditor\\MapTypeData\\" + dataname);
            int rowCount = reader.Length;
            for (int row = 0; row < rowCount; row++)
            {
                _Type tpInfo = new _Type(reader, row);
                Data.Add(new KeyValuePair<int, string>(tpInfo.ID, tpInfo.Type));
            }

        }
        catch (Exception e)
        {
            Debug.LogError("装载 Type 错误" + e);
        }
    }

    /// <summary>
    /// 获取Data的键值对形式
    /// </summary>
    /// <returns>Data的键值对</returns>
    public Dictionary<int, string> GetDataDic()
    {
        Dictionary<int, string> _data = new Dictionary<int, string>();

        foreach (KeyValuePair<int, string> kp in Data)
        {
            _data.Add(kp.Key, kp.Value);
        }
        return _data;
    }

    public Dictionary<int, Color> GetDataDicColor()
    {
        Dictionary<int, Color> _dataColor = new Dictionary<int, Color>();

        foreach (KeyValuePair<int, string> kp in Data)
        {
            string[] rgb = kp.Value.Split(',');
            Color _rgb = new Color(float.Parse(rgb[0]) / 255f, float.Parse(rgb[1]) / 255f, float.Parse(rgb[2]) / 255f);
            _dataColor.Add(kp.Key, _rgb);
            //Debug.Log(kp.Key + ":" + kp.Value + ":" + float.Parse(rgb[0]) + " " + float.Parse(rgb[1]) + " " + float.Parse(rgb[2]) + "\n" + _rgb.r + " " + _rgb.g + " " + _rgb.b + " ");

        }
        return _dataColor;
    }

    public List<KeyValuePair<int, string>> Data = new List<KeyValuePair<int, string>>();
}
