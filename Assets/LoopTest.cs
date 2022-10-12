using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach(Transform child in transform)
            {

                Vector3 scale = child.localScale ;
                scale.y *= 2;
                child.localScale = scale;

            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform fred = transform.GetChild(i);
                fred.GetComponent<TestTimer>().setTimeAndDelay(Time.time, i);
                
            }

        }
    }
}
