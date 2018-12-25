using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPGame : MonoBehaviour {

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update () {
        NetworkManager.Instance.Update(Time.deltaTime);
    }

    void OnApplicationQuit()
    {
        Debug.Log("退出游戏");
        NetworkManager.Instance.Close();
    }
}
