using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;    //what to look at
    public float height = 5 ;   //how high above it
    public float distance = 3;  //how far behind it

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get target location and forward
        Vector3 pos = target.position;
        Vector3 fwd = target.forward;

        //set cam position to target position, move back from it, move up from it
        transform.position = pos - (fwd * distance) + (Vector3.up * height);
        
        //look at it
        transform.LookAt(target);
    }
}
