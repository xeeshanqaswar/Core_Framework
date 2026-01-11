using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class GameManager: IStartable
{
    private readonly IEnemySpawner _enemySpawner;
    private readonly IPlayerService _playerService;
    
    public GameManager(IEnemySpawner enemySpawner, IPlayerService playerService)
    {
        _enemySpawner = enemySpawner;
        _playerService = playerService;
    }
    
    public void Start()
    {
        _playerService.SpawnPlayer();
        _enemySpawner.BeginSpawning();
    }
}
