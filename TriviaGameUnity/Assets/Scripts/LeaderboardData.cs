using System;
using System.Collections.Generic;

[Serializable]
public class LeaderboardEntry
{
    public int rank;
    public string nickname;
    public int score;
}

[Serializable]
public class LeaderboardResponse
{
    public int page;
    public bool is_last;
    public List<LeaderboardEntry> data;
}