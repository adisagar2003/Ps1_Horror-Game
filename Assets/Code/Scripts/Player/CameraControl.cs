using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Attaches to camera holder
/// usage: for handling camera movement with mouse.
/// Warning: X: looking up, Y: looking left, right according to unity
/// </summary>
public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform physicsBody;

    [Header("Sensitivity")]
    [SerializeField] private float mouseX = 239.5f;
    [SerializeField] private float mouseY = 100.0f;
    [SerializeField] private float xRotationMin = -76.7f; // how down a player can look
    [SerializeField] private float xRotationMax = 72.8f; // how up a player can look


    [Header("Player looking")]
    [SerializeField] private float xLookRotation = 0.0f;
    [SerializeField] private float yLookRotation = 0.0f;

    void Start()
    {
        HideCursor();

    }

    private static void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private static void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        // react to horizontal and vertical input of the mouse,
        HandleUpAndDownLook();

        // handle y input
        float yInput = Input.GetAxis("Mouse X");
        yLookRotation += yInput * Time.deltaTime * mouseY;

        // when rotating on y axis the whole physics transform is affected,
        Vector3 physicsbodyRotationAngles = physicsBody.transform.rotation.eulerAngles;
        Vector3 newRotationByYInput = new Vector3(0f, yLookRotation, 0f);
        physicsBody.transform.rotation = Quaternion.Euler(newRotationByYInput);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, yLookRotation, transform.eulerAngles.z);
        
    }

    private void HandleUpAndDownLook()
    {
        float xInput = Input.GetAxis("Mouse Y"); // we need y value for x rotation up and down.
        xLookRotation += xInput * mouseX * Time.deltaTime * -1;

        // the player can look down till x: 72.8f and x: -76.7f
        xLookRotation = Mathf.Clamp(xLookRotation, xRotationMin, xRotationMax);
        transform.rotation = Quaternion.Euler(xLookRotation, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
