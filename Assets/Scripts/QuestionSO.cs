using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    // attribute TextArea allows us to adjust and control the size of the text box in the Inspector
    [TextArea(2,6)] 
   //SerializeField allows us to access this in the Inspector, but not access it form other scripts
   [SerializeField] string strQuestion = "Enter new question text here.";

   [SerializeField] int intCorrectAnswerIndex;

   // where we will store our answers
   [SerializeField] string[] strAnswers = new string[4];

   public string GetQuestion()
   {
       return strQuestion;
   } // GetQuestionSO()

   public int GetCorrectAnswerIndex()
   {
       return intCorrectAnswerIndex;
   } // GetCorrectAnswerIndex

    public string GetAnswer(int intIndex )
    {
        return strAnswers[intIndex]; 
    }

   
} // QuestionSO
