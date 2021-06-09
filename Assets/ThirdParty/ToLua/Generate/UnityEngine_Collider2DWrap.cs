﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_Collider2DWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Collider2D), typeof(UnityEngine.Behaviour));
		L.RegFunction("CreateMesh", CreateMesh);
		L.RegFunction("GetShapeHash", GetShapeHash);
		L.RegFunction("IsTouching", IsTouching);
		L.RegFunction("IsTouchingLayers", IsTouchingLayers);
		L.RegFunction("OverlapPoint", OverlapPoint);
		L.RegFunction("Distance", Distance);
		L.RegFunction("OverlapCollider", OverlapCollider);
		L.RegFunction("GetContacts", GetContacts);
		L.RegFunction("Cast", Cast);
		L.RegFunction("Raycast", Raycast);
		L.RegFunction("ClosestPoint", ClosestPoint);
		L.RegFunction("New", _CreateUnityEngine_Collider2D);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("density", get_density, set_density);
		L.RegVar("isTrigger", get_isTrigger, set_isTrigger);
		L.RegVar("usedByEffector", get_usedByEffector, set_usedByEffector);
		L.RegVar("usedByComposite", get_usedByComposite, set_usedByComposite);
		L.RegVar("composite", get_composite, null);
		L.RegVar("offset", get_offset, set_offset);
		L.RegVar("attachedRigidbody", get_attachedRigidbody, null);
		L.RegVar("shapeCount", get_shapeCount, null);
		L.RegVar("bounds", get_bounds, null);
		L.RegVar("sharedMaterial", get_sharedMaterial, set_sharedMaterial);
		L.RegVar("friction", get_friction, null);
		L.RegVar("bounciness", get_bounciness, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Collider2D(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.Collider2D obj = new UnityEngine.Collider2D();
				ToLua.Push(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Collider2D.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateMesh(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
			UnityEngine.Mesh o = obj.CreateMesh(arg0, arg1);
			ToLua.PushSealed(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetShapeHash(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
			uint o = obj.GetShapeHash();
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsTouching(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<UnityEngine.Collider2D>(L, 2))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Collider2D arg0 = (UnityEngine.Collider2D)ToLua.ToObject(L, 2);
				bool o = obj.IsTouching(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<UnityEngine.ContactFilter2D>(L, 2))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.ContactFilter2D arg0 = StackTraits<UnityEngine.ContactFilter2D>.To(L, 2);
				bool o = obj.IsTouching(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 3)
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Collider2D arg0 = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.Check(L, 3);
				bool o = obj.IsTouching(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Collider2D.IsTouching");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsTouchingLayers(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				bool o = obj.IsTouchingLayers();
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 2)
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				bool o = obj.IsTouchingLayers(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Collider2D.IsTouchingLayers");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapPoint(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			bool o = obj.OverlapPoint(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Distance(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
			UnityEngine.Collider2D arg0 = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 2);
			UnityEngine.ColliderDistance2D o = obj.Distance(arg0);
			ToLua.PushValue(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapCollider(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3 && TypeChecker.CheckTypes<UnityEngine.Collider2D[]>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.ContactFilter2D arg0 = StackTraits<UnityEngine.ContactFilter2D>.Check(L, 2);
				UnityEngine.Collider2D[] arg1 = ToLua.ToObjectArray<UnityEngine.Collider2D>(L, 3);
				int o = obj.OverlapCollider(arg0, arg1);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<System.Collections.Generic.List<UnityEngine.Collider2D>>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.ContactFilter2D arg0 = StackTraits<UnityEngine.ContactFilter2D>.Check(L, 2);
				System.Collections.Generic.List<UnityEngine.Collider2D> arg1 = (System.Collections.Generic.List<UnityEngine.Collider2D>)ToLua.ToObject(L, 3);
				int o = obj.OverlapCollider(arg0, arg1);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Collider2D.OverlapCollider");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetContacts(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<UnityEngine.ContactPoint2D[]>(L, 2))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.ContactPoint2D[] arg0 = ToLua.ToStructArray<UnityEngine.ContactPoint2D>(L, 2);
				int o = obj.GetContacts(arg0);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<System.Collections.Generic.List<UnityEngine.ContactPoint2D>>(L, 2))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				System.Collections.Generic.List<UnityEngine.ContactPoint2D> arg0 = (System.Collections.Generic.List<UnityEngine.ContactPoint2D>)ToLua.ToObject(L, 2);
				int o = obj.GetContacts(arg0);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<UnityEngine.Collider2D[]>(L, 2))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Collider2D[] arg0 = ToLua.ToObjectArray<UnityEngine.Collider2D>(L, 2);
				int o = obj.GetContacts(arg0);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<System.Collections.Generic.List<UnityEngine.Collider2D>>(L, 2))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				System.Collections.Generic.List<UnityEngine.Collider2D> arg0 = (System.Collections.Generic.List<UnityEngine.Collider2D>)ToLua.ToObject(L, 2);
				int o = obj.GetContacts(arg0);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<UnityEngine.ContactPoint2D[]>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.ContactFilter2D arg0 = StackTraits<UnityEngine.ContactFilter2D>.Check(L, 2);
				UnityEngine.ContactPoint2D[] arg1 = ToLua.ToStructArray<UnityEngine.ContactPoint2D>(L, 3);
				int o = obj.GetContacts(arg0, arg1);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<System.Collections.Generic.List<UnityEngine.ContactPoint2D>>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.ContactFilter2D arg0 = StackTraits<UnityEngine.ContactFilter2D>.Check(L, 2);
				System.Collections.Generic.List<UnityEngine.ContactPoint2D> arg1 = (System.Collections.Generic.List<UnityEngine.ContactPoint2D>)ToLua.ToObject(L, 3);
				int o = obj.GetContacts(arg0, arg1);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<UnityEngine.Collider2D[]>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.ContactFilter2D arg0 = StackTraits<UnityEngine.ContactFilter2D>.Check(L, 2);
				UnityEngine.Collider2D[] arg1 = ToLua.ToObjectArray<UnityEngine.Collider2D>(L, 3);
				int o = obj.GetContacts(arg0, arg1);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 3 && TypeChecker.CheckTypes<System.Collections.Generic.List<UnityEngine.Collider2D>>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.ContactFilter2D arg0 = StackTraits<UnityEngine.ContactFilter2D>.Check(L, 2);
				System.Collections.Generic.List<UnityEngine.Collider2D> arg1 = (System.Collections.Generic.List<UnityEngine.Collider2D>)ToLua.ToObject(L, 3);
				int o = obj.GetContacts(arg0, arg1);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Collider2D.GetContacts");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Cast(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.RaycastHit2D[] arg1 = ToLua.CheckStructArray<UnityEngine.RaycastHit2D>(L, 3);
				int o = obj.Cast(arg0, arg1);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes<UnityEngine.RaycastHit2D[], float>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.RaycastHit2D[] arg1 = ToLua.ToStructArray<UnityEngine.RaycastHit2D>(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				int o = obj.Cast(arg0, arg1, arg2);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes<UnityEngine.ContactFilter2D, UnityEngine.RaycastHit2D[]>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.To(L, 3);
				UnityEngine.RaycastHit2D[] arg2 = ToLua.ToStructArray<UnityEngine.RaycastHit2D>(L, 4);
				int o = obj.Cast(arg0, arg1, arg2);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes<UnityEngine.ContactFilter2D, System.Collections.Generic.List<UnityEngine.RaycastHit2D>>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.To(L, 3);
				System.Collections.Generic.List<UnityEngine.RaycastHit2D> arg2 = (System.Collections.Generic.List<UnityEngine.RaycastHit2D>)ToLua.ToObject(L, 4);
				int o = obj.Cast(arg0, arg1, arg2);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 5 && TypeChecker.CheckTypes<UnityEngine.RaycastHit2D[], float, bool>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.RaycastHit2D[] arg1 = ToLua.ToStructArray<UnityEngine.RaycastHit2D>(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				bool arg3 = LuaDLL.lua_toboolean(L, 5);
				int o = obj.Cast(arg0, arg1, arg2, arg3);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 5 && TypeChecker.CheckTypes<UnityEngine.ContactFilter2D, UnityEngine.RaycastHit2D[], float>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.To(L, 3);
				UnityEngine.RaycastHit2D[] arg2 = ToLua.ToStructArray<UnityEngine.RaycastHit2D>(L, 4);
				float arg3 = (float)LuaDLL.lua_tonumber(L, 5);
				int o = obj.Cast(arg0, arg1, arg2, arg3);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 5 && TypeChecker.CheckTypes<UnityEngine.ContactFilter2D, System.Collections.Generic.List<UnityEngine.RaycastHit2D>, float>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.To(L, 3);
				System.Collections.Generic.List<UnityEngine.RaycastHit2D> arg2 = (System.Collections.Generic.List<UnityEngine.RaycastHit2D>)ToLua.ToObject(L, 4);
				float arg3 = (float)LuaDLL.lua_tonumber(L, 5);
				int o = obj.Cast(arg0, arg1, arg2, arg3);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 6 && TypeChecker.CheckTypes<UnityEngine.RaycastHit2D[], float, bool>(L, 4))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.Check(L, 3);
				UnityEngine.RaycastHit2D[] arg2 = ToLua.ToStructArray<UnityEngine.RaycastHit2D>(L, 4);
				float arg3 = (float)LuaDLL.lua_tonumber(L, 5);
				bool arg4 = LuaDLL.lua_toboolean(L, 6);
				int o = obj.Cast(arg0, arg1, arg2, arg3, arg4);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 6 && TypeChecker.CheckTypes<System.Collections.Generic.List<UnityEngine.RaycastHit2D>, float, bool>(L, 4))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.Check(L, 3);
				System.Collections.Generic.List<UnityEngine.RaycastHit2D> arg2 = (System.Collections.Generic.List<UnityEngine.RaycastHit2D>)ToLua.ToObject(L, 4);
				float arg3 = (float)LuaDLL.lua_tonumber(L, 5);
				bool arg4 = LuaDLL.lua_toboolean(L, 6);
				int o = obj.Cast(arg0, arg1, arg2, arg3, arg4);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Collider2D.Cast");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Raycast(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.RaycastHit2D[] arg1 = ToLua.CheckStructArray<UnityEngine.RaycastHit2D>(L, 3);
				int o = obj.Raycast(arg0, arg1);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes<UnityEngine.RaycastHit2D[], float>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.RaycastHit2D[] arg1 = ToLua.ToStructArray<UnityEngine.RaycastHit2D>(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				int o = obj.Raycast(arg0, arg1, arg2);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes<UnityEngine.ContactFilter2D, UnityEngine.RaycastHit2D[]>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.To(L, 3);
				UnityEngine.RaycastHit2D[] arg2 = ToLua.ToStructArray<UnityEngine.RaycastHit2D>(L, 4);
				int o = obj.Raycast(arg0, arg1, arg2);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes<UnityEngine.ContactFilter2D, System.Collections.Generic.List<UnityEngine.RaycastHit2D>>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.To(L, 3);
				System.Collections.Generic.List<UnityEngine.RaycastHit2D> arg2 = (System.Collections.Generic.List<UnityEngine.RaycastHit2D>)ToLua.ToObject(L, 4);
				int o = obj.Raycast(arg0, arg1, arg2);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 5 && TypeChecker.CheckTypes<UnityEngine.RaycastHit2D[], float, int>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.RaycastHit2D[] arg1 = ToLua.ToStructArray<UnityEngine.RaycastHit2D>(L, 3);
				float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
				int arg3 = (int)LuaDLL.lua_tonumber(L, 5);
				int o = obj.Raycast(arg0, arg1, arg2, arg3);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 5 && TypeChecker.CheckTypes<UnityEngine.ContactFilter2D, UnityEngine.RaycastHit2D[], float>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.To(L, 3);
				UnityEngine.RaycastHit2D[] arg2 = ToLua.ToStructArray<UnityEngine.RaycastHit2D>(L, 4);
				float arg3 = (float)LuaDLL.lua_tonumber(L, 5);
				int o = obj.Raycast(arg0, arg1, arg2, arg3);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 5 && TypeChecker.CheckTypes<UnityEngine.ContactFilter2D, System.Collections.Generic.List<UnityEngine.RaycastHit2D>, float>(L, 3))
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.ContactFilter2D arg1 = StackTraits<UnityEngine.ContactFilter2D>.To(L, 3);
				System.Collections.Generic.List<UnityEngine.RaycastHit2D> arg2 = (System.Collections.Generic.List<UnityEngine.RaycastHit2D>)ToLua.ToObject(L, 4);
				float arg3 = (float)LuaDLL.lua_tonumber(L, 5);
				int o = obj.Raycast(arg0, arg1, arg2, arg3);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 6)
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.RaycastHit2D[] arg1 = ToLua.CheckStructArray<UnityEngine.RaycastHit2D>(L, 3);
				float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
				int arg3 = (int)LuaDLL.luaL_checknumber(L, 5);
				float arg4 = (float)LuaDLL.luaL_checknumber(L, 6);
				int o = obj.Raycast(arg0, arg1, arg2, arg3, arg4);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 7)
			{
				UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
				UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
				UnityEngine.RaycastHit2D[] arg1 = ToLua.CheckStructArray<UnityEngine.RaycastHit2D>(L, 3);
				float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
				int arg3 = (int)LuaDLL.luaL_checknumber(L, 5);
				float arg4 = (float)LuaDLL.luaL_checknumber(L, 6);
				float arg5 = (float)LuaDLL.luaL_checknumber(L, 7);
				int o = obj.Raycast(arg0, arg1, arg2, arg3, arg4, arg5);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Collider2D.Raycast");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClosestPoint(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)ToLua.CheckObject<UnityEngine.Collider2D>(L, 1);
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			UnityEngine.Vector2 o = obj.ClosestPoint(arg0);
			ToLua.Push(L, o);
			return 1;
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
	static int get_density(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			float ret = obj.density;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index density on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isTrigger(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			bool ret = obj.isTrigger;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isTrigger on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_usedByEffector(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			bool ret = obj.usedByEffector;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index usedByEffector on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_usedByComposite(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			bool ret = obj.usedByComposite;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index usedByComposite on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_composite(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			UnityEngine.CompositeCollider2D ret = obj.composite;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index composite on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_offset(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			UnityEngine.Vector2 ret = obj.offset;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index offset on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_attachedRigidbody(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			UnityEngine.Rigidbody2D ret = obj.attachedRigidbody;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index attachedRigidbody on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shapeCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			int ret = obj.shapeCount;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index shapeCount on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounds(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			UnityEngine.Bounds ret = obj.bounds;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index bounds on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sharedMaterial(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			UnityEngine.PhysicsMaterial2D ret = obj.sharedMaterial;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sharedMaterial on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_friction(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			float ret = obj.friction;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index friction on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounciness(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			float ret = obj.bounciness;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index bounciness on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_density(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.density = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index density on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isTrigger(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.isTrigger = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isTrigger on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_usedByEffector(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.usedByEffector = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index usedByEffector on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_usedByComposite(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.usedByComposite = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index usedByComposite on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_offset(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			obj.offset = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index offset on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sharedMaterial(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.Collider2D obj = (UnityEngine.Collider2D)o;
			UnityEngine.PhysicsMaterial2D arg0 = (UnityEngine.PhysicsMaterial2D)ToLua.CheckObject(L, 2, typeof(UnityEngine.PhysicsMaterial2D));
			obj.sharedMaterial = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index sharedMaterial on a nil value");
		}
	}
}

