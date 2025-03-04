using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class S7Mgr : MonoBehaviour
{
    public List<GameObject> tower;
    public List<GameObject> towerPnl;
    public List<Button> closegoodsPnlBtn;
    public GameObject warningPnl;
    public Button closeWarnBtn;
    public Button buy02;
    public Button buy03;
    public Button buy04;
    public Button buy05;
    public EscMgr escManager;
    
    public GameObject activePanel = null;
    private bool isPanelOpen = false;
    private bool isClosingPanel = false; // 防止面板關閉時的重複觸發
    
    void Start()
    {
        // 註冊關閉按鈕事件
        for (int i = 0; i < closegoodsPnlBtn.Count; i++)
        {
            int index = i; // 創建一個區域變數來儲存當前索引
            closegoodsPnlBtn[i].onClick.AddListener(() => ClosePanel(index));
        }
        
        // 初始化警告面板和按鈕
        warningPnl.gameObject.SetActive(false);
        closeWarnBtn.onClick.AddListener(OnCloseWarning);
        
        // 註冊購買按鈕事件
        buy02.onClick.AddListener(OnBtnBuyItem2);
        buy03.onClick.AddListener(OnBtnBuyItem3);
        buy04.onClick.AddListener(OnBtnBuyItem4);
        buy05.onClick.AddListener(OnBtnBuyItem5);
    }
    
    private void OnCloseWarning()
    {
        warningPnl.gameObject.SetActive(false);
    }

    void Update()
    {
        // 只有在沒有開啟面板時才檢測點擊
        if (Input.GetButtonDown("Fire1") && !isPanelOpen && !isClosingPanel)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                // 檢查點擊到的物件是否在tower列表中
                for (int i = 0; i < tower.Count; i++)
                {
                    if (hit.collider.gameObject == tower[i])
                    {
                        OpenPanel(i);
                        break;
                    }
                }
            }
        }
    }

    // 開啟面板
    private void OpenPanel(int index)
    {
        if (isClosingPanel) return; // 如果正在關閉面板，不允許開啟新面板
        
        Time.timeScale = 0;
        
        // 如果有其他面板開著，先關閉
        if (activePanel != null)
        {
            activePanel.SetActive(false);
        }

        // 開啟對應的面板
        towerPnl[index].SetActive(true);
        activePanel = towerPnl[index];
        isPanelOpen = true;
        
        // 如果使用新的 ESC 管理器系統，則注冊此面板
        if (escManager != null)
        {
            // 注冊到 ESC 管理器
            escManager.RegisterPanel(EscMgr.ESCPanelState.LionPanel);
        }
    }

    // 關閉面板 (由按鈕調用)
    private void ClosePanel(int index)
    {
        if (isClosingPanel) return; // 防止重複關閉
        
        isClosingPanel = true;
        Time.timeScale = 1;
        towerPnl[index].SetActive(false);
        activePanel = null;
        isPanelOpen = false; 
        
        // 如果使用新的 ESC 管理器，則取消注冊此面板
        if (escManager != null)
        {
            escManager.UnregisterPanel(EscMgr.ESCPanelState.LionPanel);
        }
        
        // 添加延遲，防止立即觸發其他面板
        StartCoroutine(ResetClosingFlag());
    }
    
    // 關閉當前激活的面板 (由 ESC 管理器調用)
    public void CloseCurrentPanel()
    {
        if (activePanel == null || isClosingPanel) return;
        
        isClosingPanel = true;
        Time.timeScale = 1;
        activePanel.SetActive(false);
        activePanel = null;
        isPanelOpen = false;
        
        // 添加延遲，防止立即觸發其他面板
        StartCoroutine(ResetClosingFlag());
    }
    
    // 重置關閉標誌的協程
    private IEnumerator ResetClosingFlag()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        isClosingPanel = false;
    }
    
    // 購買物品相關方法
    private void OnBtnBuyItem2()
    {
        if (GameDB.money >= 300 && !GameDB.BoughtTower[0])
        {
            buy02.gameObject.SetActive(false);
            GameDB.money -= 300;
            GameDB.BoughtTower[0] = true;
            GameDB.Save();
            Debug.Log("你買了後水頭");
        }
        else
        {
            warningPnl.gameObject.SetActive(true);
            Debug.Log("你不夠300塊");
        }
    }

    private void OnBtnBuyItem3()
    {
        if (GameDB.money >= 500 && !GameDB.BoughtTower[1])
        {
            buy03.gameObject.SetActive(false);
            GameDB.money -= 500;
            GameDB.BoughtTower[1] = true;
            GameDB.Save();
            Debug.Log("你買了劉澳");
        }
        else
        {
            warningPnl.gameObject.SetActive(true);
            Debug.Log("你不夠500塊");
        }
    }

    private void OnBtnBuyItem4()
    {
        if (GameDB.money >= 700 && !GameDB.BoughtTower[2])
        {
            buy04.gameObject.SetActive(false);
            GameDB.money -= 700;
            GameDB.BoughtTower[2] = true;
            GameDB.Save();
            Debug.Log("你買了安崎");
        }
        else
        {
            warningPnl.gameObject.SetActive(true);
            Debug.Log("你不夠700塊");
        }
    }

    private void OnBtnBuyItem5()
    {
        if (GameDB.money >= 1500 && !GameDB.BoughtTower[3])
        {
            buy05.gameObject.SetActive(false);
            GameDB.money -= 1500;
            GameDB.BoughtTower[3] = true;
            GameDB.Save();
            Debug.Log("你買了塔后");
        }
        else
        {
            warningPnl.gameObject.SetActive(true);
            Debug.Log("你不夠1500塊");
        }
    }
}