using TMPro;
using UnityEngine;

public class LeaderboardEntryUI : MonoBehaviour
{
    [SerializeField] private TMP_Text rankText;
    [SerializeField] private TMP_Text nicknameText;
    [SerializeField] private TMP_Text scoreText;

    public void SetData(LeaderboardEntry entry)
    {
        rankText.text = entry.rank.ToString();
        nicknameText.text = entry.nickname;
        scoreText.text = entry.score.ToString();
    }
}
