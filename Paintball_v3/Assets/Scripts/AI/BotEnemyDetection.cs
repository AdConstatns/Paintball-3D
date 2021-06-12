using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotEnemyDetection : MonoBehaviour
{
    [SerializeField] private Transform[] _enemiesTransforms;

    private void Awake()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _enemiesTransforms = new Transform[enemies.Length + 1];

        for (int i = 0; i < enemies.Length; i++)
        {
            _enemiesTransforms[i] = enemies[i].transform;
        }
  
    }

    private void Start()
    {
        _enemiesTransforms[_enemiesTransforms.Length -1] = PlayerStats.Instance.gameObject.transform;
    }

    private void Update()
    {
        Transform TargetTransform;
        FindTargets(out TargetTransform);
    }


    public bool FindTargets(out Transform targetTransform)
    {
        for (int i = 0; i < _enemiesTransforms.Length; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, _enemiesTransforms[i].position - transform.position, out hit, PlayerStats.Instance.ViewDistance))
            {
                if (Vector3.Distance(transform.position, _enemiesTransforms[i].position) <= PlayerStats.Instance.ViewDistance && hit.transform == _enemiesTransforms[i])
                {
                    targetTransform = _enemiesTransforms[i];
                    return true;
                }
            }
        }
        targetTransform = null;
        return false;
    }
}
