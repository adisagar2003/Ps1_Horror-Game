using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Physics")]
    [SerializeField] private float horizontalSpeed = 10.0f;
    [SerializeField] private float verticalSpeed = 10.0f;
    private PlayerState playerState;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerState = FindFirstObjectByType<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState._currentState == PlayerState.PlayerCurrentState.IsInteracting) return;
        HandleVelocity();
    }

    private void HandleVelocity()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 finalVelocity = transform.forward * verticalSpeed * forwardInput + transform.right * horizontalInput * horizontalSpeed;
        _rb.velocity = finalVelocity;
    }
}
