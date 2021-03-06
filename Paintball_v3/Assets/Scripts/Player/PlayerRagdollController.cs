using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollController : MonoBehaviour
{
    [SerializeField] private Rigidbody[] allRigidbodies;
    private Animator _animator;
    private float _health;
    [SerializeField] private Transform _avatar;
    [SerializeField] private Rigidbody _hip;
    [SerializeField] private GunTestGameThree gunTest;
    [SerializeField] private GameObject fillBar;



    private Vector3 bulletVelocity;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        SwitchRagdoll(true);
    }

    private void Start()
    {
        _health = GameParams.Instance.playerHealth;
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
            bulletVelocity = collision.gameObject.GetComponent<Rigidbody>().velocity;
            _health -= GameParams.Instance.botWeaponDamage;
            if (_health <= 0) Death();
        }
    }

    private void Death()
    {
        SwitchRagdoll(false);
        _hip.AddForce(bulletVelocity * 20f, ForceMode.Impulse);
        _avatar.SetParent(null);
        gameObject.SetActive(false);
        gunTest.enabled = false;


    }

}
