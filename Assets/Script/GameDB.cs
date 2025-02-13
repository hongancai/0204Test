using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDB
{
    public static int towerhp = 0;

    public static int money = 1000;
    public static List<bool> Bought = new List<bool>();
    
    private static bool isInitialized = false;
    static GameDB()
    {
        if (!isInitialized)
        {
            InitializeData();
            isInitialized = true;
        }
    }

    private static void InitializeData()
    {
        // 清空列表以防重複添加
        Bought.Clear();
        // 初始化購買狀態
        for (int i = 0; i < 5; i++)
        {
            Bought.Add(false);
        }
    }

    public static void BuyItem(int index)
    {
        Bought[index] = true;
        Save();
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("Money", money);
        
        // 儲存購買狀態
        for (int i = 0; i < Bought.Count; i++)
        {
            PlayerPrefs.SetInt($"Bought_{i}", Bought[i] ? 1 : 0);
        }
        
        PlayerPrefs.Save();
    }

    public static void Load()
    {
        money = PlayerPrefs.GetInt("Money", 1000);
        
        // 讀取購買狀態
        for (int i = 0; i < Bought.Count; i++)
        {
            Bought[i] = PlayerPrefs.GetInt($"Bought_{i}", 0) == 1;
        }
    }
}
