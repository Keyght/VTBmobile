using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    GameObject[] moneys;
    public void Start()
    {
        moneys = GameObject.FindGameObjectsWithTag("money");
    }
    public void refresMoney()
    {
        foreach (var mon in moneys )
        {
            mon.SetActive(true);
        }
    }
}
