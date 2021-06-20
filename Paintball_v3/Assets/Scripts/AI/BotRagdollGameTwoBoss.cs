using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotRagdollGameTwoBoss : MonoBehaviour
{
    [SerializeField] private Rigidbody[] allRigidbodies;
    private Animator _animator;
    public float _health;
    private NavMeshAgent _agent;
    [SerializeField] private Transform _avatar;
    private BotEnemyDetectionGameTwo BotEnemyDetectionGameTwo;
    private AiSystemGameTwo aiSystemGameTwo;





    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        SwitchRagdoll(true);
        aiSystemGameTwo = GetComponent<AiSystemGameTwo>();
    }

    private void Start()
    {
        _health = GameParams.Instance.bossHealth;
        BotEnemyDetectionGameTwo = GetComponent<BotEnemyDetectionGameTwo>();
        gameObject.SetActive(false);
    }

    private void SwitchRagdoll(bool state)
    {
        _animator.enabled = state;
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].isKinematic = state;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= GameParams.Instance.playerWeaponDamage;
            if (_health <= 0) Death();
        }
    }

    private void Death()
    {
        SwitchRagdoll(false);
        _avatar.SetParent(null);
       gameObject.SetActive(false);
     
    }

}
