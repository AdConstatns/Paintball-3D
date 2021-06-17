using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCounter : MonoBehaviour
{
    public static BotCounter Instance;
    public float botCount = 5;
    [SerializeField] private GameObject Next;


    private void Awake()
    {
        Instance = this;
        Next.SetActive(false);
        PaintTarget.ClearAllPaint();
    }

    private void Update()
    {
        if (botCount <= 0)
        {
            Next.SetActive(true);
        }
    }

}
