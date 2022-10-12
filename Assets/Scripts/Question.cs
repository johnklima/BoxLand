using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{

    
    public string text;     //the text to show in the text box
    public Sprite image;    //the image to show in the image box

    public Text uiTextBox;  //the text box
    public Image uiImage;   //the image box
    public Image uiFrame;    //the inage that contains the two UI object above
    
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
