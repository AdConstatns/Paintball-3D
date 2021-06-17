using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinPoints : MonoBehaviour
{
    public List<Transform> JoinList = new List<Transform>();
    public static JoinPoints Instance;

    private void Awake()
    {
        Instance = this;

        GameObject[] join = GameObject.FindGameObjectsWithTag("join");

        for (int i = 0; i < join.Length; i++)
        {
            JoinList.Add(join[i].transform);
        }
    }

}
