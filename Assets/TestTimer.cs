using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimer : MonoBehaviour
{
    float timer = -1;
    public float delay = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setTimeAndDelay(float _time, float _delay)
    {
        timer = _time;
        delay = _delay;

    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0 && Time.time - timer > delay )
        {
            Vector3 scale = transform.localScale;
            scale.y /= 2;
            transform.localScale = scale;
            timer = -1;
        }
    }
}
