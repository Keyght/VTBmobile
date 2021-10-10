using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public string startKey;
    public string endKey;
    public GameObject window;
    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerPrefs.HasKey(endKey))
        {
            Destroy(window);
            Destroy(this);
        }
        if (!PlayerPrefs.HasKey(startKey))
        {
            window.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Complite()
    {
        PlayerPrefs.SetInt(endKey, 1);
        Destroy(window);
        Destroy(this);
    }
    public void Update()
    {
        if (PlayerPrefs.HasKey(startKey))
        {
            window.SetActive(true);
        }
    }
}
