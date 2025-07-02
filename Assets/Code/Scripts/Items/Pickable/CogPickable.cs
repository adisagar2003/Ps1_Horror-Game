using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogPickable : BasePickableInventoryItem
{
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private float xRotationSpeed = 10.0f;
    [SerializeField] private float pickupSoundVolume = 1.4f;
  
    public override void Pickup()
    {
        StartCoroutine(PlayCogAudio());
        base.Pickup();
        StartCoroutine(DestroyAfterFrame());
    }

    private IEnumerator PlayCogAudio()
    {
        AudioSource.PlayClipAtPoint(pickupSound,
        transform.localPosition,
        pickupSoundVolume);
        yield return null;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pickup();
        }
     
    }

    private void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        
        // calculate rotations
        float deltaX = xRotationSpeed * Time.deltaTime;
        float deltaY = yRotationSpeed * Time.deltaTime;

        Vector3 newRotation = new Vector3(
            currentRotation.x + deltaX,
            currentRotation.y + deltaY,
            0f);

        transform.rotation = Quaternion.Euler(newRotation);
    }

}
