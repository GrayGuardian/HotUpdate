//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Singleton_MonoUtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Singleton<MonoUtil>), typeof(System.Object), "Singleton_MonoUtil");
		L.RegFunction("New", _CreateSingleton_MonoUtil);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("Instance", get_Instance, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSingleton_MonoUtil(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Singleton<MonoUtil> obj = new Singleton<MonoUtil>();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Singleton<MonoUtil>.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, Singleton<MonoUtil>.Instance);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

