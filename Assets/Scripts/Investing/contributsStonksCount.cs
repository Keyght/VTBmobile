using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contributsStonksCount : MonoBehaviour
{
    public float percent;
    public int lengthContributs;
    public int minSum;
    public Text sum;
    public Text stonks;
    public Color colorWrong;
    public Color colorCorrect;
    public Button openButton;
    // Start is called before the first frame update
    void Start()
    {
       // colorCorrect = sum.color;
    }
    public void SetInfo(float _percent, int _length,int _minSum)
    {
        percent = _percent/12;
        lengthContributs = _length;
        minSum = _minSum;
        sum.text = minSum.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (int.Parse(sum.text) < minSum)
        {
            stonks.text = "Сумма должа быть больше " + minSum;
            stonks.color = colorWrong;
            openButton.interactable = false;
        }
        else if (int.Parse(sum.text) > TargetMoney.cash)
        {
            stonks.text = "У вас нет такой суммы";
            stonks.color = colorWrong;
            openButton.interactable = false;
        }
        else
        {
            int stonksInt = 0;
            stonksInt = Mathf.CeilToInt(Percent(float.Parse(sum.text), lengthContributs));
            stonks.text = "Доход " + (stonksInt - int.Parse(sum.text));
            stonks.color = colorCorrect;
            openButton.interactable = true;
        }
    }

    float Percent(float sum,int count)
    {
        float curentStonk = sum + sum * percent;
        if (count <= 1) return curentStonk;
        else return Percent(curentStonk, count - 1);
    }
    public void NewContribution()
    {
        Debug.Log(percent / 12 + " " + lengthContributs + " " + int.Parse(sum.text));
        TargetMoney.NewContribution(percent / 12, lengthContributs, int.Parse(sum.text));
        
    }
}
