using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private InputMaster _inputMaster;
    public bool isShow;
    public GameObject pausemenu;
    public Teach teachScript;
    public OpenPnl shopScript;
    public EscMgr escstateMachine;

    private void OnEnable()
    {
        _inputMaster = new InputMaster();
        _inputMaster.Enable();

        // 綁定 PauseMenu 鍵
        _inputMaster.Menu.PauseMenu.performed += context => HandleEscKey();
    }

    private void OnDisable()
    {
        // 取消綁定 PauseMenu 鍵
        _inputMaster.Menu.PauseMenu.performed -= context => HandleEscKey();
        _inputMaster.Disable();
    }

    void Start()
    {
        pausemenu.SetActive(false);
    }


    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            HandleEscKey();
        }
    }

    void HandleEscKey()
    {
        // 添加空值檢查
        if (teachScript != null && teachScript.teachPnl != null && teachScript.teachPnl.activeSelf)
        {
            teachScript.OnCloseTeachBtn();
        }
        else if (shopScript != null && shopScript.IsShopOpen())
        {
            shopScript.OnBtnClose();
        }
        else
        {
            TogglePauseMenu();
        }
    }


    public void TogglePauseMenu()
    {
        // 確保教學面板未開啟時才切換暫停選單
        if (!teachScript.teachPnl.activeSelf)
        {
            isShow = !isShow;
            pausemenu.SetActive(isShow);
            Time.timeScale = isShow ? 0f : 1f;
            GameDB.isGamepause = isShow;
            escstateMachine.NotifyPanelStateChanged();
        }
    }
}

