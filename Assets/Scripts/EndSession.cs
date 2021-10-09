using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSession : MonoBehaviour
{
    public GameObject FinishCanvas;
    public GameObject FinishCanvasGood;


    public GameObject oldmoney;
    

    public float timerValue = 0f;

    public bool isGameFinished;
    public Text TimerText;
    public Text TextCounter;
    public int previos_money;

    public int moneyGet_K=200;

    void Update()
    {
        UpdateTimer();
    }
    void Start()
    {
        int num;
        bool isNum = int.TryParse(PlayerPrefs.GetString("Money"), out num);
        if (!isNum) {
            PlayerPrefs.SetInt("Money", 0);
            Debug.Log(PlayerPrefs.GetInt("Money"));
        }
        else
        {
            previos_money = PlayerPrefs.GetInt("Money");
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name.Contains("Floor")) || (collision.gameObject.name.Contains("Prep")))
        {
            isGameFinished = true;
            FinishCanvas.SetActive(true);
            TimerText = GameObject.Find("TimerText").GetComponent<Text>();
            TextCounter = GameObject.Find("TextCounter").GetComponent<Text>();
            TimerText.text = "Время прохождения: " + FormatTime(timerValue);
            TextCounter.text = "Количество заработанных монет: " + (PlayerPrefs.GetInt("Money")-previos_money);
            StartCoroutine(OpenInterfaceScreen(3));
            Debug.Log("Hit");
        }
        if (collision.gameObject.name.Contains("Money"))
        {
            Debug.Log("Level over");
            //oldmoney = GameObject.Find(collision.gameObject.name);
            //oldmoney.SetActive(false);
            collision.gameObject.SetActive(false);
            int k = PlayerPrefs.GetInt("Money")+1;
            PlayerPrefs.SetInt("Money", k);
            Debug.Log(PlayerPrefs.GetInt("Money"));
        }
        if (collision.gameObject.name == "EndCylindr")
        {
            Debug.Log("Level over");
            isGameFinished = true;
            FinishCanvasGood.SetActive(true);
            TimerText = GameObject.Find("TimerText").GetComponent<Text>();
            TextCounter = GameObject.Find("TextCounter").GetComponent<Text>();
            TimerText.text = "Время прохождения: " + FormatTime(timerValue);
            TextCounter.text = "Количество заработанных монет: " + (PlayerPrefs.GetInt("Money") - previos_money);
            StartCoroutine(OpenInterfaceScreen(3));
        }

        
    }
    IEnumerator OpenInterfaceScreen(float time)
    {
        
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("FirstMenu");
        AddMoney();
    }

    void UpdateTimer()
    {
        if (isGameFinished) return;
        timerValue += Time.deltaTime;
    }

    string FormatTime(double unformatted)
    {
        int rounded = (int)Math.Round(unformatted);
        return AddLeadingZero(rounded / 3600) + ":"
               + AddLeadingZero(rounded / 60) + ":"
               + AddLeadingZero(rounded % 60);
    }
    string AddLeadingZero(int n)
    {
        if (n < 10)
            return "0" + n.ToString();
        else
            return n.ToString();
    }

    void AddMoney()
    {
        TargetMoney.curentMoney = TargetMoney.curentMoney + PlayerPrefs.GetInt("Money") * moneyGet_K;
        TargetMoney.cash = TargetMoney.cash + PlayerPrefs.GetInt("Money") * moneyGet_K;
        TargetMoney.addInflation();
    }
}
