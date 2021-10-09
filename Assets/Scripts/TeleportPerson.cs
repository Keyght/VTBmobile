using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPerson : MonoBehaviour
{
    public GameObject pers;
    public Transform portal;
    private float z_offset;


    void Start()
    {
        z_offset = portal.position.z-pers.transform.position.z;
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("TeleportPoint"))
        {
            pers.transform.position = new Vector3(pers.transform.position.x, pers.transform.position.y, pers.transform.position.z- z_offset);
            Debug.Log("Teleport");
        }
    }
   
}
