using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

/// <summary>
/// Let NavMeshAgent handle the root movement.
/// When the leg’s target is too far from where it last stepped,
/// move the leg toward this new target.
/// </summary>
public class SpiderLegMovementHandle : MonoBehaviour
{
    [SerializeField] private TwoBoneIKConstraint legIKConstraint;
    [SerializeField] private Transform legTarget;
    private Vector3 targetPosition; 
    private Vector3 lastPlantedPosition;
    [SerializeField] private float maxDistance = 0.97f;
    [SerializeField] private float legMoveSpeed = 10f;
    
    // this would help move legIkTarget
    [SerializeField] private float sineFluctuation = 40.0f;
    [SerializeField] private float sineAmplitude = 1.47f;
    private bool isStepping = false;
    private float stepTimer = 0f;

    private void Start()
    {
    }

    private void Update()
    {
        if (Vector3.Distance(targetPosition, legTarget.position) > maxDistance)
        {
            // reached too far, now lerp the current position to target position
            stepTimer += Time.deltaTime * sineFluctuation;
            float zValue = Mathf.Sin(stepTimer) * sineAmplitude;
            Debug.Log(zValue);
            Vector3 currentLegIKTargetPosition = legIKConstraint.data.target.position;
            legIKConstraint.data.target.position = new Vector3(currentLegIKTargetPosition.x,
                currentLegIKTargetPosition.y,
                zValue);
        }
    }

}
