using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Enemy"))
        {
            _particles.Play();
        }
    }
}
