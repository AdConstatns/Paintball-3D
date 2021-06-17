using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerGameTwo : MonoBehaviour
{
    private FloatingJoystick _joystic;
    private Rigidbody _player;
    private Transform Target;
    private EnemiesDetectionGameTwo enemiesDetection;

    private void Start()
    {
        _player = GetComponent<Rigidbody>();
        enemiesDetection = gameObject.GetComponent<EnemiesDetectionGameTwo>();
        _joystic = GameObject.FindGameObjectWithTag("Joystic").GetComponent<FloatingJoystick>();
    }

    private void Update()
    {
        //DrawTargetLine();
    }

    private void FixedUpdate()
    {
        Transform TargetTransform;
        if (_joystic.Horizontal != 0 && _joystic.Vertical != 0)
        {
            _player.velocity = new Vector3(_joystic.Horizontal * PlayerStats.Instance.RunSpeed, _player.velocity.y, _joystic.Vertical * PlayerStats.Instance.RunSpeed);
            Quaternion rotation = Quaternion.LookRotation(_player.velocity.normalized);
            if (enemiesDetection.FindTargets(out TargetTransform))
            {
                RotateToTarget();
                Target = TargetTransform;
            }
            else _player.MoveRotation(Quaternion.Slerp(_player.rotation, rotation, PlayerStats.Instance.RotationSpeed * Time.deltaTime));
        }
        if (enemiesDetection.FindTargets(out TargetTransform))
        {
            RotateToTarget();
            Target = TargetTransform;
        }

    }


    private void RotateToTarget()
    {
        if (Target != null)
        {
            Vector3 lookVector = Target.position - transform.position;
            lookVector.y = 0;
            if (lookVector == Vector3.zero) return;
            Quaternion rotation = Quaternion.LookRotation(lookVector, Vector3.up);
            _player.MoveRotation(Quaternion.Slerp(_player.rotation, rotation, PlayerStats.Instance.RotationSpeed * Time.deltaTime));
        }
    }

    private void DrawTargetLine()
    {
        if (Target != null) Debug.DrawLine(transform.position, Target.position, Color.red);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, PlayerStats.Instance.ViewDistance);
    //}


}
