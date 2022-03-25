using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    // TextMeshProUGUI is used for text within the UI
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField   ] GameObject[] goAnswerButtons;
    void Start()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i < goAnswerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = goAnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }     
    } // Start

    
} // Quiz
