using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerController>().doTheMovement = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerController>().doTheMovement = true;
        }
    }

}
