using System;
using System.Collections;
using System.Collections.Generic;
using UltimateProceduralPrimitivesFREE;
using UnityEngine;
public enum CameraType
{
    Start,
    Focus
}
public class CameraMovement : MonoSingletonDelay<CameraMovement>
{
    private CameraType cameraType;

    private Animator _animator;
    private void Awake()
    {
        _animator = Camera.main.GetComponent<Animator>();
    }

    public void FocusCameraMode()
    {
        Delay(() => _animator.Play(CameraType.Focus.ToString()), .25f);
    }
    public void StartCameraMode()
    {
        Delay(() => _animator.Play(CameraType.Start.ToString()), .75f);
    }
}
