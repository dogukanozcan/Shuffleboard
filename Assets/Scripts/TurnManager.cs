using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoSingleton<TurnManager>
{
    public PlayerType currentTurn = PlayerType.PLAYER;

    private void Start()
    {
        StartTurn();
    }
    public void StartTurn()
    {
        var nextDisk = DiskCreator.Instance.CreateDisk(currentTurn);
        nextDisk.GetComponent<DiskController>().OnDiskStop += ChangeTurn;
    }

    public void ChangeTurn()
    {
        if(currentTurn == PlayerType.PLAYER)
        {
            currentTurn = PlayerType.ENEMY;
        }
        else
        {
            currentTurn = PlayerType.PLAYER;
        }
        StartTurn();
    }
}
