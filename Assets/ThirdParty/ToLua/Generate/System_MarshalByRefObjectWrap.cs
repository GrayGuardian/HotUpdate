﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class System_MarshalByRefObjectWrap
{
    public static void Register(LuaState L)
    {
        L.BeginClass(typeof(System.MarshalByRefObject), typeof(System.Object));
        // L.RegFunction("CreateObjRef", CreateObjRef);
        L.RegFunction("GetLifetimeService", GetLifetimeService);
        L.RegFunction("InitializeLifetimeService", InitializeLifetimeService);
        L.RegFunction("__tostring", ToLua.op_ToString);
        L.EndClass();
    }

    // [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    // static int CreateObjRef(IntPtr L)
    // {
    // 	try
    // 	{
    // 		ToLua.CheckArgsCount(L, 2);
    // 		System.MarshalByRefObject obj = (System.MarshalByRefObject)ToLua.CheckObject<System.MarshalByRefObject>(L, 1);
    // 		System.Type arg0 = ToLua.CheckMonoType(L, 2);
    // 		System.Runtime.Remoting.ObjRef o = obj.CreateObjRef(arg0);
    // 		ToLua.PushObject(L, o);
    // 		return 1;
    // 	}
    // 	catch (Exception e)
    // 	{
    // 		return LuaDLL.toluaL_exception(L, e);
    // 	}
    // }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int GetLifetimeService(IntPtr L)
    {
        try
        {
            ToLua.CheckArgsCount(L, 1);
            System.MarshalByRefObject obj = (System.MarshalByRefObject)ToLua.CheckObject<System.MarshalByRefObject>(L, 1);
            object o = obj.GetLifetimeService();
            ToLua.Push(L, o);
            return 1;
        }
        catch (Exception e)
        {
            return LuaDLL.toluaL_exception(L, e);
        }
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int InitializeLifetimeService(IntPtr L)
    {
        try
        {
            ToLua.CheckArgsCount(L, 1);
            System.MarshalByRefObject obj = (System.MarshalByRefObject)ToLua.CheckObject<System.MarshalByRefObject>(L, 1);
            object o = obj.InitializeLifetimeService();
            ToLua.Push(L, o);
            return 1;
        }
        catch (Exception e)
        {
            return LuaDLL.toluaL_exception(L, e);
        }
    }
}

