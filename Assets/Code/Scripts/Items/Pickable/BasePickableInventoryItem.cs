using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePickableInventoryItem : MonoBehaviour, IPickable
{
   
    [SerializeField] protected SOBasePickable so;
    [SerializeField] public int amount;
    [SerializeField] private AudioClip pickupClip;
    public delegate void PickupEvent(SOBasePickable p);
    public static event PickupEvent OnPickupEvent;
    
    [SerializeField] protected float yRotationSpeed = 2.0f;

    public virtual void Pickup()
    {
        // send a signal... 1 object is picked up, send object 
        OnPickupEvent?.Invoke(so);
        Debug.Log("Event Invoked");
        if (pickupClip != null)
        {
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
        } 
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    public Sprite GetSprite()
    {
        return this.so.sprite;
    }

    public SOBasePickable GetScriptableObject()
    {
        return so;
    }

    private void Update()
    {
        FloatingMovement();
    }

    public void AddAmount(int quantity)
    {
        amount += quantity;
    }

    public void FloatingMovement()
    {
        float xRotation = transform.rotation.x;
        float yRotation = transform.rotation.y + yRotationSpeed * Time.time; 
        float zRotation = transform.rotation.z;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }

    protected IEnumerator DestroyAfterFrame()
    {
        yield return null; // wait 1 frame
        Destroy(gameObject);
    }
}


