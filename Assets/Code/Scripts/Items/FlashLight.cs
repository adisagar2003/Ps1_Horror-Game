using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Simple script for flashlight on/off
/// </summary>
public class FlashLight : MonoBehaviour
{

    [SerializeField] private bool isFlashlightOn = false;
    private AudioSource _flashlightToggleAudio;
    private Light _lightSource;
    private void Start()
    {
        _lightSource = GetComponentInChildren<Light>();
        _flashlightToggleAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightOn = !isFlashlightOn;
            _flashlightToggleAudio.Play();
            _lightSource.enabled = isFlashlightOn;
        }
    }
}
