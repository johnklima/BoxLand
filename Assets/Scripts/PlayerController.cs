using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player movement variables
    public float turnSpeed = 10.0f;
    public float moveSpeed = 5.0f;

    //bools for allowing aspects of movement
    public bool doTheSlerp = false;
    public bool doTheMovement = true;
    public bool doTheTurn = true;
    public bool doTheWalk = true;

    //rotations for the slerp demo (for information only)
    Quaternion arot;
    Quaternion brot;
    
    //time increments for slerp demo
    float t1 = 0;
    float t2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        //FOR THE SLERP DEMO ONLY:

        //get my start rotation and "buffer" it
        arot = transform.rotation;

        //use the transform to find a specific rotation (easy way)
        transform.Rotate(Vector3.up, 90);

        //assign it to the target rotation
        brot = transform.rotation;

        //reset to my start rotation
        transform.rotation = arot;

    }

    // Update is called once per frame
    void Update()
    {
        //"process" the possible states
        if (doTheMovement)
            doMovement();

        //do the slerp demo
        if(doTheSlerp)
            doSlerp(2.0f);
    }

    void doMovement()
    {
        //can I turn?
        if(doTheTurn)
            doTurn();
           
        //can I walk
        if(doTheWalk)        
            doWalk();

    }
    void doWalk()
    {
        float move;

        //get controller state
        move = Input.GetAxis("Vertical");

        //move the dude in his forward direction
        transform.position = transform.position
                           + transform.forward
                           * move
                           * moveSpeed
                           * Time.deltaTime;
    }

    void doTurn()
    {
        float turn;

        //get controller state
        turn = Input.GetAxis("Horizontal");

        //spin the sucker around the up axis
        transform.Rotate(Vector3.up,
                          turn
                        * turnSpeed * 60.0f
                        * Time.deltaTime
                        );


    }

    void doSlerp(float speed)
    {

        //if moving from initial to target
        if (t1 < 1)
        {
            transform.rotation = Quaternion.Slerp(arot, brot, t1);
            t1 += Time.deltaTime * speed ;

        }

        //if moving from target back to initial
        if (t1 > 0.999f && t2 < 1)
        {
            
            transform.rotation = Quaternion.Slerp(brot, arot, t2);
            t2 += Time.deltaTime;
        }

        //if completed return to initial, reset both
        if (t2 > 1)
        {
            t2 = 0;
            t1 = 0;
        }
        
    }
    
}
