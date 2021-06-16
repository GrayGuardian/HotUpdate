﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class HttpUtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(HttpUtil), typeof(System.Object));
		L.RegFunction("Get", Get);
		L.RegFunction("Get_Asyn", Get_Asyn);
		L.RegFunction("Post", Post);
		L.RegFunction("Post_Asyn", Post_Asyn);
		L.RegFunction("GetDownloadSize", GetDownloadSize);
		L.RegFunction("GetDownloadSizeAsyn", GetDownloadSizeAsyn);
		L.RegFunction("Download", Download);
		L.RegFunction("_threadDownload", _threadDownload);
		L.RegFunction("New", _CreateHttpUtil);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateHttpUtil(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				HttpUtil obj = new HttpUtil();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: HttpUtil.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Get(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				HttpResult o = obj.Get(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 3)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				System.Action<System.Exception> arg1 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 3);
				HttpResult o = obj.Get(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 4)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				System.Action<System.Exception> arg1 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 3);
				System.Text.Encoding arg2 = (System.Text.Encoding)ToLua.CheckObject<System.Text.Encoding>(L, 4);
				HttpResult o = obj.Get(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: HttpUtil.Get");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Get_Asyn(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				obj.Get_Asyn(arg0);
				return 0;
			}
			else if (count == 3)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				System.Action<HttpResult> arg1 = (System.Action<HttpResult>)ToLua.CheckDelegate<System.Action<HttpResult>>(L, 3);
				obj.Get_Asyn(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				System.Action<HttpResult> arg1 = (System.Action<HttpResult>)ToLua.CheckDelegate<System.Action<HttpResult>>(L, 3);
				System.Action<System.Exception> arg2 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 4);
				obj.Get_Asyn(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				System.Action<HttpResult> arg1 = (System.Action<HttpResult>)ToLua.CheckDelegate<System.Action<HttpResult>>(L, 3);
				System.Action<System.Exception> arg2 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 4);
				System.Text.Encoding arg3 = (System.Text.Encoding)ToLua.CheckObject<System.Text.Encoding>(L, 5);
				obj.Get_Asyn(arg0, arg1, arg2, arg3);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: HttpUtil.Get_Asyn");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Post(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
				HttpResult o = obj.Post(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 4)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
				System.Action<System.Exception> arg2 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 4);
				HttpResult o = obj.Post(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 5)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
				System.Action<System.Exception> arg2 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 4);
				System.Text.Encoding arg3 = (System.Text.Encoding)ToLua.CheckObject<System.Text.Encoding>(L, 5);
				HttpResult o = obj.Post(arg0, arg1, arg2, arg3);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: HttpUtil.Post");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Post_Asyn(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
				obj.Post_Asyn(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
				System.Action<HttpResult> arg2 = (System.Action<HttpResult>)ToLua.CheckDelegate<System.Action<HttpResult>>(L, 4);
				obj.Post_Asyn(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
				System.Action<HttpResult> arg2 = (System.Action<HttpResult>)ToLua.CheckDelegate<System.Action<HttpResult>>(L, 4);
				System.Action<System.Exception> arg3 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 5);
				obj.Post_Asyn(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 6)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				System.Net.HttpWebRequest arg0 = (System.Net.HttpWebRequest)ToLua.CheckObject<System.Net.HttpWebRequest>(L, 2);
				byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
				System.Action<HttpResult> arg2 = (System.Action<HttpResult>)ToLua.CheckDelegate<System.Action<HttpResult>>(L, 4);
				System.Action<System.Exception> arg3 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 5);
				System.Text.Encoding arg4 = (System.Text.Encoding)ToLua.CheckObject<System.Text.Encoding>(L, 6);
				obj.Post_Asyn(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: HttpUtil.Post_Asyn");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDownloadSize(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				long o = obj.GetDownloadSize(arg0);
				LuaDLL.tolua_pushint64(L, o);
				return 1;
			}
			else if (count == 3)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				System.Action<System.Exception> arg1 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 3);
				long o = obj.GetDownloadSize(arg0, arg1);
				LuaDLL.tolua_pushint64(L, o);
				return 1;
			}
			else if (count == 4)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				System.Action<System.Exception> arg1 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 3);
				int arg2 = (int)LuaDLL.luaL_checknumber(L, 4);
				long o = obj.GetDownloadSize(arg0, arg1, arg2);
				LuaDLL.tolua_pushint64(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: HttpUtil.GetDownloadSize");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDownloadSizeAsyn(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				System.Action<long> arg1 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 3);
				obj.GetDownloadSizeAsyn(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				System.Action<long> arg1 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 3);
				System.Action<System.Exception> arg2 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 4);
				obj.GetDownloadSizeAsyn(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				System.Action<long> arg1 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 3);
				System.Action<System.Exception> arg2 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 4);
				int arg3 = (int)LuaDLL.luaL_checknumber(L, 5);
				obj.GetDownloadSizeAsyn(arg0, arg1, arg2, arg3);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: HttpUtil.GetDownloadSizeAsyn");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Download(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				obj.Download(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				obj.Download(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				obj.Download(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 6)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				System.Action<System.Exception> arg4 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 6);
				obj.Download(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else if (count == 7)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				System.Action<System.Exception> arg4 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 6);
				long arg5 = LuaDLL.tolua_checkint64(L, 7);
				obj.Download(arg0, arg1, arg2, arg3, arg4, arg5);
				return 0;
			}
			else if (count == 8)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				System.Action<System.Exception> arg4 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 6);
				long arg5 = LuaDLL.tolua_checkint64(L, 7);
				long arg6 = LuaDLL.tolua_checkint64(L, 8);
				obj.Download(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
				return 0;
			}
			else if (count == 9)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				System.Action<System.Exception> arg4 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 6);
				long arg5 = LuaDLL.tolua_checkint64(L, 7);
				long arg6 = LuaDLL.tolua_checkint64(L, 8);
				int arg7 = (int)LuaDLL.luaL_checknumber(L, 9);
				obj.Download(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
				return 0;
			}
			else if (count == 10)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				System.Action<System.Exception> arg4 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 6);
				long arg5 = LuaDLL.tolua_checkint64(L, 7);
				long arg6 = LuaDLL.tolua_checkint64(L, 8);
				int arg7 = (int)LuaDLL.luaL_checknumber(L, 9);
				int arg8 = (int)LuaDLL.luaL_checknumber(L, 10);
				obj.Download(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: HttpUtil.Download");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _threadDownload(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				obj._threadDownload(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				obj._threadDownload(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				obj._threadDownload(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 6)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				System.Action<System.Exception> arg4 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 6);
				obj._threadDownload(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else if (count == 7)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				System.Action<System.Exception> arg4 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 6);
				long arg5 = LuaDLL.tolua_checkint64(L, 7);
				obj._threadDownload(arg0, arg1, arg2, arg3, arg4, arg5);
				return 0;
			}
			else if (count == 8)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				System.Action<System.Exception> arg4 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 6);
				long arg5 = LuaDLL.tolua_checkint64(L, 7);
				long arg6 = LuaDLL.tolua_checkint64(L, 8);
				obj._threadDownload(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
				return 0;
			}
			else if (count == 9)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				System.Action<System.Exception> arg4 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 6);
				long arg5 = LuaDLL.tolua_checkint64(L, 7);
				long arg6 = LuaDLL.tolua_checkint64(L, 8);
				int arg7 = (int)LuaDLL.luaL_checknumber(L, 9);
				obj._threadDownload(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
				return 0;
			}
			else if (count == 10)
			{
				HttpUtil obj = (HttpUtil)ToLua.CheckObject<HttpUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action<long> arg2 = (System.Action<long>)ToLua.CheckDelegate<System.Action<long>>(L, 4);
				System.Action<long,long,long> arg3 = (System.Action<long,long,long>)ToLua.CheckDelegate<System.Action<long,long,long>>(L, 5);
				System.Action<System.Exception> arg4 = (System.Action<System.Exception>)ToLua.CheckDelegate<System.Action<System.Exception>>(L, 6);
				long arg5 = LuaDLL.tolua_checkint64(L, 7);
				long arg6 = LuaDLL.tolua_checkint64(L, 8);
				int arg7 = (int)LuaDLL.luaL_checknumber(L, 9);
				int arg8 = (int)LuaDLL.luaL_checknumber(L, 10);
				obj._threadDownload(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: HttpUtil._threadDownload");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

