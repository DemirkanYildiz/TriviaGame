using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardAPI : MonoBehaviour
{
    private const string BASE_URL = "http://localhost:8080/leaderboard";

    public IEnumerator GetLeaderboard(
        int page,
        Action<LeaderboardResponse> onSuccess,
        Action<string> onError)
    {
        string url = $"{BASE_URL}?page={page}";

        using UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            onError?.Invoke(request.error);
            yield break;
        }

        string json = request.downloadHandler.text;

        Debug.Log($"Leaderboard Response: {json}");

        try
        {
            LeaderboardResponse response =
                JsonUtility.FromJson<LeaderboardResponse>(json);

            onSuccess?.Invoke(response);
        }
        catch (Exception e)
        {
            onError?.Invoke(
                $"Failed to parse leaderboard JSON: {e.Message}"
            );
        }
    }
}