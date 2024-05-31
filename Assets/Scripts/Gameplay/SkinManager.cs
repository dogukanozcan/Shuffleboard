using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoSingleton<SkinManager>
{
    #region DiskSkin
    public List<DiskSkinSO> diskSkins = new();

    public DiskSkinSO currentDiskSkin = null;


    public void UpdateDiskSkin(DiskSkinSO nextDiskSkin)
    {
        var allDisk = FindObjectsOfType<DiskSkinLoader>();
        foreach (var disk in allDisk) 
        {

        }
    }


    #endregion

    #region BoardSkin

    public List<BoardSkinSO> boardSkins = new();


    #endregion



    public void Start()
    {
        currentDiskSkin = DefaultProperties.Instance.DefaultDiskSkin;
    }


}
