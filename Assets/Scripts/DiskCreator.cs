using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskCreator : MonoSingleton<DiskCreator>
{
    [SerializeField] private DiskManager diskPrefab;
    [SerializeField] private Transform diskSpawnPoint;

    public DiskManager CreateDisk(PlayerType nextTurn)
    {
        var manager = Instantiate(diskPrefab, diskSpawnPoint.position,Quaternion.identity);
        manager.SetupDisk(nextTurn);
        manager.GetComponent<DiskController>().OnDiskStop += CameraMovement.Instance.StartCameraMode;
        manager.GetComponent<DiskController>().OnDiskThrow += CameraMovement.Instance.FocusCameraMode;
        return manager;
    }
}
