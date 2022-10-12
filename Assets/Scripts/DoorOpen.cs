using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Transform doorPivot;
    private Animation anim;

    public GameObject theKey;

    private bool doorIsOpen = false;
    private bool inTrigger = false;

    void Start()
    {
        anim = doorPivot.GetComponent<Animation>();
        anim["doorAnim"].speed = 0;
        
    }
    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //cast a ray from screen mouse pos through camera view
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;  //structure to hold info about what we hit.
                if (Physics.Raycast(ray, out hit, 40))
                {
                    Debug.Log("hit door " + hit.collider.name);

                    if (doorIsOpen == false)
                    {
                        anim["doorAnim"].speed = 1;
                        anim.Play();
                        doorIsOpen = true;
                        return;

                    }
                    else if (doorIsOpen)
                    {

                        anim["doorAnim"].speed = -1;

                        if (anim["doorAnim"].time == 0)
                            anim["doorAnim"].time = anim["doorAnim"].length;

                        anim.Play();
                        doorIsOpen = false;
                        return;

                    }

                }
            }

        }

        if (inTrigger &&  Input.GetKeyDown(KeyCode.E) && doorIsOpen == false)
        {
            Debug.Log("key pressed open");

            anim["doorAnim"].speed = 1;
            anim.Play();
            doorIsOpen = true;
            return;
        }
        else if ( inTrigger && Input.GetKeyDown(KeyCode.E) && doorIsOpen == true)
        {
            Debug.Log("key pressed close");

            anim["doorAnim"].speed = -1;

            if (anim["doorAnim"].time == 0)
                anim["doorAnim"].time = anim["doorAnim"].length;

            anim.Play();
            doorIsOpen = false;
            return;

        }


    }

    private void OnTriggerStay(Collider other)
{
        if (other.tag == "Player")
        {
            Debug.Log("on trigger stay");
            inTrigger = true;
            
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        

        //only players open doors
        if (other.tag == "Player")
        {              

            PlayerInventory playerinv = other.transform.GetComponent<PlayerInventory>();
            //does the player THE key that open THIS door
            if (playerinv.hasTheKey(theKey) && doorIsOpen == false)
            {
                anim["doorAnim"].speed = 1;
                anim.Play();
                doorIsOpen = true;
            }
            
        }
        
    }
    private void OnTriggerExit(Collider other)
    {

        inTrigger = false;

        if (other.tag == "Player" && doorIsOpen)
        {
            anim["doorAnim"].speed = -1;
            
            if(anim["doorAnim"].time == 0)
                anim["doorAnim"].time = anim["doorAnim"].length;
            
            anim.Play();
            doorIsOpen = false;
        }
        
    }
}
