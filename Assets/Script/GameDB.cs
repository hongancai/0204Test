using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDB
{
    public static int towerhp = 0;

    public static int money;
    public static List<bool> Bought = new List<bool>();

    static GameDB()
    {
        Bought.Add(false);
        Bought.Add(false);
        Bought.Add(false);
        Bought.Add(false);
        Bought.Add(false);
    }

    public static void BuyItem(int index)
    {
        Bought[index] = true;
    }
}