using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject leaderboardPanel;

    [Header("Leaderboard")]
    [SerializeField] private Transform content;
    [SerializeField] private GameObject leaderboardEntryPrefab;

    [Header("Pagination")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private TMP_Text pageText;

    [Header("API")]
    [SerializeField] private LeaderboardAPI api;

    private int currentPage = 0;

    public void OpenLeaderboard()
    {
        leaderboardPanel.SetActive(true);

        currentPage = 0;

        LoadPage(currentPage);
    }

    public void CloseLeaderboard()
    {
        leaderboardPanel.SetActive(false);
    }

    public void LoadPage(int page)
    {
        StartCoroutine(
            api.GetLeaderboard(
                page,
                OnLeaderboardLoaded,
                OnLeaderboardError
            )
        );
    }

    private void OnLeaderboardLoaded(LeaderboardResponse response)
    {
        currentPage = response.page;

        ClearLeaderboard();

        foreach (LeaderboardEntry entry in response.data)
        {
            CreateLeaderboardEntry(entry);
        }

        UpdatePagination(response);
    }

    private void CreateLeaderboardEntry(LeaderboardEntry entry)
    {
        GameObject entryObject =
            Instantiate(
                leaderboardEntryPrefab,
                content
            );

        LeaderboardEntryUI entryUI =
            entryObject.GetComponent<LeaderboardEntryUI>();

        entryUI.SetData(entry);
    }

    private void ClearLeaderboard()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    private void UpdatePagination(LeaderboardResponse response)
    {
        pageText.text = $"{response.page + 1}";

        previousButton.interactable =
            response.page > 0;

        nextButton.interactable =
            !response.is_last;
    }

    private void OnLeaderboardError(string error)
    {
        Debug.LogError($"Leaderboard Error: {error}, Note: first run the server script in the Server folder");
    }

    public void OnNextClicked()
    {
        LoadPage(currentPage + 1);
    }

    public void OnPreviousClicked()
    {
        if (currentPage > 0)
        {
            LoadPage(currentPage - 1);
        }
    }

}