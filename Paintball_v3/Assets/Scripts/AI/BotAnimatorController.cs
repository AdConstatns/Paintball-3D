using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BotAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private Transform _stickman;
    private NavMeshAgent _agent;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _stickman = _animator.gameObject.transform;
    }

    void FixedUpdate()
    {
        _stickman.localPosition = Vector3.zero;

        Vector3 direction = _agent.transform.InverseTransformDirection(_agent.velocity);
        float forward = direction.z;
        float right = direction.x;

        _animator.SetFloat("Forward", forward);
        _animator.SetFloat("Right", right);
    }
}
