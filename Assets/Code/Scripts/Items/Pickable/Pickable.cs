using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : BasePickableInventoryItem
{
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private float xRotationSpeed = 10.0f;
    [SerializeField] private float pickupSoundVolume = 0.4f;

    public Pickable()
    {
    }

    public override void Pickup()
    {
        base.Pickup();
        AudioSource.PlayClipAtPoint(pickupSound, transform.position, pickupSoundVolume);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
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
