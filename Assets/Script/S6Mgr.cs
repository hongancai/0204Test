using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S6Mgr : MonoBehaviour
{
    public List<GameObject> buyedItems;
    public List<GameObject> buyTowers;
    
    void Start()
    {
        GameDB.Load();
        UpdateDisplay();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameDB.ResetAll();
            UpdateDisplay();  // 如果在S6中
        }
    }
  
    private void UpdateDisplay()
    {
        // 根據 GameDB.Bought 的狀態更新物品顯示
        for (int i = 0; i < GameDB.Bought.Count; i++)
        {
            // 假設你有一個存放已購買物品的GameObject列表
            if (buyedItems != null && i < buyedItems.Count)
            {
                buyedItems[i].SetActive(GameDB.Bought[i]);
            }
        }
        for (int i = 0; i < GameDB.BoughtTower.Count; i++)
        {
            // 假設你有一個存放已購買物品的GameObject列表
            if (buyTowers != null && i < buyTowers.Count)
            {
                buyTowers[i].SetActive(GameDB.BoughtTower[i]);
            }
        }
    }
}
