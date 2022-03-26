using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float fltTimeToCompleteQuestion = 30f;
    [SerializeField] float fltTimeToShowCorrectAnswer = 10f;

    public bool blLoadNextQuestion;
    public float fltFillFraction; 
    
    public bool blIsAnsweringQuestion;
    float fltTimerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        fltTimerValue = 0f;
    }

    void UpdateTimer()
    {
        fltTimerValue -= Time.deltaTime;

        // check whether we're showing a question or an answer
        if (blIsAnsweringQuestion)
        {
            // do we have any time remaining?
            if (fltTimerValue > 0)
            {
                fltFillFraction = fltTimerValue / fltTimeToCompleteQuestion;
            }
            else  // no time remaining
            {
                blIsAnsweringQuestion = false;
                fltTimerValue = fltTimeToShowCorrectAnswer;
            }
        }
        else  // showing an answer
        {
            // do we have any time remaining?
            if (fltTimerValue > 0)
            {
                fltFillFraction = fltTimerValue / fltTimeToShowCorrectAnswer;
            }
            else  // no time remaining
            {
                blIsAnsweringQuestion = true;
                fltTimerValue = fltTimeToCompleteQuestion;
                blLoadNextQuestion = true;
            }
        }

    }
}
