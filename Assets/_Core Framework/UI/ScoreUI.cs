using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using VContainer;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    private IScoreService _scoreService;

    [Inject]
    public void Constructor(IScoreService scoreService)
    {
        _scoreService = scoreService;
        _scoreService.OnScoreChanged += UpdateScore;
    }

    private void UpdateScore(int score)
    {
        scoreText.text = score.ToString();   
    }

    private void OnDestroy()
    {
        _scoreService.OnScoreChanged -= UpdateScore;   
    }
}
