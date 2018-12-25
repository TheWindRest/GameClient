using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using System;

public class LuaManager : UnitySingleton<LuaManager>
{
    private LuaState lua;
    private LuaLoader loader;
    private LuaLooper loop = null;

    public override void Awake()
    {
        base.Awake();
        loader = new LuaLoader();
        lua = new LuaState();
        OpenLibs();
        lua.LuaSetTop(0);

        LuaBinder.Bind(lua);
        DelegateFactory.Init();
        LuaCoroutine.Register(lua, this);
    }

    public void InitStart()
    {
        if (AppConst.DebugMode)
        {
            lua.AddSearchPath(Application.dataPath + "/Lua");
            lua.AddSearchPath(Application.dataPath + "/ToLua/Lua");
        }

        InitLuaBundle();
        this.lua.Start();    //启动LUAVM
        this.StartMain();
        this.StartLooper();
    }

    /// <summary>
    /// 初始化LuaBundle
    /// </summary>
    void InitLuaBundle()
    {
        if (loader.beZip)
        {
            loader.AddBundle("lua/lua.unity3d");
            loader.AddBundle("lua/lua_system.unity3d");
            loader.AddBundle("lua/lua_system_reflection.unity3d");
            loader.AddBundle("lua/lua_system_injection.unity3d");
            loader.AddBundle("lua/lua_unityengine.unity3d");
            loader.AddBundle("lua/lua_misc.unity3d");

            loader.AddBundle("lua/lua_protobuf.unity3d");
            loader.AddBundle("lua/lua_protos.unity3d");
            loader.AddBundle("lua/lua_tools_events.unity3d");
            loader.AddBundle("lua/lua_windows.unity3d");
        }
    }

    void StartMain()
    {
        lua.DoFile("Main.lua");

        LuaFunction main = lua.GetFunction("Main");
        main.Call();
        main.Dispose();
        main = null;
    }

    void StartLooper()
    {
        loop = gameObject.AddComponent<LuaLooper>();
        loop.luaState = lua;
    }

    /// <summary>
    /// 初始化加载第三方库
    /// </summary>
    void OpenLibs()
    {
        lua.OpenLibs(LuaDLL.luaopen_pb);
        lua.OpenLibs(LuaDLL.luaopen_sproto_core);
        lua.OpenLibs(LuaDLL.luaopen_lpeg);
        lua.OpenLibs(LuaDLL.luaopen_bit);
        lua.OpenLibs(LuaDLL.luaopen_socket_core);
        lua.OpenLibs(LuaDLL.luaopen_protobuf_c);

        this.OpenCJson();

        if (LuaConst.openLuaSocket)
        {
            OpenLuaSocket();
        }
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int LuaOpen_Socket_Core(IntPtr L)
    {
        return LuaDLL.luaopen_socket_core(L);
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int LuaOpen_Mime_Core(IntPtr L)
    {
        return LuaDLL.luaopen_mime_core(L);
    }

    protected void OpenLuaSocket()
    {
        LuaConst.openLuaSocket = true;
        lua.BeginPreLoad();
        lua.RegFunction("socket.core", LuaOpen_Socket_Core);
        lua.RegFunction("mime.core", LuaOpen_Mime_Core);
        lua.EndPreLoad();
    }

    //cjson 比较特殊，只new了一个table，没有注册库，这里注册一下
    protected void OpenCJson()
    {
        lua.LuaGetField(LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
        lua.OpenLibs(LuaDLL.luaopen_cjson);
        lua.LuaSetField(-2, "cjson");

        lua.OpenLibs(LuaDLL.luaopen_cjson_safe);
        lua.LuaSetField(-2, "cjson.safe");
    }

    public void DoFile(string filename)
    {
        lua.DoFile(filename);
    }

    public void Require(string filename)
    {
        lua.Require(filename);
    }

    public void Close()
    {
        if(loop != null)
        {
            loop.Destroy();
            loop = null;
        }

        if(lua != null)
        {
            lua.Dispose();
            lua = null;
        }

        loader = null;
    }
}
