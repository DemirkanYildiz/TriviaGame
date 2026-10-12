using UnityEngine;
using TMPro;
using System;

public class QuestionPanel : MonoBehaviour
{

    [SerializeField] TMP_Text QuestionNumber, Score;

    [SerializeField] GameManager GameManager;

    public void UpdateUI()
    {
        QuestionNumber.SetText((GameManager.QuestionIndex).ToString());
        Score.SetText(GameManager.CurrentScore.ToString());
    }
    

}
