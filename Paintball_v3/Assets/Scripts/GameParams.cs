using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParams : MonoBehaviour
{
    public static GameParams Instance;

    public float botHealth = 20f;
    public float playerWeaponDamage = 1f;
    public float playerHealth = 20f;
    public float botWeaponDamage = 1f;
    public float bulletSpeed = 30f;

    private void Awake()
    {
        Instance = this;
    }
}
