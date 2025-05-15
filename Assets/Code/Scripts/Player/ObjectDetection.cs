using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This detects object, references the object at e 
/// </summary>
public class ObjectDetection : MonoBehaviour
{
    // Raycast from camera to middle of the screen.
    [SerializeField] LayerMask detectableLayers;
    [SerializeField] private float maxDetectionDistance;
    [SerializeField] private GameObject interactionUI;

    private PlayerStateHandle playerState;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        playerState = GetComponentInParent<PlayerStateHandle>();
    }


    private void Update()
    {
        DetectableInteraction();
    }

    private void DetectableInteraction()
    {
        RaycastHit hit;
        bool playerIsPlayable = playerState.GetCurrentState() == PlayerStateHandle.PlayerState.Playable;

        if (PlayerIsLookingAtInteractable(out hit) && playerIsPlayable)
        {
            interactionUI.SetActive(true); // sets the 'Press E to interact' UI
            IInteractable interactableReference = hit.collider.gameObject.GetComponent<IInteractable>();
            if (Input.GetKey(KeyCode.E)) interactableReference.Interact();
        }
        else
        {
            interactionUI.SetActive(false); // sets the 'Press E to interact' UI
        }
    }

    private bool PlayerIsLookingAtInteractable(out RaycastHit hit)
    {
        return Physics.Raycast(mainCamera.transform.position,
                mainCamera.transform.forward * maxDetectionDistance,
                out hit,
                maxDetectionDistance,
                detectableLayers);
    }

#if DEBUG_RAYS
    private void OnDrawGizmos()
    {
        Debug.DrawRay(_mainCamera.transform.position, _mainCamera.transform.forward * _maxDetectionDistance, Color.red);
    }
#endif
}
