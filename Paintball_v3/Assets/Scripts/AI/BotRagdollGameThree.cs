using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotRagdollGameThree : MonoBehaviour
{
    [SerializeField] private Rigidbody[] allRigidbodies;
    private Animator _animator;
    private float _health;
    private NavMeshAgent _agent;
    [SerializeField] private Transform _avatar;
    [SerializeField] private Rigidbody hip;

    private Vector3 bulletVelocity;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        SwitchRagdoll(true);
    }

    private void Start()
    {
        _health = GameParams.Instance.botHealth;
    }

    private void SwitchRagdoll(bool state)
    {
        _animator.enabled = state;
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].isKinematic = state;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            bulletVelocity = other.gameObject.GetComponent<Rigidbody>().velocity;
            _health -= GameParams.Instance.playerWeaponDamage;
            if (_health <= 0) Death();
        }
    }

    private void Death()
    {
        SwitchRagdoll(false);
        hip.AddForce(bulletVelocity * 10f, ForceMode.Impulse);
        _avatar.SetParent(null);
        gameObject.SetActive(false);
        BotCounter.Instance.botCount -= 1;
    }
}
