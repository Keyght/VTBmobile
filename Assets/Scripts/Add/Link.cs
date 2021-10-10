using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    public string link;
    public void Go()
    {
        Application.OpenURL(link);
    }

}
