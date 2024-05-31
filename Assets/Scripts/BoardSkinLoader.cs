using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardSkinLoader : MonoBehaviour
{
    [SerializeField] private MeshRenderer bodyMesh;
    [SerializeField] private MeshRenderer borderMesh;
    [SerializeField] private MeshRenderer[] stripeMeshs;


    private void Start()
    {
        LoadDefaultSkin();
    }
    
    public void LoadDefaultSkin()
    {
        var defaultSkin = DefaultProperties.Instance.DefaultBoardSkin;
        if (defaultSkin == null)
            return;

        ApplySkin(defaultSkin);
    }

    public void ApplySkin(BoardSkinSO skin)
    {
        if (borderMesh == null || bodyMesh == null || stripeMeshs.Length == 0)
            return;

        bodyMesh.material = skin.bodyMat;
        borderMesh.material = skin.borderMat;
        foreach (var item in stripeMeshs)
        {
            item.material = skin.stripeMat;
        }
    }
  

}
