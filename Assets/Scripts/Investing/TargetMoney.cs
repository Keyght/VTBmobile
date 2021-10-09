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

        public Bonds(int _nominal,int _percent, int _med_percent, int _period,int _length,int _risk)
        {
            nominal = _nominal;
            cupon = Mathf.CeilToInt( nominal * _percent / _period);
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
        }

        void ChangeCost()
        {
            float min, max;
            min = (lengthBonds - startLengthBonds / 2)/period*cupon+(cupon-medianCupon)* lengthBonds/period- Random.Range(0.0f, 0.1f)*nominal;
            max = (lengthBonds - startLengthBonds / 2)/period*cupon+(cupon-medianCupon)* lengthBonds/period+ Random.Range(0.0f, 0.1f)*nominal;
            curentCost = Mathf.Clamp(curentCost + Random.Range(min, max), nominal *0.8f, nominal * 1.2f);
        }

        public void Close()
        {
            cash = cash + nominal;
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
        contributions.Add(new Contribution(_percent, _length, _sum));
        cash = cash - _sum;
    }

    public static void NewBonds(int _nominal, int _percent, int _med_percent, int _period, int _length, int _risk)
    {
        bonds.Add(new Bonds( _nominal,  _percent,  _med_percent,  _period,  _length,  _risk));
        cash = cash - _nominal;
    }
}
