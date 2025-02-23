using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S7Mgr : MonoBehaviour
{
    public List<GameObject> tower;
    public List<GameObject> towerPnl;
    public List<Button> closegoodsPnlBtn;
    public GameObject warningPnl;
    public Button closeWarnBtn;
    //public Button buy01;
    //public Button buy02;
    //public Button buy03;
    //public Button buy04;
    
    public GameObject activePanel = null;
    private bool isPanelOpen = false;
    void Start()
    {
        for (int i = 0; i < closegoodsPnlBtn.Count; i++)
        {
            int index = i; // 創建一個區域變數來儲存當前索引
            closegoodsPnlBtn[i].onClick.AddListener(() => ClosePanel(index));
        }
    }

    void Update()
    {
        // 當滑鼠左鍵點擊時
        if (Input.GetButtonDown("Fire1")&& !isPanelOpen)
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
        // 如果有其他面板開著，先關閉
        if (activePanel != null)
        {
            activePanel.SetActive(false);
        }

        // 開啟對應的面板
        towerPnl[index].SetActive(true);
        activePanel = towerPnl[index];
        
        isPanelOpen = true; 
    }

    // 關閉面板
    private void ClosePanel(int index)
    {
        towerPnl[index].SetActive(false);
        activePanel = null;
        isPanelOpen = false; 
    }
}

