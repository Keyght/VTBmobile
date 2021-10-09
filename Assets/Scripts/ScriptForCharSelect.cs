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
