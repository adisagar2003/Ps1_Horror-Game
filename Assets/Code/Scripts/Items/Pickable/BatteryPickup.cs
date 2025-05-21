using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour, IPickable
{
    [SerializeField] private AudioClip pickupAudio;
    [SerializeField] private float pickupVolume;
    [SerializeField] private float amount; // adds up to total battery

    // events to register 
    public delegate void AddBattery(float amount);
    public static event AddBattery OnAddBattery;

    public void FloatingMovement()
    {
        // future implementation
    }

    public void Pickup()
    {
        AudioSource.PlayClipAtPoint(pickupAudio, transform.position, pickupVolume);
        OnAddBattery?.Invoke(amount);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        Pickup();
    }
}
