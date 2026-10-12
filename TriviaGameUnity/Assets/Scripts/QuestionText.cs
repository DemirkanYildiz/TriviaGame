using TMPro;
using UnityEngine;

public class QuestionText : MonoBehaviour
{

    [SerializeField] private TMP_Text TmpText;

    public void init(string text)
    {
        TmpText.SetText(text);
    }

}
