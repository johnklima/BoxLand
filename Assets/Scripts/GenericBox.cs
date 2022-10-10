/*
 * 
 * 
 * Just a simple demonstration of variable types, array manipulation, and timers
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GenericBox : MonoBehaviour
{
    //variable types:
    public bool myBool;
    public float myFloat;
    public double myDouble;
    public string myString = "this is my first string";
    public string[] textList;
    public GameObject[] gameObjs;

    int curObj = 0;
    float timer = -1;

    // Start is called before the first frame update

    private void Start()
    {
        //initialize
        curObj = 0;
        timer = Time.time;

        //what do we got in the lists
        for (int i = 0; i < textList.Length; i++)
        {
            Debug.Log("for " + textList[i] + " is index " + i);
        }

        int ii = 0;
        foreach(string t in textList)
        {
            Debug.Log("for each " + t + " is index " + ii);
            ii++;
        }
        

    }

    // Update is called once per frame
    private void Update()
    {       
        
        //set deactivate for each object on three second intervals
        if(curObj < gameObjs.Length )
        {
            //has one second passed
            if(Time.time - timer > 1.0f)
            {
                Debug.Log("current object is " + gameObjs[curObj].name);
                
                //flip it off if it is on, or on if it is off using BANG!!!!!
                gameObjs[curObj].SetActive(!gameObjs[curObj].activeSelf);
                
                curObj++;           //increment the object to the next
                timer = Time.time;  //reset the timer for another round
            }
        }
        else  
        {
            //once curobj bigger than list, reset curobj, and timer to new time
            curObj = 0;
            timer = Time.time;            
        }        

    }
}
                             