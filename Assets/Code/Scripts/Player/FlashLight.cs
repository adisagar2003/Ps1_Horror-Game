using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Simple script for flashlight on/off
/// Also handles battery health
/// self feedback, adding a lot of bools, need refactoring 
/// </summary>
public class FlashLight : MonoBehaviour
{
    [SerializeField] private bool isFlashlightOn = false;
    private AudioSource _flashlightToggleAudio;
    private Light _lightSource;
    private bool canToggleFlashlight = true;

    // battery drain reigon
    private float maxBatteryCapacity = 100.0f;
    private float currentBattery = 100.0f;
    private bool canBatteryDrain = false;
    private int startDrainingAfter = 4;
    [SerializeField] private float drainSpeed = 40.0f;


    // private float 


    private void OnEnable()
    {
        BatteryPickup.OnAddBattery += AddBattery;
    }

    private void OnDisable()
    {
        BatteryPickup.OnAddBattery -= AddBattery;
    }
    private void Start()
    {
        _lightSource = GetComponentInChildren<Light>();
        _lightSource.enabled = false;
        _flashlightToggleAudio = GetComponent<AudioSource>();
        StartCoroutine(DrainAfter(startDrainingAfter));
    }

    private IEnumerator DrainAfter(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canBatteryDrain = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }

        DrainBattery();

    }

    private void ToggleFlashlight()
    {
        if (!canToggleFlashlight) return;
        isFlashlightOn = !isFlashlightOn;
        _flashlightToggleAudio.Play();
        _lightSource.enabled = isFlashlightOn;
    }

    private void DrainBattery()
    {
        if (!canBatteryDrain) return;
        if (!isFlashlightOn) return;
        currentBattery = currentBattery - Time.deltaTime * drainSpeed;
        // if battery reaches below 0 
        if (currentBattery < 0.0f)
        {
            canBatteryDrain = false;
            ToggleFlashlight();
            isFlashlightOn = false;
            canToggleFlashlight = false;
        }
    }

    public void AddBattery(float amount)
    {
        currentBattery += amount;
        if (currentBattery > 0)
        {
            canToggleFlashlight = true;
        }
        else
        {
            canToggleFlashlight = true;
            ToggleFlashlight();
        }
        canBatteryDrain = true;
    }

    public float GetCurrentBattery()
    {
        return currentBattery;
    }

    public float GetMaxFlashlightCapacity()
    {
        return maxBatteryCapacity;
    }
}
