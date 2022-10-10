using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //warning, parallel arrays, not the cleanest way, but it works
    public Transform[] items = new Transform[3]; // array to hold items
    public Transform[] slots = new Transform[3]; // hud locations to place items    
    public Transform pickups; //scene empty for organization in the hierarchy

    private void Update()
    {
        //when user clicks the left mouse
        if(Input.GetMouseButtonDown(0))
        {
            //cast a ray from screen mouse pos through camera view
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;  //structure to hold info about what we hit.
            if (Physics.Raycast(ray, out hit, 40))
            {
                Debug.Log(hit.transform.name);

                //check if it is in our inventory
                for(int i = 0; i < items.Length; i++)
                {
                    //if this is the one
                    if( items[i] == hit.transform )
                    {
                        //remove the item in the list
                        items[i] = null;
                        
                        //get the parallel slot location, first child is the object
                        Transform obj = slots[i].GetChild(0);
                        
                        //place it under the pickup empty
                        obj.parent = pickups;
                        
                        //get player's forward facing
                        Vector3 fwd = transform.forward;
                        
                        //add a bit to it
                        obj.position += fwd * 2;

                        //turn on physics
                        Rigidbody rigid = obj.GetComponent<Rigidbody>();
                        rigid.useGravity = true;
                        rigid.isKinematic = false;

                        return;  //exit function
                    }
                }

            }
        }
    }


    public void addToInventory(Transform obj)
    {
        Debug.Log(obj.name + "was added to inventory");        

        //check for free slots
        for(int i = 0; i < items.Length; i++)
        {
            //did we find one?
            if(items[i] == null)
            {
                //assign it
                items[i] = obj;
                
                //init position to zero 
                obj.position = Vector3.zero;
                
                //remove from pickups and add to parallel slot position
                obj.parent = slots[i];

                //set the obj positon to slot position
                obj.localPosition = slots[i].localPosition;

                //set rotation to zero
                obj.localRotation = Quaternion.identity;

                //turn off physics
                Rigidbody rigid = obj.GetComponent<Rigidbody>();
                rigid.useGravity = false;
                rigid.isKinematic = true;
                                
                return; //exit function, we are done
            }
        }

        //inform player they ran out of slots
        Debug.Log("YOU RAN OUT OF SLOTS!!!");

    }

}
