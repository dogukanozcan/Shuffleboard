using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Board Skin", menuName = "Skins/Board Skin")]
public class BoardSkinSO : ScriptableObject
{
    public string skinName;
    public Material bodyMat;
    public Material borderMat;
    public Material stripeMat;
}
