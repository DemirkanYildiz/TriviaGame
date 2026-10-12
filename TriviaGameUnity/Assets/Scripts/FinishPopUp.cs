using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishPopUp : MonoBehaviour
{

    [SerializeField] private TMP_Text ScoreText;

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void SetScore(int score)
    {
        ScoreText.text = $"Score: {score}";
    }
    
    public void OnOkClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
