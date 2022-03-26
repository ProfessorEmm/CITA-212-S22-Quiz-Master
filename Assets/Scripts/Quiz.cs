using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    // TextMeshProUGUI is used for text within the UI
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField   ] GameObject[] goAnswerButtons;
    int intCorrectAnswerIndex;
    [SerializeField] Sprite sprDefaultAnswerSprite;
    [SerializeField] Sprite sprCorrectAnswerSprite; 
    void Start()
    {
       GetNextQuestion(); 
       // DisplayQuestion();
    } // Start


    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        if(index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = goAnswerButtons[index].GetComponent<Image>();
            buttonImage.sprite = sprCorrectAnswerSprite;
        }
        else
        {
            intCorrectAnswerIndex = question.GetCorrectAnswerIndex();
            string strCorrectAnswer = question.GetAnswer(intCorrectAnswerIndex);
            questionText.text = "Sorry, the correct answer was \n" + strCorrectAnswer;
            buttonImage = goAnswerButtons[intCorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = sprCorrectAnswerSprite;
        }

        SetButtonState(false);
    } // OnAnswerSelected()

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    } // GetNextQuestion()

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i < goAnswerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = goAnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    } // DisplayQuestion()

    void SetButtonState(bool blState)
    {
        for(int i = 0; i < goAnswerButtons.Length; i++)
        {
            Button btnButton = goAnswerButtons[i].GetComponent<Button>();
            btnButton.interactable = blState;
        }
    } // SetButtonState

    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < goAnswerButtons.Length; i++)
        {
            Image buttonImage = goAnswerButtons[i].GetComponent<Image>();
            buttonImage.sprite = sprDefaultAnswerSprite;
        }
    }

    
} // Quiz
