using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST
{
    public static string test = "";
    static TEST()
    {
        test = "static";
        Debug.Log("static");
    }
    public TEST()
    {
        test = "public";
        Debug.Log(test);
    }
}
public class UniTaskTest : MonoBehaviour
{
 
    public Transform disk;
    private void Start()
    {
        _ = new TEST();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            TestTask().Forget();
        }
    }

    public async UniTaskVoid TestTask()
    {
        await UniTask.Yield();
        print("test1");
        await UniTask.DelayFrame(100);
        print("frame100");
        var task = disk.DOMoveZ(disk.position.z + 5f, 2f).SetEase(Ease.InOutQuint).ToUniTask();
        _ = disk.DOMoveY(disk.position.y + 5f, 4f).SetEase(Ease.InOutQuint);
        await UniTask.WhenAll(task);
        print("Tween1Done");
    }
}
