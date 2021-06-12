using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTest : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float shootDelay;        

    private EnemiesDetection _enemiesDetection;

    private bool gun = true;

    private void Start()
    {
        _enemiesDetection = GetComponent<EnemiesDetection>();
    }

    private void FixedUpdate()
    {
        Transform enemy;
        if(_enemiesDetection.FindTargets(out enemy)) StartGun();
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
