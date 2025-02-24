using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDB
{
    //Tower
    public static int towerhp = 0;
    
    //PlayerMoney
    public static int money = 10000;
    
    //Pause
    public static bool isGamepause;
    
    //Shop
    public static List<bool> Bought = new List<bool>();
    public static List<bool> BoughtTower = new List<bool>();
    
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
        BoughtTower.Clear();
        for (int i = 0; i < 4; i++)
        {
            BoughtTower.Add(false);
        }
    }

    public static void BuyItem(int index)
    {
        Bought[index] = true;
        Save();
    }
    public static void BuyTower(int index)
    {
        BoughtTower[index] = true;
        Save();
    }
    
    
    //PlayerPrefs
    public static void Save()
    {
        PlayerPrefs.SetInt("Money", money);
    
        // 一般商店物品
        for (int i = 0; i < Bought.Count; i++)
        {
            PlayerPrefs.SetInt($"Shop_Bought_{i}", Bought[i] ? 1 : 0);
        }
    
        // 塔防商店物品
        for (int i = 0; i < BoughtTower.Count; i++)
        {
            PlayerPrefs.SetInt($"Tower_Bought_{i}", BoughtTower[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    public static void Load()
    {
        money = PlayerPrefs.GetInt("Money", 10000);
    
        // 一般商店物品
        for (int i = 0; i < Bought.Count; i++)
        {
            Bought[i] = PlayerPrefs.GetInt($"Shop_Bought_{i}", 0) == 1;
        }
    
        // 塔防商店物品
        for (int i = 0; i < BoughtTower.Count; i++)
        {
            BoughtTower[i] = PlayerPrefs.GetInt($"Tower_Bought_{i}", 0) == 1;
        }
    }
    public static void ResetAll()
    {
        money = 10000;  // 重置金錢
    
        // 重置所有商品購買狀態
        for (int i = 0; i < Bought.Count; i++)
        {
            Bought[i] = false;
        }
        for (int i = 0; i < BoughtTower.Count; i++)
        {
            BoughtTower[i] = false;
        }
    
        // 儲存重置後的狀態
        Save();
    }
    
}
