using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class QuestionUI : MonoBehaviour
{

    [SerializeField] private GameObject AnswerButtonPrefab;
    [SerializeField] private TMP_Text QuestionText;
    [SerializeField] private Transform ButtonParentTransform;
    [SerializeField] private TMP_Text QuestionCategory;
    [SerializeField] private GameManager GameManager;
    private Question CurrentQuestion;
    private List<AnswerButton> buttons;
    private int correctIndex;

    public void Awake()
    {
        buttons = new List<AnswerButton>();
    }

    public void ShowQuestion(Question question)
    {
        CurrentQuestion = question;
        ClearButtons();
        GenerateButtons(question.choices);
        QuestionCategory.SetText(question.category);
        QuestionText.SetText(question.question);
    }

    public void GenerateButtons(string[] choices)
    {
        int i = 0;
        foreach(string answer in choices)
        {
            int separatorIndex = answer.IndexOf(')');

            string option = answer.Substring(0, separatorIndex).Trim();
            string text = answer.Substring(separatorIndex + 1).Trim();

            GameObject answerBtn = Instantiate(AnswerButtonPrefab,ButtonParentTransform);
            AnswerButton abcomp = answerBtn.GetComponent<AnswerButton>();
            abcomp.init(text, option, i, this);
            buttons.Add(abcomp);
            if(option == CurrentQuestion.answer)
            {
                correctIndex = i;
            }
            i++;
        }
    }

    public void ClearButtons()
    {
        foreach (Transform child in ButtonParentTransform)
        {
            Destroy(child.gameObject);
        }
        buttons.Clear();
    }

    public void SelectAnswer(int selectedIndex)
    {
        if (GameManager.IsWaiting) { return; }
        if(selectedIndex == correctIndex)
        {
            GameManager.CorrectAnswer();
            buttons[selectedIndex].SetCorrect();
        }
        else
        {
            GameManager.WrongAnswer();
            buttons[selectedIndex].SetWrong();
            buttons[correctIndex].SetCorrect();
        }
    }

    public void ShowCorrectAnswer()
    {
        buttons[correctIndex].SetCorrect();
    }
    
}
