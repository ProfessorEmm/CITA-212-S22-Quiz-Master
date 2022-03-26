using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    // TextMeshProUGUI is used for text within the UI
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;

    [Header("Answers")]
    [SerializeField   ] GameObject[] goAnswerButtons;
    int intCorrectAnswerIndex;
    bool blHasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite sprDefaultAnswerSprite;
    [SerializeField] Sprite sprCorrectAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion(); 
       // DisplayQuestion();
    } // Start

    void Update()
    {
        timerImage.fillAmount = timer.fltFillFraction;
        if (timer.blLoadNextQuestion)
        {
            blHasAnsweredEarly = false;
            GetNextQuestion();
            timer.blLoadNextQuestion = false;
        }
        else if (!blHasAnsweredEarly && ! timer.blIsAnsweringQuestion)
        {
            DisplayAnswer(-1 );
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        blHasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();  // Once we've selected an answer, we want to 
                              // put it into it's next state
    } // OnAnswerSelected()

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())
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

    } // Display Answer()

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
