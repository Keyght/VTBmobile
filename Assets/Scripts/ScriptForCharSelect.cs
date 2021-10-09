using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptForCharSelect : MonoBehaviour
{
    public Button women;
    public Button men;
    public Button begin;

    public Button work;
    public Button notwork;

    public Button low;
    public Button medium;
    public Button high;



    public GameObject women_obj;
    public GameObject men_obj;

    public InputField namee;

    // Start is called before the first frame update
    void Start()
    {
        int num;
        bool isNum = int.TryParse(PlayerPrefs.GetString("was_begin"), out num);
        //namee = GetComponent<InputField>();
        if (!isNum)
        {
            PlayerPrefs.SetInt("was_begin", 0);
            Debug.Log(PlayerPrefs.GetInt("was_begin"));
        }
        else if (PlayerPrefs.GetInt("was_begin")==1)
        {
            SceneManager.LoadScene("FirstMenu");
        }

        women.onClick.AddListener(select_women);
        men.onClick.AddListener(select_men);
        begin.onClick.AddListener(begin_action);

        work.onClick.AddListener(select_work);
        notwork.onClick.AddListener(select_notwork);

        low.onClick.AddListener(select_low);
        medium.onClick.AddListener(select_medium);
        high.onClick.AddListener(select_high);
    }
    public void select_women()
    {
        women_obj.SetActive(true);
        men_obj.SetActive(false);
        //GameObject.FindGameObjectWithTag("women").SetActive(true);
        //GameObject.FindGameObjectWithTag("men").SetActive(false);
        PlayerPrefs.SetString("sex", "women");
    }
    public void select_men()
    {
        women_obj.SetActive(false);
        men_obj.SetActive(true);
        //GameObject.FindGameObjectWithTag("women").SetActive(false);
        //GameObject.FindGameObjectWithTag("men").SetActive(true);
        PlayerPrefs.SetString("sex", "men");
    }
    public void begin_action()
    {
        PlayerPrefs.SetInt("was_begin", 1);
        SceneManager.LoadScene("FirstMenu");
    }

    public void select_work()
    {
        PlayerPrefs.SetString("type_work", "work");
        Debug.Log(PlayerPrefs.GetString("type_work"));
    }

    public void select_notwork()
    {
        PlayerPrefs.SetString("type_work", "notwork");
        Debug.Log(PlayerPrefs.GetString("type_work"));
    }
    public void select_low()
    {
        PlayerPrefs.SetString("type_fee", "low");
        Debug.Log(PlayerPrefs.GetString("type_fee"));
    }
    public void select_medium()
    {
        PlayerPrefs.SetString("type_fee", "medium");
        Debug.Log(PlayerPrefs.GetString("type_fee"));
    }
    public void select_high()
    {
        PlayerPrefs.SetString("type_fee", "high");
        Debug.Log(PlayerPrefs.GetString("type_fee"));
    }

    // Update is called once per frame
    void Update()
    {
        if (namee.text!="")
        {
            PlayerPrefs.SetString("name", namee.text);
            //Debug.Log(PlayerPrefs.GetString("name"));
        }
        
    }
}
