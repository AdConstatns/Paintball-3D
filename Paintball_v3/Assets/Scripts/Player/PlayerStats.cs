using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float RunSpeed;
    public float RotationSpeed;
    public float ViewDistance;
    public static PlayerStats Instance;

    private void Awake()
    {
        Instance = this;
    }

}
