using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePerson : MonoBehaviour
{
    public Transform Camera;
    //public Transform Target;
    GameObject target;

    public GameObject women;
    public GameObject men;


    private Vector3 offset;
    void Start()
    {
        if (PlayerPrefs.GetString("sex")=="women")
        {
            women.SetActive(true);
            men.SetActive(false);
            target = women;
        }
        else if (PlayerPrefs.GetString("sex") == "men")
        {
            women.SetActive(false);
            men.SetActive(true);
            target = men;
        }
        //offset = (Camera.position - Target.position);
        offset = (Camera.position - target.transform.position);
    }

    void FixedUpdate()
    {
        //Camera.position = Target.position + offset;
        Camera.position = target.transform.position + offset;
    }
}
