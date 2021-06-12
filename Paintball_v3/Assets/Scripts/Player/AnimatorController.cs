using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    private Transform _stickman;
    

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _stickman = _animator.gameObject.transform;
    }


    void Update()
    {
        _stickman.localPosition = Vector3.zero;

        Vector3 localVelocity = _rigidbody.transform.InverseTransformDirection(_rigidbody.velocity);
        float forward = localVelocity.z / PlayerStats.Instance.RunSpeed;
        float right = localVelocity.x / PlayerStats.Instance.RunSpeed;
        

        _animator.SetFloat("Forward", forward);
        _animator.SetFloat("Right", right);

    }
}
