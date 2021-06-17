using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject smallBullets;
    [SerializeField] private Transform spawn;


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(smallBullets, spawn.position, Quaternion.identity, null);
        
    }
}
