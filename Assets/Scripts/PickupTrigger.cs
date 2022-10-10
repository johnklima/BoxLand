using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    //when an object enters a trigger volume
    private void OnTriggerEnter(Collider other)
    {
        //only players can pickup
        if(other.tag == "Player")
        {
            Debug.Log(name + " hit by " + other.name);

            //get the inventory component and add this obj
            other.GetComponent<PlayerInventory>().addToInventory(transform);

        }
        
    }
    
}
