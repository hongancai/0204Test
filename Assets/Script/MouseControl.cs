using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControl : MonoBehaviour
{
    private InputMaster _inputMaster;
    public float sensitivity = 2f;
    
    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);
    private void Start()
    {
        _inputMaster = new InputMaster();
        _inputMaster.Enable();
    }

    private void Update()
    {
        Vector2 mouseVector = _inputMaster.Mouse.Control.ReadValue<Vector2>();
        
        // 處理滑鼠移動
        if (mouseVector != Vector2.zero)
        {
            Vector2 mouseDelta = mouseVector * sensitivity;
            //Cursor.position += new Vector3(mouseDelta.x, -mouseDelta.y, 0);
        }
    }

    
}
