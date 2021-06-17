using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticlesGameThree : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private MeshRenderer meshRenderer;




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Enemy"))
        {
            _particles.gameObject.transform.SetParent(null);
            _particles.Play();
            meshRenderer.enabled = false;
        }
    }
}
