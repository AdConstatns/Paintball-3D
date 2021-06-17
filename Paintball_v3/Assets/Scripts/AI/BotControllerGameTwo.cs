using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotControllerGameTwo : MonoBehaviour
{
    private NavMeshAgent _agent;
    private AiSystemGameTwo _aiSystem;
    [SerializeField] private Transform _target;
    private Transform Target;
    private Rigidbody _bot;
    private BotEnemyDetectionGameTwo _botEnemyDetection;


    private void Start()
    {
        _aiSystem = GetComponent<AiSystemGameTwo>();
        _agent = GetComponent<NavMeshAgent>();
        _bot = GetComponent<Rigidbody>();
        _botEnemyDetection = GetComponent<BotEnemyDetectionGameTwo>();

    }

    private void Update()
    {
        _agent.SetDestination(_aiSystem.Destination.position);
   
    }

    private void FixedUpdate()
    {
        Transform TargetTransform;
        if (_botEnemyDetection.FindTargets(out TargetTransform))
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
            _bot.MoveRotation(Quaternion.Slerp(_bot.rotation, rotation, PlayerStats.Instance.RotationSpeed * Time.deltaTime));
        }
    }
}
