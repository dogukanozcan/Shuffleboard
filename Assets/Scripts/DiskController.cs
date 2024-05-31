using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DiskController : MonoBehaviour
{

    [SerializeField] private float diskSpeed = 2f;
    public bool Stopped => _rigidbody.velocity.magnitude > 0.01f;
    public Action OnDiskStop;
    public Action OnDiskThrow;

    private Rigidbody _rigidbody;
    private Vector3 _startPos;
    private bool _throwed = false;
    private DiskManager _diskManager;

    private void Awake()
    {
        _diskManager = GetComponent<DiskManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _throwed = false;
    }

    private void Update()
    {
        if (!CanMove()) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            MovementStart();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            OnMovement();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Push(MovementEnd());
        }
    }

    public void Push(Vector3 force)
    {
        if (force.magnitude < 5f * diskSpeed)
            return;

        OnDiskThrow?.Invoke();
        OnDiskThrow = null;
        _throwed = true;

        force *= -1 * diskSpeed; 
        _rigidbody.AddForce(new Vector3(force.x,0,force.y), ForceMode.Force);
        StartCoroutine(StoppedCheck());
    }
    public IEnumerator StoppedCheck()
    {
        yield return new WaitUntil(() => _rigidbody.velocity.magnitude > 0.01f);
        yield return new WaitUntil(() => _rigidbody.velocity.magnitude < 0.01f);
        DiskStopInvoker();
    }

    public void DiskStopInvoker()
    {
        OnDiskStop?.Invoke();
        OnDiskStop = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }
    private void OnCollisionExit(Collision collision)
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
    }

    #region Movement
    private void MovementStart()
    {
        _startPos = Input.mousePosition;
    }
    private void OnMovement()
    {
      
    }

    private Vector3 MovementEnd()
    {
        var dir = _startPos - Input.mousePosition;
        return dir;
    }

    public bool CanMove()
    {
        if (_throwed || TurnManager.Instance.currentTurn != _diskManager.diskOwner)
            return false;

        return true;
    }
    #endregion

}
