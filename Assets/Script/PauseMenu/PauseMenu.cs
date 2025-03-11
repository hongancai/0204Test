using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private InputMaster inputMaster;
    public bool isShow;
    public GameObject pausemenu;

    private void OnEnable()
    {
        inputMaster = new InputMaster();
        inputMaster.Enable();

        // 綁定 PauseMenu 鍵 - 這裡我們將呼叫 EscMgr 的方法，而不是直接處理
        //inputMaster.Menu.PauseMenu.performed += context => EscMgr.Instance.HandleEscKey();
    }

    private void OnDisable()
    {
        // 取消綁定 PauseMenu 鍵
        inputMaster.Menu.PauseMenu.performed -= context => EscMgr.Instance.HandleEscKey();
        inputMaster.Disable();
    }

    void Start()
    {
        pausemenu.SetActive(false);
        isShow = false;
        
        // 確保在遊戲開始時，遊戲暫停狀態為 false
        GameDB.isGamepause = false;
    }
    
    // 這個方法將由 EscMgr 調用
    public void OpenPauseMenu()
    {
        isShow = true;
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        GameDB.isGamepause = true;
    }
    
    // 這個方法將由 EscMgr 調用
    public void ClosePauseMenu()
    {
        isShow = false;
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        GameDB.isGamepause = false;
    }
    
    // 舊的切換方法，保留供按鈕使用，但內部調用 EscMgr
    public void TogglePauseMenu()
    {
        if (isShow)
        {
            EscMgr.Instance.ClosePausePanel();
        }
        else
        {
            // 只有當沒有其他面板開啟時，才能開啟暫停選單
            if (EscMgr.Instance.CurrentState == EscMgr.ESCPanelState.None)
            {
                EscMgr.Instance.OpenPausePanel();
            }
        }
    }
}