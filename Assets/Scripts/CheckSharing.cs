using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSharing : MonoBehaviour
{
    // Start is called before the first frame update
    public string name;
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        if (PlayerPrefs.HasKey(name + "_sharing"))
        {
            button.interactable = false;
        }
    }

    // Update is called once per frame
    public void Share()
    {
        button.interactable = false;
        PlayerPrefs.SetInt(name + "_sharing", 1);
        TargetMoney.curentMoney = TargetMoney.curentMoney + 200;
        TargetMoney.cash = TargetMoney.cash + 200;
    }
}
