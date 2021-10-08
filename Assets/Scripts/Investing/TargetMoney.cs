using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TargetMoney 
{
    public static int targetMoney;
    public static int curentMoney;
    public static float inflation;
    
    public static void setMoney(int curent,int target, float _inflation)
    {
        targetMoney = target;
        curentMoney = curent;
        inflation = _inflation;
    }
    
    public static void addInflation()
    {
        targetMoney = targetMoney + Mathf.CeilToInt(targetMoney * inflation);
    }
    public static void addMoney(int money)
    {
        curentMoney = curentMoney + money;
    }
}
