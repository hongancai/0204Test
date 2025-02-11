using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S5Mgr : MonoBehaviour
{
    //public AudioClip s2bgm;
    public List<Button> goodsButtons;
    public List<GameObject> goodsPnl;
    public List<Button> closegoodsPnlBtn;
    //public List<GameObject> buyedItem;
    public GameObject warningPnl;
    public Button closeWarnBtn;

    private GameObject activePanel = null;

    void Start()
    {
        //GameDB.Audio.Playbgm(s2bgm);
        // 初始化所有已購買物品的顯示狀態
        for (int i = 0; i < 5; i++)
        {
            //buyedItem[i].SetActive(GameDB.Bought[i]);
        }

        // 初始化時關閉所有面板
        foreach (var panel in goodsPnl)
        {
            panel.SetActive(false);
        }

        // 設置開啟面板的按鈕監聽器
        for (int i = 0; i < goodsButtons.Count; i++)
        {
            int index = i; // 重要：要用區域變數來保存索引
            goodsButtons[i].onClick.AddListener(() => OpenPanel(index));
        }

        // 設置關閉面板的按鈕監聽器
        for (int i = 0; i < closegoodsPnlBtn.Count; i++)
        {
            int index = i;
            closegoodsPnlBtn[i].onClick.AddListener(() => ClosePanel(index));
        }
    }

    private void OpenPanel(int index)
    {
        // 如果有活動面板，先關閉它
        if (activePanel != null)
        {
            activePanel.SetActive(false);
        }

        // 開啟新的面板
        goodsPnl[index].SetActive(true);
        activePanel = goodsPnl[index];
    }

    private void ClosePanel(int index)
    {
        goodsPnl[index].SetActive(false);
        if (activePanel == goodsPnl[index])
        {
            activePanel = null;
        }
    }

    //public void OnBtnBuyItem1()
    //{
        //if (GameDB.money > 80 && !GameDB.Bought[0])
        //{
            //GameDB.money -= 80;
            //GameDB.Bought[0] = true;
            //Debug.Log("你買了燒餅");
        }
        //else
        //{
            //Debug.Log("你不夠80塊");
        //}
    //}
