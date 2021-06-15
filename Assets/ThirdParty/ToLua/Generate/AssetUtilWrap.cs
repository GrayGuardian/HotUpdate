﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class AssetUtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AssetUtil), typeof(System.Object));
		L.RegFunction("getAssetFileBytes", getAssetFileBytes);
		L.RegFunction("getRelyBundleKeys", getRelyBundleKeys);
		L.RegFunction("DecryptBundleBytes", DecryptBundleBytes);
		L.RegFunction("DecryptBundleBytesAsync", DecryptBundleBytesAsync);
		L.RegFunction("LoadBundle", LoadBundle);
		L.RegFunction("LoadBundleAsync", LoadBundleAsync);
		L.RegFunction("UnloadBundle", UnloadBundle);
		L.RegFunction("LoadAssetFromBundle", LoadAssetFromBundle);
		L.RegFunction("LoadAssetFromBundleAsync", LoadAssetFromBundleAsync);
		L.RegFunction("LoadAssetFromEditorBundle", LoadAssetFromEditorBundle);
		L.RegFunction("LoadAssetFromEditorBundleAsync", LoadAssetFromEditorBundleAsync);
		L.RegFunction("LoadAssetFromResources", LoadAssetFromResources);
		L.RegFunction("LoadAssetFromResourcesAsync", LoadAssetFromResourcesAsync);
		L.RegFunction("LoadAsset", LoadAsset);
		L.RegFunction("LoadAssetAsync", LoadAssetAsync);
		L.RegFunction("New", _CreateAssetUtil);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAssetUtil(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				AssetUtil obj = new AssetUtil();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: AssetUtil.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAssetFileBytes(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			byte[] o = obj.getAssetFileBytes(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getRelyBundleKeys(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			string[] o = obj.getRelyBundleKeys(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DecryptBundleBytes(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			byte[] o = obj.DecryptBundleBytes(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DecryptBundleBytesAsync(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			System.Action<byte[]> arg1 = (System.Action<byte[]>)ToLua.CheckDelegate<System.Action<byte[]>>(L, 3);
			bool o = obj.DecryptBundleBytesAsync(arg0, arg1);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadBundle(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			UnityEngine.AssetBundle o = obj.LoadBundle(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadBundleAsync(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				obj.LoadBundleAsync(arg0);
				return 0;
			}
			else if (count == 3)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				System.Action<UnityEngine.AssetBundle> arg1 = (System.Action<UnityEngine.AssetBundle>)ToLua.CheckDelegate<System.Action<UnityEngine.AssetBundle>>(L, 3);
				obj.LoadBundleAsync(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: AssetUtil.LoadBundleAsync");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnloadBundle(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				obj.UnloadBundle(arg0);
				return 0;
			}
			else if (count == 3)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				obj.UnloadBundle(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: AssetUtil.UnloadBundle");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetFromBundle(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 4)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				System.Type arg0 = ToLua.CheckMonoType(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				string arg2 = ToLua.CheckString(L, 4);
				UnityEngine.Object o = obj.LoadAssetFromBundle(arg0, arg1, arg2);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 5)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				System.Type arg0 = ToLua.CheckMonoType(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				string arg2 = ToLua.CheckString(L, 4);
				bool arg3 = LuaDLL.luaL_checkboolean(L, 5);
				UnityEngine.Object o = obj.LoadAssetFromBundle(arg0, arg1, arg2, arg3);
				ToLua.Push(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: AssetUtil.LoadAssetFromBundle");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetFromBundleAsync(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 5)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				System.Type arg0 = ToLua.CheckMonoType(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				string arg2 = ToLua.CheckString(L, 4);
				System.Action<UnityEngine.Object> arg3 = (System.Action<UnityEngine.Object>)ToLua.CheckDelegate<System.Action<UnityEngine.Object>>(L, 5);
				obj.LoadAssetFromBundleAsync(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 6)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				System.Type arg0 = ToLua.CheckMonoType(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				string arg2 = ToLua.CheckString(L, 4);
				System.Action<UnityEngine.Object> arg3 = (System.Action<UnityEngine.Object>)ToLua.CheckDelegate<System.Action<UnityEngine.Object>>(L, 5);
				bool arg4 = LuaDLL.luaL_checkboolean(L, 6);
				obj.LoadAssetFromBundleAsync(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: AssetUtil.LoadAssetFromBundleAsync");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetFromEditorBundle(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
			System.Type arg0 = ToLua.CheckMonoType(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			string arg2 = ToLua.CheckString(L, 4);
			UnityEngine.Object o = obj.LoadAssetFromEditorBundle(arg0, arg1, arg2);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetFromEditorBundleAsync(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
			System.Type arg0 = ToLua.CheckMonoType(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			string arg2 = ToLua.CheckString(L, 4);
			System.Action<UnityEngine.Object> arg3 = (System.Action<UnityEngine.Object>)ToLua.CheckDelegate<System.Action<UnityEngine.Object>>(L, 5);
			obj.LoadAssetFromEditorBundleAsync(arg0, arg1, arg2, arg3);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetFromResources(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
			System.Type arg0 = ToLua.CheckMonoType(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			string arg2 = ToLua.CheckString(L, 4);
			UnityEngine.Object o = obj.LoadAssetFromResources(arg0, arg1, arg2);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetFromResourcesAsync(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
			System.Type arg0 = ToLua.CheckMonoType(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			string arg2 = ToLua.CheckString(L, 4);
			System.Action<UnityEngine.Object> arg3 = (System.Action<UnityEngine.Object>)ToLua.CheckDelegate<System.Action<UnityEngine.Object>>(L, 5);
			obj.LoadAssetFromResourcesAsync(arg0, arg1, arg2, arg3);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAsset(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 4)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				System.Type arg0 = ToLua.CheckMonoType(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				string arg2 = ToLua.CheckString(L, 4);
				UnityEngine.Object o = obj.LoadAsset(arg0, arg1, arg2);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 5)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				System.Type arg0 = ToLua.CheckMonoType(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				string arg2 = ToLua.CheckString(L, 4);
				bool arg3 = LuaDLL.luaL_checkboolean(L, 5);
				UnityEngine.Object o = obj.LoadAsset(arg0, arg1, arg2, arg3);
				ToLua.Push(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: AssetUtil.LoadAsset");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetAsync(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 5)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				System.Type arg0 = ToLua.CheckMonoType(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				string arg2 = ToLua.CheckString(L, 4);
				System.Action<UnityEngine.Object> arg3 = (System.Action<UnityEngine.Object>)ToLua.CheckDelegate<System.Action<UnityEngine.Object>>(L, 5);
				obj.LoadAssetAsync(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 6)
			{
				AssetUtil obj = (AssetUtil)ToLua.CheckObject<AssetUtil>(L, 1);
				System.Type arg0 = ToLua.CheckMonoType(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				string arg2 = ToLua.CheckString(L, 4);
				System.Action<UnityEngine.Object> arg3 = (System.Action<UnityEngine.Object>)ToLua.CheckDelegate<System.Action<UnityEngine.Object>>(L, 5);
				bool arg4 = LuaDLL.luaL_checkboolean(L, 6);
				obj.LoadAssetAsync(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: AssetUtil.LoadAssetAsync");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

