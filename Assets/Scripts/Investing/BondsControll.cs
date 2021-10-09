using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BondsControll : MonoBehaviour
{


    float percent;
    public float minPercent;
    public float maxPercent;
    public Text percentField;
    public Text stonksField;

    public Text countField;
    public Text stonksBoldField;
    public Text currentCost;

    public int period;
    public int lengthBonds;
    public int nominal;
    public int risk;

    public Button buyButton;
    public Button sellButton;
    
    // 1/100000
    // Start is called before the first frame update
    void Start()
    {
        percent = Random.Range(minPercent, maxPercent);
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetMoney.cash < nominal)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }

        if (TargetMoney.GetBondCount(period) <= 0)
        {
            sellButton.interactable = false;
        }
        else
        {
            sellButton.interactable = true;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
           
            UpdateText();

        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            UpdateText();

        }
    }

    public void UpdateText()
    {
        float trash = Mathf.RoundToInt(percent * 1000);
        trash = trash / 10;
        percentField.text = trash + "% годовых";
        stonksField.text = "+" + Mathf.RoundToInt(nominal * percent * period / 12) + " каждые " + period + " ";
        if (period < 5) stonksField.text = stonksField.text + "месяца";
        else stonksField.text = stonksField.text + "месяцев";

        countField.text = TargetMoney.GetBondCount(period).ToString();
        stonksBoldField.text = TargetMoney.GetBond(period).ToString() + "/в " + period + " мес.";
        currentCost.text = TargetMoney.GetBondCost(period).ToString();
    }

    public void BuyBand()
    {
        TargetMoney.NewBonds(nominal, percent, Mathf.RoundToInt((maxPercent - minPercent) / 2), period, lengthBonds, risk);
        UpdateText();
    }
    public void SellBand()
    {
        TargetMoney.SellBond(period);
        UpdateText();
    }
}
