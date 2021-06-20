using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotEnemyDetectionGameTwoBoss : MonoBehaviour
{
    public List<Transform> enemiesTransforms;

    private void Start()
    {
        enemiesTransforms.Add(PlayerStats.Instance.gameObject.transform);
    }

    private void Update()
    {
        Transform TargetTransform;
        FindTargets(out TargetTransform);
    }


    public bool FindTargets(out Transform targetTransform)
    {
        for (int i = 0; i < enemiesTransforms.Count; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, enemiesTransforms[i].position - transform.position, out hit, PlayerStats.Instance.ViewDistance))
            {
                if (Vector3.Distance(transform.position, enemiesTransforms[i].position) <= PlayerStats.Instance.ViewDistance && hit.transform == enemiesTransforms[i])
                    
                {
                    targetTransform = enemiesTransforms[i];
                    return true;
                }
            }
        }
        targetTransform = null;
        return false;
    }

    public void AddBotsToList()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            enemiesTransforms.Add(enemies[i].transform);
        }
    }
}
