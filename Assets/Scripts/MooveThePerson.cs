using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooveThePerson : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {

        float moveHorizontal;
        //float moveVertical;

        if (Application.platform == RuntimePlatform.Android)
        {

            moveHorizontal = Input.acceleration.x;
            //moveVertical = Input.acceleration.y;

        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            //moveVertical = Input.GetAxis("Vertical");
        }

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

}
