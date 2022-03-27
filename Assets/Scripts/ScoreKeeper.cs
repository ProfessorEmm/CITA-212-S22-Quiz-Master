using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int intCorrectAnswers = 0;
    int intQuestionsSeen = 0;


    // Two different ways of allowing editing/visibility are using 'public' and 
    // the user of 'getters' and 'setters'. Public access allows editing and exposure to
    // unwanted change. Getters and setters allow more control over access
    // and allows validation checks to be made.
    public int GetCorrectAnswer() // getter method
    {
        return intCorrectAnswers;
    }

    public void IncrementCorrrectAnswers() // setter method
    {
        intCorrectAnswers++;
    }

    public int GetQuestionSeen() // getter method
    {
        return intQuestionsSeen;
    }

    public void IncrementQuestionSeen() // setter method
    {
        intQuestionsSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(intCorrectAnswers / (float)intQuestionsSeen * 100);
    }

} // ScoreKeeper