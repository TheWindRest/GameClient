using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public  class SdataManage : MonoBehaviour {

    private static SdataManage _instance;

    public static SdataManage Instance
    {
        get{
            if(null==_instance)
            {
                _instance=FindObjectOfType(typeof(SdataManage))as SdataManage;
            }
            return _instance;
        }
    }

    public List<SData_Type> LevelItemListData;

    void Awake()
    {
        if(LevelItemListData==null)
            LevelItemListData=new List<SData_Type>();
            string[] _config = File.ReadAllLines(Application.dataPath + "\\MapEditor\\config.txt");
            foreach (string pathname in _config[0].Split(';'))
            {
                LevelItemListData.Add(new SData_Type(pathname+".txt"));            
            }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
