using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePers : MonoBehaviour
{
    public GameObject women;
    public GameObject men;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("sex")=="women")
        {
            women.SetActive(true);
            men.SetActive(false);
        }
        else if (PlayerPrefs.GetString("sex") == "men")
        {
            women.SetActive(false);
            men.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
