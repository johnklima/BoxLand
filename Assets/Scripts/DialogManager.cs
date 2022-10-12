using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DialogManager : MonoBehaviour
{
    const int FIRST_CHILD = 0;

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

   
    public void answerClicked(int whichAnswer)
    {
        currentAnswer = currentQuestion.transform.GetChild(whichAnswer).GetComponent<Answer>();
        //the current question will now be the current answer's question
        currentQuestion = currentAnswer.transform.GetChild(FIRST_CHILD).GetComponent<Question>();
        //update view aka move to next question
        currentQuestion.moveNext();
    }
}
