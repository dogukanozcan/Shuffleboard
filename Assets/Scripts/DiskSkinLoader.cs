using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskSkinLoader : MonoBehaviour
{
    [SerializeField] private MeshRenderer diskTop;
    [SerializeField] private MeshRenderer diskBottom;

    private void Start()
    {
        
    }
  
    public void LoadDefaultSkin()
    {
        var defaultSkin = DefaultProperties.Instance.DefaultDiskSkin;
        if (defaultSkin == null)
            return;

        ApplySkin(defaultSkin);
    }

    public void ApplySkin(DiskSkinSO skin) 
    {
        if(diskTop == null || diskBottom == null)
            return;

        diskTop.material = skin.topMat;
        diskBottom.material = skin.bottomMat;
    }
}
