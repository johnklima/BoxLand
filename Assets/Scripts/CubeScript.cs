using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public float timer = -1;
    public float delay = 1.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0 && transform.childCount > 0 && Time.time - timer > delay )
        {
            transform.GetChild(0).gameObject.SetActive(true);
            timer = -1;

            this.enabled = false;

        }
        
    }
}
