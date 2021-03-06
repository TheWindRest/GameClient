﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LoadingScreenWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LoadingScreen), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("LoadScene", LoadScene);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("canvasAlpha", get_canvasAlpha, set_canvasAlpha);
		L.RegVar("status", get_status, set_status);
		L.RegVar("title", get_title, set_title);
		L.RegVar("titleDescription", get_titleDescription, set_titleDescription);
		L.RegVar("progressBar", get_progressBar, set_progressBar);
		L.RegVar("prefabName", get_prefabName, set_prefabName);
		L.RegVar("SceneBundleName", get_SceneBundleName, set_SceneBundleName);
		L.RegVar("OnLoadFinished", get_OnLoadFinished, set_OnLoadFinished);
		L.RegVar("hintsText", get_hintsText, set_hintsText);
		L.RegVar("HintList", get_HintList, set_HintList);
		L.RegVar("changeHintWithTimer", get_changeHintWithTimer, set_changeHintWithTimer);
		L.RegVar("hintTimerValue", get_hintTimerValue, set_hintTimerValue);
		L.RegVar("imageObject", get_imageObject, set_imageObject);
		L.RegVar("fadingAnimator", get_fadingAnimator, set_fadingAnimator);
		L.RegVar("ImageList", get_ImageList, set_ImageList);
		L.RegVar("changeImageWithTimer", get_changeImageWithTimer, set_changeImageWithTimer);
		L.RegVar("imageTimerValue", get_imageTimerValue, set_imageTimerValue);
		L.RegVar("imageFadingSpeed", get_imageFadingSpeed, set_imageFadingSpeed);
		L.RegVar("objectAnimator", get_objectAnimator, set_objectAnimator);
		L.RegVar("virtualLoadingTimer", get_virtualLoadingTimer, set_virtualLoadingTimer);
		L.RegVar("enableVirtualLoading", get_enableVirtualLoading, set_enableVirtualLoading);
		L.RegVar("enableTitleDesc", get_enableTitleDesc, set_enableTitleDesc);
		L.RegVar("enableRandomHints", get_enableRandomHints, set_enableRandomHints);
		L.RegVar("enableRandomImages", get_enableRandomImages, set_enableRandomImages);
		L.RegVar("enablePressAnyKey", get_enablePressAnyKey, set_enablePressAnyKey);
		L.RegVar("titleText", get_titleText, set_titleText);
		L.RegVar("titleDescText", get_titleDescText, set_titleDescText);
		L.RegVar("fadingAnimationSpeed", get_fadingAnimationSpeed, set_fadingAnimationSpeed);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadScene(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string arg0 = ToLua.CheckString(L, 1);
			LuaFunction arg1 = ToLua.CheckLuaFunction(L, 2);
			LoadingScreen.LoadScene(arg0, arg1);
			return 0;
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_canvasAlpha(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.CanvasGroup ret = obj.canvasAlpha;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index canvasAlpha on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_status(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Text ret = obj.status;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index status on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_title(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Text ret = obj.title;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index title on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_titleDescription(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Text ret = obj.titleDescription;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index titleDescription on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_progressBar(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Slider ret = obj.progressBar;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index progressBar on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_prefabName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, LoadingScreen.prefabName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SceneBundleName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, LoadingScreen.SceneBundleName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnLoadFinished(IntPtr L)
	{
		try
		{
			ToLua.Push(L, LoadingScreen.OnLoadFinished);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hintsText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Text ret = obj.hintsText;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index hintsText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HintList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			System.Collections.Generic.List<string> ret = obj.HintList;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index HintList on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_changeHintWithTimer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool ret = obj.changeHintWithTimer;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index changeHintWithTimer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hintTimerValue(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			float ret = obj.hintTimerValue;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index hintTimerValue on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_imageObject(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Image ret = obj.imageObject;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index imageObject on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fadingAnimator(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.Animator ret = obj.fadingAnimator;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fadingAnimator on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ImageList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			System.Collections.Generic.List<UnityEngine.Sprite> ret = obj.ImageList;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index ImageList on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_changeImageWithTimer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool ret = obj.changeImageWithTimer;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index changeImageWithTimer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_imageTimerValue(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			float ret = obj.imageTimerValue;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index imageTimerValue on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_imageFadingSpeed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			float ret = obj.imageFadingSpeed;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index imageFadingSpeed on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_objectAnimator(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.Animator ret = obj.objectAnimator;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index objectAnimator on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_virtualLoadingTimer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			float ret = obj.virtualLoadingTimer;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index virtualLoadingTimer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enableVirtualLoading(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool ret = obj.enableVirtualLoading;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enableVirtualLoading on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enableTitleDesc(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool ret = obj.enableTitleDesc;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enableTitleDesc on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enableRandomHints(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool ret = obj.enableRandomHints;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enableRandomHints on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enableRandomImages(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool ret = obj.enableRandomImages;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enableRandomImages on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enablePressAnyKey(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool ret = obj.enablePressAnyKey;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enablePressAnyKey on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_titleText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			string ret = obj.titleText;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index titleText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_titleDescText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			string ret = obj.titleDescText;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index titleDescText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fadingAnimationSpeed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			float ret = obj.fadingAnimationSpeed;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fadingAnimationSpeed on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_canvasAlpha(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.CanvasGroup arg0 = (UnityEngine.CanvasGroup)ToLua.CheckObject(L, 2, typeof(UnityEngine.CanvasGroup));
			obj.canvasAlpha = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index canvasAlpha on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_status(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)ToLua.CheckObject<UnityEngine.UI.Text>(L, 2);
			obj.status = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index status on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_title(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)ToLua.CheckObject<UnityEngine.UI.Text>(L, 2);
			obj.title = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index title on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_titleDescription(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)ToLua.CheckObject<UnityEngine.UI.Text>(L, 2);
			obj.titleDescription = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index titleDescription on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_progressBar(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Slider arg0 = (UnityEngine.UI.Slider)ToLua.CheckObject<UnityEngine.UI.Slider>(L, 2);
			obj.progressBar = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index progressBar on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_prefabName(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			LoadingScreen.prefabName = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SceneBundleName(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			LoadingScreen.SceneBundleName = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnLoadFinished(IntPtr L)
	{
		try
		{
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			LoadingScreen.OnLoadFinished = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hintsText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)ToLua.CheckObject<UnityEngine.UI.Text>(L, 2);
			obj.hintsText = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index hintsText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_HintList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			System.Collections.Generic.List<string> arg0 = (System.Collections.Generic.List<string>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.List<string>));
			obj.HintList = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index HintList on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_changeHintWithTimer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.changeHintWithTimer = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index changeHintWithTimer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hintTimerValue(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.hintTimerValue = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index hintTimerValue on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_imageObject(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.UI.Image arg0 = (UnityEngine.UI.Image)ToLua.CheckObject<UnityEngine.UI.Image>(L, 2);
			obj.imageObject = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index imageObject on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fadingAnimator(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.Animator arg0 = (UnityEngine.Animator)ToLua.CheckObject(L, 2, typeof(UnityEngine.Animator));
			obj.fadingAnimator = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fadingAnimator on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ImageList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			System.Collections.Generic.List<UnityEngine.Sprite> arg0 = (System.Collections.Generic.List<UnityEngine.Sprite>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Sprite>));
			obj.ImageList = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index ImageList on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_changeImageWithTimer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.changeImageWithTimer = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index changeImageWithTimer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_imageTimerValue(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.imageTimerValue = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index imageTimerValue on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_imageFadingSpeed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.imageFadingSpeed = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index imageFadingSpeed on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_objectAnimator(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			UnityEngine.Animator arg0 = (UnityEngine.Animator)ToLua.CheckObject(L, 2, typeof(UnityEngine.Animator));
			obj.objectAnimator = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index objectAnimator on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_virtualLoadingTimer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.virtualLoadingTimer = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index virtualLoadingTimer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enableVirtualLoading(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.enableVirtualLoading = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enableVirtualLoading on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enableTitleDesc(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.enableTitleDesc = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enableTitleDesc on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enableRandomHints(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.enableRandomHints = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enableRandomHints on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enableRandomImages(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.enableRandomImages = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enableRandomImages on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enablePressAnyKey(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.enablePressAnyKey = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enablePressAnyKey on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_titleText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.titleText = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index titleText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_titleDescText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.titleDescText = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index titleDescText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fadingAnimationSpeed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LoadingScreen obj = (LoadingScreen)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.fadingAnimationSpeed = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index fadingAnimationSpeed on a nil value");
		}
	}
}

