using System;
using LuaInterface;

public class LuaEventCallback : IEventCallback
{
    internal void Init(object classRef, LuaFunction funcRef)
    {
        m_ClassRef = classRef;
        m_FuncRef = funcRef;
    }

    public void Call(object param)
    {
        _Call(param);
    }
    public void Call(object[] param)
    {
        _Call(param);
    }
    protected virtual void _Call(object param)
    {
        if (m_FuncRef != null)
        {
            m_FuncRef.BeginPCall();
            m_FuncRef.Push(m_ClassRef);
            m_FuncRef.Push(param);
            m_FuncRef.PCall();
            m_FuncRef.EndPCall();
        }
        else
        {
            Debugger.LogError("LuaEventCallback m_FuncRef  is null");
        }
    }
    protected virtual void _Call(object[] param)
    {
        if (m_FuncRef != null)
        {
            m_FuncRef.BeginPCall();
            m_FuncRef.Push(m_ClassRef);
            if(param != null)
            {
                for (int i = 0; i < param.Length; ++i)
                {
                    m_FuncRef.Push(param[i]);
                }
            }
            m_FuncRef.PCall();
            m_FuncRef.EndPCall();
        }
        else
        {
            Debugger.LogError("LuaEventCallback m_FuncRef  object[] param is null");
        }
    }
    public void Dispose()
    {
        if (m_ClassRef != null)
        {
            //类句柄通常是Lua表，如果不释放可能导致c#层的引用句柄泄漏，同时lua层的对象因为引用计数器不为0也不会被清理
            var diposObj = m_ClassRef as IDisposable;
            if (diposObj != null) diposObj.Dispose();

            m_ClassRef = null;
        }
        if (m_FuncRef != null)
        {
            m_FuncRef.Dispose();
            m_FuncRef = null;
        }
    }

    protected object m_ClassRef;//lua类句柄
    protected LuaFunction m_FuncRef;//lua函数句柄

    public object ClassRef
    {
        get
        {
            return m_ClassRef;
        }
    }
    public LuaFunction FuncRef
    {
        get
        {
            return m_FuncRef;
        }
    }
}


