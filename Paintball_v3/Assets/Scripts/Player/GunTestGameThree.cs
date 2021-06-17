using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTestGameThree : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private FillBar fillBar;



    private EnemiesDetection _enemiesDetection;

    public bool gun = false;

    private void Start()
    {
        _enemiesDetection = GetComponent<EnemiesDetection>();
        fillBar.OnGun += StartGun;
    }

    private void StartGun()
    {
        GameObject bullet = Instantiate(_bullet, _spawnPoint.position, Quaternion.identity);
        bullet.gameObject.GetComponent<CollisionPainter>().brush.splatScale = fillBar.FillCount * 7f;
        bullet.transform.localScale = Vector3.one * fillBar.FillCount * 2;
        GameParams.Instance.playerWeaponDamage = GameParams.Instance.botHealth * 1.5f * fillBar.FillCount;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * GameParams.Instance.bulletSpeed, ForceMode.Impulse);
    }


}
