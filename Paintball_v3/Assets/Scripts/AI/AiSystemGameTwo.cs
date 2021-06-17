using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSystemGameTwo : MonoBehaviour
{
    [SerializeField]  private Transform[] _shelters;
    public Transform Destination;
    [SerializeField] private Transform playerJoin;
    [SerializeField] private JoinPoints joinPoints;



    [Range(1f, 20f), SerializeField] private int minDelay = 2;
    [Range(1f, 20f), SerializeField] private int maxDelay = 10;



    private void Awake()
    {

        GameObject[] shelters = GameObject.FindGameObjectsWithTag("Shelter");
        _shelters = new Transform[shelters.Length];

        for (int i = 0; i < _shelters.Length; i++)
        {
            _shelters[i] = shelters[i].transform;
        }

    }

    private void Start()
    {
        SetDestinationPoint(_shelters);
    }

    private void SetDestinationPoint(Transform[] shelters)
    {
        Destination = shelters[Random.Range(0, shelters.Length)];
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        SetDestinationPoint(_shelters);
    }

    public void JoinToPlayer()
    {
        Transform toDelete = null;
        StopAllCoroutines();
        if (JoinPoints.Instance.JoinList.Count > 0)
        {
            Destination = JoinPoints.Instance.JoinList[0];
            JoinPoints.Instance.JoinList.RemoveAt(0);
        }

    }

}
