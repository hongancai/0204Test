using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class EscMgr : MonoBehaviour
{
    public enum ESCPanelState
    {
        None,       // 無面板開啟
        Tutorial,   // 教學面板
        Shop,       // 商店面板
        Pause       // 暫停面板
    }
    
    public Teach teachScript;
    public OpenPnl shopScript;
    public PauseMenu pauseScript;
    
    private ESCPanelState currentState = ESCPanelState.None;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            HandleEscKey();
        } 
    }

    private void HandleEscKey()
    {
        switch (currentState)
        {
            case ESCPanelState.Tutorial:
                if (teachScript.teachPnl.activeSelf)
                {
                    teachScript.OnCloseTeachBtn();
                    UpdateState();
                }
                break;

            case ESCPanelState.Shop:
                if (shopScript.IsShopOpen())
                {
                    shopScript.OnBtnClose();
                    UpdateState();
                }
                break;

            case ESCPanelState.Pause:
                if (pauseScript.isShow)
                {
                    pauseScript.TogglePauseMenu();
                    UpdateState();
                }
                break;

            case ESCPanelState.None:
                // 當沒有面板開啟時，開啟暫停選單
                pauseScript.TogglePauseMenu();
                UpdateState();
                break;
        }
    }
    public void UpdateState()
    {
        if (teachScript.teachPnl.activeSelf)
        {
            currentState = ESCPanelState.Tutorial;
        }
        else if (shopScript.IsShopOpen())
        {
            currentState = ESCPanelState.Shop;
        }
        else if (pauseScript.isShow)
        {
            currentState = ESCPanelState.Pause;
        }
        else
        {
            currentState = ESCPanelState.None;
        }
    }

    // 外部腳本呼叫此方法來更新狀態
    public void NotifyPanelStateChanged()
    {
        UpdateState();
    }
}
