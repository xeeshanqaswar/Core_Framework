using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : IEnemySpawner
{
    public void BeginSpawning()
    {
        Debug.Log("Begin Enemy Spawning!");
    }
}
