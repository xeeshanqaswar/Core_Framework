using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IScoreService 
{
    void AddScore(int score);
    int CurrentScore { get; set; }
    event Action<int> OnScoreChanged;
}
