using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProperties : MonoSingleton<DefaultProperties>
{
    [SerializeField] private BoardSkinSO defaultBoardSkin;
    [SerializeField] private DiskSkinSO defaultDiskSkin;
    [SerializeField] private DiskSkinSO defaultDiskSkinEnemy;

    public BoardSkinSO DefaultBoardSkin { get { return defaultBoardSkin; } }
    public DiskSkinSO DefaultDiskSkin { get { return defaultDiskSkin; } }
    public DiskSkinSO DefaultDiskSkinEnemy { get { return defaultDiskSkinEnemy; } }
  
}
