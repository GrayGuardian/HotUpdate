﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class System_ExceptionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(System.Exception), typeof(System.Object));
		L.RegFunction("GetBaseException", GetBaseException);
		L.RegFunction("ToString", ToString);
		L.RegFunction("GetObjectData", GetObjectData);
		L.RegFunction("GetType", GetType);
		L.RegFunction("New", _CreateSystem_Exception);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("Message", get_Message, null);
		L.RegVar("Data", get_Data, null);
		L.RegVar("InnerException", get_InnerException, null);
		L.RegVar("TargetSite", get_TargetSite, null);
		L.RegVar("StackTrace", get_StackTrace, null);
		L.RegVar("HelpLink", get_HelpLink, set_HelpLink);
		L.RegVar("Source", get_Source, set_Source);
		L.RegVar("HResult", get_HResult, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSystem_Exception(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				System.Exception obj = new System.Exception();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 1)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Exception obj = new System.Exception(arg0);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 2)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Exception arg1 = (System.Exception)ToLua.CheckObject<System.Exception>(L, 2);
				System.Exception obj = new System.Exception(arg0, arg1);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Exception.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBaseException(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			System.Exception obj = (System.Exception)ToLua.CheckObject<System.Exception>(L, 1);
			System.Exception o = obj.GetBaseException();
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			System.Exception obj = (System.Exception)ToLua.CheckObject<System.Exception>(L, 1);
			string o = obj.ToString();
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetObjectData(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			System.Exception obj = (System.Exception)ToLua.CheckObject<System.Exception>(L, 1);
			System.Runtime.Serialization.SerializationInfo arg0 = (System.Runtime.Serialization.SerializationInfo)ToLua.CheckObject(L, 2, typeof(System.Runtime.Serialization.SerializationInfo));
			System.Runtime.Serialization.StreamingContext arg1 = StackTraits<System.Runtime.Serialization.StreamingContext>.Check(L, 3);
			obj.GetObjectData(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			System.Exception obj = (System.Exception)ToLua.CheckObject<System.Exception>(L, 1);
			System.Type o = obj.GetType();
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Message(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			System.Exception obj = (System.Exception)o;
			string ret = obj.Message;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Message on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Data(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			System.Exception obj = (System.Exception)o;
			System.Collections.IDictionary ret = obj.Data;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Data on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InnerException(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			System.Exception obj = (System.Exception)o;
			System.Exception ret = obj.InnerException;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InnerException on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TargetSite(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			System.Exception obj = (System.Exception)o;
			System.Reflection.MethodBase ret = obj.TargetSite;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index TargetSite on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StackTrace(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			System.Exception obj = (System.Exception)o;
			string ret = obj.StackTrace;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index StackTrace on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HelpLink(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			System.Exception obj = (System.Exception)o;
			string ret = obj.HelpLink;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index HelpLink on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Source(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			System.Exception obj = (System.Exception)o;
			string ret = obj.Source;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Source on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HResult(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			System.Exception obj = (System.Exception)o;
			int ret = obj.HResult;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index HResult on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_HelpLink(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			System.Exception obj = (System.Exception)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.HelpLink = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index HelpLink on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Source(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			System.Exception obj = (System.Exception)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.Source = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Source on a nil value");
		}
	}
}

