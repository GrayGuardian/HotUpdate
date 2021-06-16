﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class GameConstWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameConst), typeof(System.Object));
		L.RegFunction("New", _CreateGameConst);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("PRO_ENV", get_PRO_ENV, set_PRO_ENV);
		L.RegVar("RESOURCES", get_RESOURCES, set_RESOURCES);
		L.RegVar("Asset_ROOT", get_Asset_ROOT, set_Asset_ROOT);
		L.RegVar("BUILD_ROOT", get_BUILD_ROOT, set_BUILD_ROOT);
		L.RegVar("AssetBundles_ROOT", get_AssetBundles_ROOT, set_AssetBundles_ROOT);
		L.RegVar("StreamingAssetsPath", get_StreamingAssetsPath, set_StreamingAssetsPath);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGameConst(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				GameConst obj = new GameConst();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: GameConst.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PRO_ENV(IntPtr L)
	{
		try
		{
			ToLua.Push(L, GameConst.PRO_ENV);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_RESOURCES(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, GameConst.RESOURCES);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Asset_ROOT(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, GameConst.Asset_ROOT);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BUILD_ROOT(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, GameConst.BUILD_ROOT);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetBundles_ROOT(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, GameConst.AssetBundles_ROOT);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StreamingAssetsPath(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, GameConst.StreamingAssetsPath);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_PRO_ENV(IntPtr L)
	{
		try
		{
			ENV_TYPE arg0 = (ENV_TYPE)ToLua.CheckObject(L, 2, typeof(ENV_TYPE));
			GameConst.PRO_ENV = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_RESOURCES(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			GameConst.RESOURCES = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Asset_ROOT(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			GameConst.Asset_ROOT = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_BUILD_ROOT(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			GameConst.BUILD_ROOT = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AssetBundles_ROOT(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			GameConst.AssetBundles_ROOT = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_StreamingAssetsPath(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			GameConst.StreamingAssetsPath = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

