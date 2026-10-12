using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int CurrentScore { get; private set; } = 0;

    [SerializeField] float timePerQuestion;
    [SerializeField] int wrongAnswerScore;
    [SerializeField] int correctAnswerScore;
    [SerializeField] int outOfTimeScore;
    [SerializeField] TMP_Text timer;
    [SerializeField] QuestionUI questionUI;
    [SerializeField] QuestionPanel questionPanel;

    [SerializeField] FinishPopUp finishPopUp;

    public int QuestionIndex { get; private set; } = 0;
    QuestionData QuestionData;
    private float CurrentTime;

    public bool IsWaiting { get; private set; }

    public void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Questions/questions");
        QuestionData = JsonUtility.FromJson<QuestionData>(jsonFile.text);
        LoadNextQuestion();
    }

    public void CorrectAnswer()
    {
        CurrentScore += correctAnswerScore;
        StartCoroutine(NextQuestionDelay());
    }

    public void WrongAnswer()
    {
        CurrentScore += wrongAnswerScore;
        StartCoroutine(NextQuestionDelay());
    }

    public void OutOfTime()
    {
        CurrentScore += outOfTimeScore;
        questionUI.ShowCorrectAnswer();
        StartCoroutine(NextQuestionDelay());
    }

    public IEnumerator NextQuestionDelay()
    {

        IsWaiting = true;

        yield return new WaitForSeconds(3f);

        LoadNextQuestion();
    }

    public void LoadNextQuestion()
    {
        CurrentTime = timePerQuestion;
        if(QuestionIndex >= QuestionData.questions.Length)
        {
            //show game finish screen.
            IsWaiting = true;
            finishPopUp.SetScore(CurrentScore);
            finishPopUp.Activate();
            return;
        }
        Question currentQuestion = QuestionData.questions[QuestionIndex];
        questionUI.ShowQuestion(currentQuestion);
        QuestionIndex++;
        questionPanel.UpdateUI();
        IsWaiting = false;
    }

    public void Update()
    {
        if (IsWaiting) { return; }
        CurrentTime -= Time.deltaTime;
        timer.SetText(CurrentTime.ToString("F0"));
        if (CurrentTime < 0)
        {
            OutOfTime();
        }
    }

}
