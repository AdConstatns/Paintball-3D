using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShootingGameTwo : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float shootDelay;
    private BotEnemyDetectionGameTwo _botEnemyDetection;
    private bool gun = true;
    private void Start()
    {
        _botEnemyDetection = GetComponent<BotEnemyDetectionGameTwo>();
    }

    private void FixedUpdate()
    {
        Transform enemy;
        if (_botEnemyDetection.FindTargets(out enemy)) StartGun();
    }

    private void StartGun()
    {
        if (gun)
        {
            GameObject bullet = Instantiate(_bullet, _spawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * GameParams.Instance.bulletSpeed, ForceMode.Impulse);
            gun = false;
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(shootDelay);
        gun = true;
    }
}
