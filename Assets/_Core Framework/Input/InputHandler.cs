using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class InputHandler : MonoBehaviour
{
    private IScoreService _scoreService;

    [Inject]
    public void Constructor(IScoreService scoreService)
    {
        _scoreService = scoreService;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _scoreService.AddScore(1);
        }
    }
}
