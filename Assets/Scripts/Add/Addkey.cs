using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addkey : MonoBehaviour
{
    // Start is called before the first frame update
    public string Key;

    public void Add()
    {
        PlayerPrefs.SetInt(Key, 1);
    }
}
