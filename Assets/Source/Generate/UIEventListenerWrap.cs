﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UIEventListenerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIEventListener), typeof(UnityEngine.EventSystems.EventTrigger));
		L.RegFunction("Listen", Listen);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Listen(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 5)
			{
				UIEventListener obj = (UIEventListener)ToLua.CheckObject<UIEventListener>(L, 1);
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 2, typeof(UnityEngine.GameObject));
				UnityEngine.EventSystems.EventTriggerType arg1 = (UnityEngine.EventSystems.EventTriggerType)ToLua.CheckObject(L, 3, typeof(UnityEngine.EventSystems.EventTriggerType));
				object arg2 = ToLua.ToVarObject(L, 4);
				LuaFunction arg3 = ToLua.CheckLuaFunction(L, 5);
				obj.Listen(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 6)
			{
				UIEventListener obj = (UIEventListener)ToLua.CheckObject<UIEventListener>(L, 1);
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 2, typeof(UnityEngine.GameObject));
				UnityEngine.EventSystems.EventTriggerType arg1 = (UnityEngine.EventSystems.EventTriggerType)ToLua.CheckObject(L, 3, typeof(UnityEngine.EventSystems.EventTriggerType));
				object arg2 = ToLua.ToVarObject(L, 4);
				LuaFunction arg3 = ToLua.CheckLuaFunction(L, 5);
				object arg4 = ToLua.ToVarObject(L, 6);
				obj.Listen(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UIEventListener.Listen");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

