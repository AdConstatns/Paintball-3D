using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystic;
    [SerializeField] private Image _fillBar;
    [SerializeField] private GameObject bg;
    [SerializeField] private Transform player;
    [SerializeField] private Transform fillbar;
    [SerializeField] private GunTestGameThree gunTestGameThree;

    
    public event Action OnGun;


    private Camera mainCam;
    private bool afterFill = false;


    [SerializeField] private float timeFill;

    public float FillCount = 0;


    private void Awake()
    {
        mainCam = Camera.main;
    }
    private void Update()
    {
        fillbar.position = mainCam.WorldToScreenPoint(player.position);
        if (bg.active)
        {
            FillCount += timeFill * Time.deltaTime;
            if (FillCount > 1) FillCount = 1;
            afterFill = true;
        }
        else if (!bg.active && afterFill)
        {
            gunTestGameThree.gun = true;
            afterFill = false;
            OnGun?.Invoke();
            FillCount = 0;
            
        }
        _fillBar.fillAmount = FillCount;
    }
  
}
