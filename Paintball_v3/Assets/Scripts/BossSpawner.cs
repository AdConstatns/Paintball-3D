using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private BotCounter botCounter;
    [SerializeField] private GameObject Boss;

    private bool check = true;
    private void Update()
    {
        if (botCounter.botCount <= 0 && check)
        {
            Boss.SetActive(true);
            check = false;
        }
    }


}
