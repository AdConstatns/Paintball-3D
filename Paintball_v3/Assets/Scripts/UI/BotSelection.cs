using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSelection : MonoBehaviour
{
    [SerializeField] private EnemiesDetection _enemiesDetection;
    [SerializeField] private Transform _selector;
    [SerializeField] private CanvasGroup _selectorCanvas;

    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }



    private void LateUpdate()
    {
        Transform TargetTransform;
        if (_enemiesDetection.FindTargets(out TargetTransform))
        {
            _selectorCanvas.alpha = 1;
            _selector.position = mainCam.WorldToScreenPoint(TargetTransform.position);
        }
        else _selectorCanvas.alpha = 0;
    }

}
