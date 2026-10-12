using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{

    [SerializeField] TMP_Text answerName, answerText;

    [SerializeField] Image image;

    [SerializeField] Color correctColor, wrongColor;

    QuestionUI questionUI;
    int btnIndex;

    public void init(string answerText, string answerName, int btnIndex, QuestionUI questionUI)
    {
        this.answerText.SetText(answerText);
        this.answerName.SetText(answerName);
        this.questionUI = questionUI;
        this.btnIndex = btnIndex;
    }

    public void OnClick()
    {
        questionUI.SelectAnswer(btnIndex);
    }

    public void SetCorrect()
    {
        image.color = correctColor;
    }

    public void SetWrong()
    {
        image.color = wrongColor;
    }

}
