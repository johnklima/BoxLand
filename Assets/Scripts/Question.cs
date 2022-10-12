using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : Dialog
{

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        uiTextBox.text = text;
        uiImage.sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void moveNext()
    {
        uiTextBox.text = text;
        uiImage.sprite = image;

        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
                Debug.Log(child.name);
                
                Answer answer = child.GetComponent<Answer>();
                
                answer.refresh();
               
            }

        }
    }
}
