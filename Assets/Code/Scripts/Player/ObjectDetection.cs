using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Raycast from camera to middle of the screen.
    private Camera _mainCamera;
    [SerializeField] LayerMask _detectableLayers;
    [SerializeField] private float _maxDetectionDistance;

    private void Start()
    {
        _mainCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
      
        RaycastHit hit;

        if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward * _maxDetectionDistance, out hit, _maxDetectionDistance,_detectableLayers))
        {
            Debug.LogWarning(hit.collider.gameObject.name);
        }
    }

#if DEBUG_RAYS
    private void OnDrawGizmos()
    {
        Debug.DrawRay(_mainCamera.transform.position, _mainCamera.transform.forward * _maxDetectionDistance, Color.red);
    }
#endif
}
