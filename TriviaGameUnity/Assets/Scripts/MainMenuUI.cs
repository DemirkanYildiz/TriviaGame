using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] private LeaderboardUI leaderboardUI;

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnLeaderboardClicked()
    {
        leaderboardUI.OpenLeaderboard();
    }

}
