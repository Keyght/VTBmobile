using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheBall : MonoBehaviour
{
    public Transform Camera;
    public Transform Target;
    private Vector3 offset;
    void Start()
    {
        offset = (Camera.position - Target.position);
    }

    void FixedUpdate()
    {
        Camera.position = Target.position + offset;
    }

}
