using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Raycast to detect ground
/// Move to new Target Position when needed
/// </summary>
public class IKSetTarget : MonoBehaviour
{
    [SerializeField] private LayerMask detectThisLayer;
    [SerializeField] private float gizmosSphereRadius = 3.0f;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private GameObject ikTarget;
    [SerializeField] private Vector3 ikOffset;
    private Vector3 currentIKPosition;
    private RaycastHit hit;
    [SerializeField] private GameObject currentBodyPosition; // gameobject attached to spider that calculates where to shift IK
    [SerializeField] private float distanceNeededToShiftLeg = 1.00f;
    [SerializeField] private bool canCurrentIkPositionLerp = false;
    [SerializeField] private float ikLerpSpeed = 10.0f;

    void Start()
    {
        SetIKTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        ikTarget.transform.position = currentIKPosition; // keeps position of leg in-place when moving body
        UpdateLegPositionIfFar();
        LerpIKToNewPosition(hit.point + ikOffset);
    }

    private void LerpIKToNewPosition(Vector3 newPosition)
    {
        if (canCurrentIkPositionLerp)
        {
            currentIKPosition = Vector3.Lerp(currentIKPosition, newPosition, Time.deltaTime * ikLerpSpeed);
            if (newPosition == currentIKPosition) canCurrentIkPositionLerp = false;
        }
    }

    private void UpdateLegPositionIfFar()
    {
        float distanceBetweenTargetAndBody = Vector3.Distance(currentBodyPosition.transform.position, currentIKPosition);
        if (distanceBetweenTargetAndBody > distanceNeededToShiftLeg)
        {
            UpdateTargetIKPosition();
        }
    }

    private void UpdateTargetIKPosition()
    {
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.down), out hit, detectThisLayer))
        {
            Debug.DrawRay(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            ikTarget.transform.position = hit.point + ikOffset;
            canCurrentIkPositionLerp = true;
            LerpIKToNewPosition(hit.point + ikOffset);
        }
    }

    private void SetIKTargetPosition()
    {
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.down), out hit, detectThisLayer))
        {
            Debug.DrawRay(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            ikTarget.transform.position = hit.point + ikOffset;
            currentIKPosition = hit.point + ikOffset;
        }
    }

    private void OnDrawGizmos()
    {
        if (hit.point != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(hit.point, gizmosSphereRadius);
        }
    }
}
