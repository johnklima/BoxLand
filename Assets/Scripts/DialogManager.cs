using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    public Question currentQuestion;
    public Answer currentAnswer;

    // Start is called before the first frame update
    void Start()
    {
        //update the view with the first question, in this case of start, moveNext
        //is really "move first"
        currentQuestion.moveNext();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void answerAClicked()
    {
        Debug.Log("answerA selected");
        //first child is index 0 answer A, make it current answer
        currentAnswer = currentQuestion.transform.GetChild(0).GetComponent<Answer>();
        //the current question will now be the current answer's question
        currentQuestion = currentAnswer.transform.GetChild(0).GetComponent<Question>();
        //update view aka move to next question
        currentQuestion.moveNext();

    }
    public void answerBClicked()
    {
        Debug.Log("answer B clicked");
        //second child is index 1 answer B, make it current answer
        currentAnswer = currentQuestion.transform.GetChild(1).GetComponent<Answer>();
        //the current question will now be the current answer's question
        currentQuestion = currentAnswer.transform.GetChild(0).GetComponent<Question>();
        //update view aka move to next question
        currentQuestion.moveNext();

    }
}
