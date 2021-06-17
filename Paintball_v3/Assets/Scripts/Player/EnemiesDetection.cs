using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDetection : MonoBehaviour
{
    private Transform[] _enemiesTransforms;

    private void Awake()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _enemiesTransforms = new Transform[enemies.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            _enemiesTransforms[i] = enemies[i].transform;
        }
       
    }


    private void Update()
    {
        Transform TargetTransform;
        FindTargets(out TargetTransform);
    }


    //public bool FindTargets(out Transform targetTransform)
    //{
    //    for (int i = 0; i < _enemiesTransforms.Length; i++)
    //    {
    //        RaycastHit hit;
    //        if (Physics.Raycast(transform.position, _enemiesTransforms[i].position - transform.position, out hit, PlayerStats.Instance.ViewDistance) && hit.transform == _enemiesTransforms[i])
    //        {
    //                targetTransform = _enemiesTransforms[i];
    //                return true;    
    //        }
    //    }
    //    targetTransform = null;
    //    return false;
    //}

    public bool FindTargets(out Transform targetTransform)
    {
        var minDistance = float.MaxValue;
        targetTransform = null;

        for (int i = 0; i < _enemiesTransforms.Length; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, _enemiesTransforms[i].position - transform.position, out hit, PlayerStats.Instance.ViewDistance) && hit.transform == _enemiesTransforms[i])
            {
                var candidateTransform = _enemiesTransforms[i];
                var sqrDistance = (candidateTransform.position - transform.position).sqrMagnitude;
                if (sqrDistance < minDistance)
                {
                    minDistance = sqrDistance;
                    targetTransform = candidateTransform;
                }
            }
        }
        return targetTransform != null;
    }
}
