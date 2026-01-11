using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ScoreService : IScoreService
{
    public void AddScore(int score)
    {
        CurrentScore += score;
        OnScoreChanged?.Invoke(CurrentScore);
    }

    public int CurrentScore { get; set; }
    public event Action<int> OnScoreChanged;
}
