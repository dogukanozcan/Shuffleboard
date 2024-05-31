using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Disk Skin", menuName = "Skins/Disk Skin")]
public class DiskSkinSO : ScriptableObject
{
    public string skinName;

    [Header("Player 1")]
    public Material topMat;
    public Material bottomMat;
}
