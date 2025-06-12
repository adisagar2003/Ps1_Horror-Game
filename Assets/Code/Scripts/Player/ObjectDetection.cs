using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// This detects object, references the object at e 
/// </summary>
public class ObjectDetection : MonoBehaviour
{
    // Raycast from camera to middle of the screen.
    [SerializeField] LayerMask detectableLayers;
    [SerializeField] private float maxDetectionDistance;
    private GameObject interactionUI;
    private TextMeshProUGUI textComponent;
    private PlayerStateHandle playerState;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        playerState = GetComponentInParent<PlayerStateHandle>();
        interactionUI = GameObject.Find("PressE");
        textComponent = interactionUI.GetComponent<TextMeshProUGUI>();
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
            textComponent.text = "Press E to interact";
            IInteractable interactableReference = hit.collider.gameObject.GetComponent<IInteractable>();
            if (Input.GetKey(KeyCode.E)) interactableReference.Interact();
        }
        else
        {
           textComponent.text = ""; // sets the 'Press E to interact' UI
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
