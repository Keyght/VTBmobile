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

    public class Bonds
    {
        public int cupon;
        public int medianCupon;
        public int lengthBonds;
        public int startLengthBonds;
        public int period;
        public int curenPeriod;
        public int nominal;
        public float curentCost;
        public int risk;// 1/100000

        public Bonds(int _nominal,float _percent, int _med_percent, int _period,int _length,int _risk)
        {
            nominal = _nominal;
            curentCost = nominal;
            cupon = Mathf.CeilToInt( nominal * _percent * _period/12);
            period = _period;
            curenPeriod = period;
            lengthBonds = _length;
            startLengthBonds = _length;
            risk = _risk;
            medianCupon= Mathf.CeilToInt(nominal * _med_percent / _period);
        }

        public void NewMounth()
        {
            if (lengthBonds > 0)
            {
                lengthBonds = lengthBonds - 1;
                curenPeriod = curenPeriod - 1;
                if (curenPeriod <= 0)
                {
                    curenPeriod = period;
                    curentMoney = curentMoney + cupon;
                    cash = cash + cupon;
                }
                
                
            }
            ChangeCost();
        }

        void ChangeCost()
        {
            float min, max;
            min = (lengthBonds - startLengthBonds )/period*cupon/20+(cupon-medianCupon)* lengthBonds/period/20- Random.Range(0.1f, 0.2f)*nominal;
            max = (lengthBonds - startLengthBonds )/period*cupon/20+(cupon-medianCupon)* lengthBonds/period/20+ Random.Range(0.0f, 0.1f)*nominal;
            Debug.Log(min + " " + max);
            float trash = curentCost + Random.Range(min, max);
            trash= Mathf.Clamp(trash, nominal * 0.8f, nominal * 1.2f);
            Debug.Log(trash);
            curentCost = trash;
            Debug.Log(curentCost);
        }

        public void Close()
        {
            cash = cash + nominal;
        }
        public void Sell()
        {
            curentMoney = curentMoney - nominal + Mathf.RoundToInt(curentCost);
            cash = cash +Mathf.RoundToInt( curentCost);
        }
    }


    public static int targetMoney;
    public static int curentMoney;
    public static int cash;
    public static int allMoney;
    public static float inflation;
    public static List<Contribution> contributions=new List<Contribution>();
    public static List<Bonds> bonds=new List<Bonds>();
    
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
        newMounth();


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
            contrib.NewMounth();
            if (contrib.lengthContributs<=0)
            {
                contrib.Close();
                contributions.Remove(contrib);
            }
        }
        foreach (var bond in bonds)
        {
            bond.NewMounth();
            if (bond.lengthBonds <= 0)
            {
                bond.Close();
                bonds.Remove(bond);
            }
        }
    }

    public static void NewContribution(float _percent, int _length, int _sum)
    {
        contributions.Add(new Contribution(_percent, _length, _sum));
        cash = cash - _sum;
    }

    public static void NewBonds(int _nominal, float _percent, int _med_percent, int _period, int _length, int _risk)
    {
        bonds.Add(new Bonds( _nominal,  _percent,  _med_percent,  _period,  _length,  _risk));
        cash = cash - _nominal;
    }
    public static void SellBond(int _period)
    {
        foreach (var bond in bonds)
        {
            if (bond.period == _period)
            {
                bond.Sell();
                bonds.Remove(bond);
                break;
            }
        }
        
    }

    public static int GetBond(int _period)
    {
        int sum=0;
        foreach (var bond in bonds)
        {
            if (bond.period == _period)
            {
                sum = sum + bond.cupon;
            }
        }
        return sum;
    }
    public static int GetBondCount(int _period)
    {
        int sum = 0;
        foreach (var bond in bonds)
        {
            if (bond.period == _period)
            {
                sum = sum + 1;
                Debug.Log(sum + " " + bond.curentCost);
            }
        }
        return sum;
    }
    public static int GetBondCost(int _period)
    {
        int sum = 0;
        foreach (var bond in bonds)
        {
            if (bond.period == _period)
            {
                sum =Mathf.RoundToInt( bond.curentCost);
                Debug.Log(sum+" "+ bond.curentCost);
                break;
            }
        }
        return sum;
    }
}
