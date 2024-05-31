using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.FilePathAttribute;
public class DiskManager : MonoBehaviour
{
    private DiskController _diskController;
    public PlayerType diskOwner = PlayerType.PLAYER;
    public Collider score1Collider, score2Collider, score3Collider;

    private void Awake()
    {
        _diskController = GetComponent<DiskController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score1"))
        {
            score1Collider = other;
        }
        else if (other.CompareTag("Score2"))
        {
            score2Collider = other;
        }
        else if (other.CompareTag("Score3"))
        {
            score3Collider = other;
        }

        if (other.CompareTag("DiskRemover"))
        {
            _diskController.DiskStopInvoker();
            Destroy(gameObject);
        }
        UpdateScore();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Score1"))
        {
            score1Collider = null;
        }
        else if (other.CompareTag("Score2"))
        {
            score2Collider = null;
        }
        else if (other.CompareTag("Score3"))
        {
            score3Collider = null;
        }
        UpdateScore();
    }

    public void SetupDisk(PlayerType diskOwner)
    {
        this.diskOwner = diskOwner;
        if(diskOwner != PlayerType.PLAYER)
        {
            GetComponent<DiskSkinLoader>().ApplySkin(DefaultProperties.Instance.DefaultDiskSkinEnemy);
        }
    }

    private void UpdateScore()
    {
        var score = 0;
      /*  if (score1Collider && score2Collider)
        {
            score = ColliderToScore(GetClosestScore(score1Collider, score2Collider));
        }
        else if (score2Collider && score3Collider)
        {
            score = ColliderToScore(GetClosestScore(score2Collider, score3Collider));
        }*/
        if (score3Collider)
        {
            score = 3;
        }
        else if (score2Collider)
        {
            score = 2;
        }
        else if (score1Collider)
        {
            score = 1;
        }

        ScoreCalculator.Instance.OnScoreUpdate(score, this);
    }

    public Collider GetClosestScore(Collider scoreA, Collider scoreB)
    {
        Vector3 closestPointA = scoreA.ClosestPoint(transform.position);
        float closestDistanceA = Vector3.Distance(closestPointA, transform.position);
        
        Vector3 closestPointB = scoreA.ClosestPoint(transform.position);
        float closestDistanceB = Vector3.Distance(closestPointB, transform.position);
        if(closestDistanceA > closestDistanceB)
        {
            return scoreB;
        }
        else
        {
            return scoreA;
        }
    }

    public int ColliderToScore(Collider collider)
    {
        if(score1Collider == collider)
        {
            return 1;
        }
        else if(score2Collider == collider) 
        {
            return 2;
        }
        else if (score3Collider == collider)
        {
            return 3;
        }
        Debug.LogError("ColliderToScore(Collider collider) collider not found!");
        return 0;
    }

}
