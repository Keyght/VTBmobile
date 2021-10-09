using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TargetMoney 
{
    public class Contribution
    {
        public float percent;
        public int lengthContributs;
        public float sum;
        public Contribution(float _percent, int _length, int _sum)
        {
            percent = _percent;
            lengthContributs = _length;
            sum = _sum;
        }

        public void NewMounth()
        {
            if (lengthContributs > 0)
            {
                curentMoney = Mathf.CeilToInt( curentMoney + sum * percent);//Будет ошибка в округление исправить когда нибуд потом!!!!
                sum = sum + Mathf.CeilToInt(sum * percent);
                lengthContributs=lengthContributs - 1;
            }
        }
        public void Close()
        {
            cash = Mathf.CeilToInt(cash + sum);
        }
    }



    public static int targetMoney;
    public static int curentMoney;
    public static int cash;
    public static int allMoney;
    public static float inflation;
    public static List<Contribution> contributions=new List<Contribution>();
    
    public static void setMoney(int curent,int target, float _inflation)
    {
        targetMoney = target;
        curentMoney = curent;
        inflation = _inflation;
        cash = curent;
    }
    
    public static void addInflation()
    {
        targetMoney = targetMoney + Mathf.CeilToInt(targetMoney * inflation);
    }
    public static void addMoney(int money)
    {
        curentMoney = curentMoney + money;
    }


    public static void newMounth()
    {
        Debug.Log(cash + " cash " + contributions.Count);
        foreach (var contrib in contributions)
        {
            Debug.Log(contrib.percent + " cash " + contrib.lengthContributs+" "+contrib.sum);
            contrib.NewMounth();
            if (contrib.lengthContributs<=0)
            {
                contrib.Close();
                contributions.Remove(contrib);
            }
        }
    }

    public static void NewContribution(float _percent, int _length, int _sum)
    {
        Debug.Log(_percent + " " + _length + " | " + _sum);
        contributions.Add(new Contribution(_percent, _length, _sum));
        cash = cash - _sum;
        Debug.Log(contributions.Count);
    }
}
