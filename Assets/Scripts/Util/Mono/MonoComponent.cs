using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MonoComponent : MonoBehaviour
{
    /// <summary>
    /// 绑定的Lua脚本名
    /// </summary>
    public string LuaName = "";
    private event Action<string, object[]> _onListenEvent = null;
    public void AddListenEvent(Action<string, object[]> e)
    {
        _onListenEvent += e;
    }
    public void DelListenEvent(Action<string, object[]> e)
    {
        _onListenEvent -= e;
    }
    protected void Awake()
    {
        if (_onListenEvent != null) _onListenEvent("Awake", null);
    }
    protected void Start()
    {
        if (_onListenEvent != null) _onListenEvent("Start", null);
    }
    protected void OnEnable()
    {
        if (_onListenEvent != null) _onListenEvent("OnEnable", null);
    }
    protected void OnDisable()
    {
        if (_onListenEvent != null) _onListenEvent("OnDisable", null);
    }
    protected void OnDestroy()
    {
        if (_onListenEvent != null) _onListenEvent("OnDestroy", null);
    }
    protected void Update()
    {
        if (_onListenEvent != null) _onListenEvent("Update", null);
    }
    protected void FixedUpdate()
    {
        if (_onListenEvent != null) _onListenEvent("FixedUpdate", null);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_onListenEvent != null) _onListenEvent("OnTriggerEnter", new object[] { other });
    }
    private void OnTriggerStay(Collider other)
    {
        if (_onListenEvent != null) _onListenEvent("OnTriggerStay", new object[] { other });
    }
    private void OnTriggerExit(Collider other)
    {
        if (_onListenEvent != null) _onListenEvent("OnTriggerExit", new object[] { other });
    }
    private void OnCollisionEnter(Collision other)
    {
        if (_onListenEvent != null) _onListenEvent("OnCollisionEnter", new object[] { other });
    }
    private void OnCollisionStay(Collision other)
    {
        if (_onListenEvent != null) _onListenEvent("OnCollisionStay", new object[] { other });
    }
    private void OnCollisionExit(Collision other)
    {
        if (_onListenEvent != null) _onListenEvent("OnCollisionExit", new object[] { other });
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_onListenEvent != null) _onListenEvent("OnTriggerEnter2D", new object[] { other });
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (_onListenEvent != null) _onListenEvent("OnTriggerStay2D", new object[] { other });
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (_onListenEvent != null) _onListenEvent("OnTriggerExit2D", new object[] { other });
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_onListenEvent != null) _onListenEvent("OnCollisionEnter2D", new object[] { other });
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (_onListenEvent != null) _onListenEvent("OnCollisionStay2D", new object[] { other });
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (_onListenEvent != null) _onListenEvent("OnCollisionExit2D", new object[] { other });
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        if (_onListenEvent != null) _onListenEvent("OnPause", new object[] { pauseStatus });
    }
    private void OnApplicationFocus(bool focusStatus)
    {
        if (_onListenEvent != null) _onListenEvent("OnFocus", new object[] { focusStatus });
    }
}
