using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventListener : EventTrigger
{
    [System.NonSerialized]
    GameObject m_GameObjectRef = null;
    [System.NonSerialized]
    object m_callbackLuaClass = null;
    [System.NonSerialized]
    LuaFunction m_callbackLuaFunc = null;
    [System.NonSerialized]
    object m_Param = null;

    public void Listen(GameObject go, EventTriggerType EventTriggerType, object callbackLuaClass, LuaFunction callbackLuaFunc, object param = null)
    {
        triggers.RemoveAll(s => s.eventID == EventTriggerType);

        m_GameObjectRef = go;
        m_callbackLuaClass = callbackLuaClass;
        m_callbackLuaFunc = callbackLuaFunc;
        m_Param = param;

        Entry entry = new Entry();
        entry.eventID = EventTriggerType;
        entry.callback.AddListener(delegate(BaseEventData baseEventData)
        {
            try
            {
                m_callbackLuaFunc.BeginPCall();
                m_callbackLuaFunc.Push(m_callbackLuaClass);
                m_callbackLuaFunc.Push(m_GameObjectRef);
                m_callbackLuaFunc.Push(m_Param);
                m_callbackLuaFunc.PCall();
                m_callbackLuaFunc.EndPCall();
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("游戏物体{0} 的回掉接口中存在错误", go.name));
                Debug.LogError(ex.ToString());
            }
        });

        triggers.Add(entry);
    }    
}
