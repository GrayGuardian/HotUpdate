//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class EncryptUtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(EncryptUtil), typeof(Singleton<EncryptUtil>));
		L.RegFunction("ReadBytes", ReadBytes);
		L.RegFunction("ReadBytesAsync", ReadBytesAsync);
		L.RegFunction("ReadString", ReadString);
		L.RegFunction("ReadStringAsync", ReadStringAsync);
		L.RegFunction("WriteBytes", WriteBytes);
		L.RegFunction("WriteBytesAsync", WriteBytesAsync);
		L.RegFunction("WriteString", WriteString);
		L.RegFunction("WriteStringAsync", WriteStringAsync);
		L.RegFunction("AesEncrypt", AesEncrypt);
		L.RegFunction("AesDecrypt", AesDecrypt);
		L.RegFunction("AesEncryptAsync", AesEncryptAsync);
		L.RegFunction("AesDecryptAsync", AesDecryptAsync);
		L.RegFunction("New", _CreateEncryptUtil);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateEncryptUtil(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				EncryptUtil obj = new EncryptUtil();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: EncryptUtil.New");
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
			EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
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
	static int ReadBytesAsync(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			System.Action<byte[]> arg1 = (System.Action<byte[]>)ToLua.CheckDelegate<System.Action<byte[]>>(L, 3);
			obj.ReadBytesAsync(arg0, arg1);
			return 0;
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
			ToLua.CheckArgsCount(L, 2);
			EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string o = obj.ReadString(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadStringAsync(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			System.Action<string> arg1 = (System.Action<string>)ToLua.CheckDelegate<System.Action<string>>(L, 3);
			obj.ReadStringAsync(arg0, arg1);
			return 0;
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
			EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
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
	static int WriteBytesAsync(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
				obj.WriteBytesAsync(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				byte[] arg1 = ToLua.CheckByteBuffer(L, 3);
				System.Action arg2 = (System.Action)ToLua.CheckDelegate<System.Action>(L, 4);
				obj.WriteBytesAsync(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: EncryptUtil.WriteBytesAsync");
			}
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
			ToLua.CheckArgsCount(L, 3);
			EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			obj.WriteString(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteStringAsync(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				obj.WriteStringAsync(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				System.Action arg2 = (System.Action)ToLua.CheckDelegate<System.Action>(L, 4);
				obj.WriteStringAsync(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: EncryptUtil.WriteStringAsync");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AesEncrypt(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<byte[]>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
				byte[] o = obj.AesEncrypt(arg0);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				string o = obj.AesEncrypt(arg0);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<byte[], string>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
				string arg1 = ToLua.ToString(L, 3);
				byte[] o = obj.AesEncrypt(arg0, arg1);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, string>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				string arg1 = ToLua.ToString(L, 3);
				string o = obj.AesEncrypt(arg0, arg1);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: EncryptUtil.AesEncrypt");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AesDecrypt(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<byte[]>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
				byte[] o = obj.AesDecrypt(arg0);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				string o = obj.AesDecrypt(arg0);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<byte[], string>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
				string arg1 = ToLua.ToString(L, 3);
				byte[] o = obj.AesDecrypt(arg0, arg1);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, string>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				string arg1 = ToLua.ToString(L, 3);
				string o = obj.AesDecrypt(arg0, arg1);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: EncryptUtil.AesDecrypt");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AesEncryptAsync(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3 && TypeChecker.CheckTypes<byte[], System.Action<byte[]>>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
				System.Action<byte[]> arg1 = (System.Action<byte[]>)ToLua.ToObject(L, 3);
				obj.AesEncryptAsync(arg0, arg1);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, System.Action<string>>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				System.Action<string> arg1 = (System.Action<string>)ToLua.ToObject(L, 3);
				obj.AesEncryptAsync(arg0, arg1);
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes<byte[], System.Action<byte[]>, string>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
				System.Action<byte[]> arg1 = (System.Action<byte[]>)ToLua.ToObject(L, 3);
				string arg2 = ToLua.ToString(L, 4);
				obj.AesEncryptAsync(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes<string, System.Action<string>, string>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				System.Action<string> arg1 = (System.Action<string>)ToLua.ToObject(L, 3);
				string arg2 = ToLua.ToString(L, 4);
				obj.AesEncryptAsync(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: EncryptUtil.AesEncryptAsync");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AesDecryptAsync(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3 && TypeChecker.CheckTypes<byte[], System.Action<byte[]>>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
				System.Action<byte[]> arg1 = (System.Action<byte[]>)ToLua.ToObject(L, 3);
				obj.AesDecryptAsync(arg0, arg1);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, System.Action<string>>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				System.Action<string> arg1 = (System.Action<string>)ToLua.ToObject(L, 3);
				obj.AesDecryptAsync(arg0, arg1);
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes<byte[], System.Action<byte[]>, string>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				byte[] arg0 = ToLua.CheckByteBuffer(L, 2);
				System.Action<byte[]> arg1 = (System.Action<byte[]>)ToLua.ToObject(L, 3);
				string arg2 = ToLua.ToString(L, 4);
				obj.AesDecryptAsync(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes<string, System.Action<string>, string>(L, 2))
			{
				EncryptUtil obj = (EncryptUtil)ToLua.CheckObject<EncryptUtil>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				System.Action<string> arg1 = (System.Action<string>)ToLua.ToObject(L, 3);
				string arg2 = ToLua.ToString(L, 4);
				obj.AesDecryptAsync(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: EncryptUtil.AesDecryptAsync");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

