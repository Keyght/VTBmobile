using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressMoney : MonoBehaviour
{
    Slider slider;
    public Text percent;
    public Text curentM;
    public Text targetM;
    public Text cashM;
    public int targetMoney;
    public int curentMoney;
    public float inflation;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlider();
        InputUpdate();
    }

    public void InputUpdate()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            TargetMoney.setMoney(curentMoney, targetMoney, inflation);
            UpdateSlider();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            TargetMoney.addMoney(10);
            UpdateSlider();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            TargetMoney.addInflation();
            UpdateSlider();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            TargetMoney.newMounth();
            UpdateSlider();
        }
    }

    public void UpdateSlider()
    {
        float trash = TargetMoney.curentMoney;
        trash = trash/TargetMoney.targetMoney;
        slider.value = trash;
        trash = Mathf.RoundToInt(slider.value * 1000);
        trash = trash / 10;
        percent.text = trash + "%";
        curentM.text = TargetMoney.curentMoney.ToString();
        targetM.text= TargetMoney.targetMoney.ToString();
        cashM.text= TargetMoney.cash.ToString();
    }

    
}
