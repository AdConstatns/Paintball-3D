using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTestGameThree : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bullet2;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _spawnPoint2;
    [SerializeField] private Transform _spawnPoint3;
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
        if (fillBar.FillCount >= 0.6f)
        {
            GameObject bullet = Instantiate(_bullet, _spawnPoint.position, Quaternion.identity);
            bullet.gameObject.GetComponent<CollisionPainter>().brush.splatScale = fillBar.FillCount * 7f;
            bullet.transform.localScale = Vector3.one * fillBar.FillCount * 1.2f;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * GameParams.Instance.bulletSpeed, ForceMode.Impulse);

            GameObject bullet2 = Instantiate(_bullet2, _spawnPoint2.position, Quaternion.identity);
            bullet2.gameObject.GetComponent<CollisionPainter>().brush.splatScale = fillBar.FillCount * 7f;
            bullet2.transform.localScale = Vector3.one * fillBar.FillCount * 1.2f;
            bullet2.GetComponent<Rigidbody>().AddForce(transform.forward * GameParams.Instance.bulletSpeed, ForceMode.Impulse);

            GameObject bullet3 = Instantiate(_bullet2, _spawnPoint3.position, Quaternion.identity);
            bullet3.gameObject.GetComponent<CollisionPainter>().brush.splatScale = fillBar.FillCount * 7f;
            bullet3.transform.localScale = Vector3.one * fillBar.FillCount * 1.2f;
            bullet3.GetComponent<Rigidbody>().AddForce(transform.forward * GameParams.Instance.bulletSpeed, ForceMode.Impulse);



            GameParams.Instance.playerWeaponDamage = GameParams.Instance.botHealth * 1.5f * fillBar.FillCount;

        }
        else
        {
            GameObject bullet = Instantiate(_bullet, _spawnPoint.position, Quaternion.identity);
            bullet.gameObject.GetComponent<CollisionPainter>().brush.splatScale = fillBar.FillCount * 7f;
            bullet.transform.localScale = Vector3.one * fillBar.FillCount * 1.2f;
            GameParams.Instance.playerWeaponDamage = GameParams.Instance.botHealth * 1.5f * fillBar.FillCount;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * GameParams.Instance.bulletSpeed, ForceMode.Impulse);
        }
    }


}
