using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotRagdollGameTwo : MonoBehaviour
{
    [SerializeField] private Rigidbody[] allRigidbodies;
    private Animator _animator;
    public float _health;
    private NavMeshAgent _agent;
    [SerializeField] private Transform _avatar;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Renderer _renderer;
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
        _health = GameParams.Instance.botHealth;
        BotEnemyDetectionGameTwo = GetComponent<BotEnemyDetectionGameTwo>();
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
            if (_health <= 0) JoinPlayer();
        }
    }

    private void Death()
    {
        SwitchRagdoll(false);
        _avatar.SetParent(null);
        gameObject.SetActive(false);
     
    }

    private void JoinPlayer()
    {
        BotCounter.Instance.botCount -= 1;
        gameObject.tag = "Friend";
        _renderer.material = _greenMaterial;
        _health = GameParams.Instance.botHealth;
        BotEnemyDetectionGameTwo.enemiesTransforms.Clear();
        BotEnemyDetectionGameTwo.AddBotsToList();
        aiSystemGameTwo.JoinToPlayer();
    }
}
