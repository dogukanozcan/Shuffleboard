using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoSingleton<ScoreCalculator>
{
    public float playerScore = 0;
    public float enemyScore = 0;
    public Dictionary<DiskManager, int> diskScores = new Dictionary<DiskManager, int>();
    public void OnScoreUpdate(int score, DiskManager disk)
    {
        diskScores[disk] = score;
        UpdateScores();
    }

    public void UpdateScores()
    {
        playerScore = 0;
        enemyScore = 0;
        foreach (var item in diskScores)
        {
            if (item.Key.diskOwner == PlayerType.PLAYER)
            {
                ChangePlayerScore(item.Value);
            }
            else
            {
                ChangeEnemyScore(item.Value);
            }
                
        }
    }

    public void ChangePlayerScore(int score)
    {
        playerScore += score;
        if(playerScore < 0)
        {
            playerScore = 0;
        }
    }

    public void ChangeEnemyScore(int score)
    {
        enemyScore += score;
        if(enemyScore < 0)
        {
            enemyScore = 0;
        }
    }
}
