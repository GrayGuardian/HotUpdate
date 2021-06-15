﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class FileUtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FileUtil), typeof(System.Object));
		L.RegFunction("ReadBytes", ReadBytes);
		L.RegFunction("ReadString", ReadString);
		L.RegFunction("WriteBytes", WriteBytes);
		L.RegFunction("WriteString", WriteString);
		L.RegFunction("GetChildFiles", GetChildFiles);
		L.RegFunction("GetChildFile", GetChildFile);
		L.RegFunction("ComputeHash", ComputeHash);
		L.RegFunction("MoveTo", MoveTo);
		L.RegFunction("CopyTo", CopyTo);
		L.RegFunction("CreateDirectory", CreateDirectory);
		L.RegFunction("New", _CreateFileUtil);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateFileUtil(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				FileUtil obj = new FileUtil();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: FileUtil.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadBytes(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			byte[] o = obj.ReadBytes(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadString(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string o = obj.ReadString(arg0);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else if (count == 3)
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				System.Text.Encoding arg1 = (System.Text.Encoding)ToLua.CheckObject<System.Text.Encoding>(L, 3);
				string o = obj.ReadString(arg0, arg1);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FileUtil.ReadString");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteBytes(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
			obj.WriteBytes(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteString(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				obj.WriteString(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Text.Encoding arg2 = (System.Text.Encoding)ToLua.CheckObject<System.Text.Encoding>(L, 4);
				obj.WriteString(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FileUtil.WriteString");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetChildFiles(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				System.IO.FileInfo[] o = obj.GetChildFiles(arg0);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 3)
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.IO.FileInfo[] o = obj.GetChildFiles(arg0, arg1);
				ToLua.Push(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FileUtil.GetChildFiles");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetChildFile(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			System.IO.FileInfo o = obj.GetChildFile(arg0, arg1);
			ToLua.PushSealed(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ComputeHash(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<byte[]>(L, 2))
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
				string o = obj.ComputeHash(arg0);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string>(L, 2))
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				string o = obj.ComputeHash(arg0);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FileUtil.ComputeHash");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveTo(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				bool o = obj.MoveTo(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 4)
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				bool arg2 = LuaDLL.luaL_checkboolean(L, 4);
				bool o = obj.MoveTo(arg0, arg1, arg2);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FileUtil.MoveTo");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyTo(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				bool o = obj.CopyTo(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 4)
			{
				FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				bool arg2 = LuaDLL.luaL_checkboolean(L, 4);
				bool o = obj.CopyTo(arg0, arg1, arg2);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FileUtil.CopyTo");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateDirectory(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FileUtil obj = (FileUtil)ToLua.CheckObject<FileUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.CreateDirectory(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

