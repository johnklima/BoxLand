using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public string text;     //the text to show in the text box
    public Sprite image;    //the image to show in the image box

    public Text uiTextBox;  //the text box
    public Image uiImage;   //the image box
    public Image uiFrame;    //the inage that contains the two UI object above

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void refresh()
    {
        uiTextBox.text = text;
        uiImage.sprite = image;
    }
}
