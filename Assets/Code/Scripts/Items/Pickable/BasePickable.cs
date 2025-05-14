using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePickable : MonoBehaviour, IPickable
{
   
    [SerializeField] protected SOBasePickable so;
    [SerializeField] public int amount;

    public delegate void PickupEvent(SOBasePickable p);
    public static event PickupEvent OnPickupEvent;

    public virtual void Pickup()
    {
        // send a signal... 1 object is picked up, send object 
        OnPickupEvent?.Invoke(so);
        Debug.Log("Event Invoked");
    }

    public Sprite GetSprite()
    {
        return this.so.sprite;
    }

    public SOBasePickable GetScriptableObject()
    {
        return so;
    }

    public void AddAmount(int quantity)
    {
        amount += quantity;
    }

    public void FloatingMovement()
    {
        
    }

    protected IEnumerator DestroyAfterFrame()
    {
        yield return null; // wait 1 frame
        Destroy(gameObject);
    }
}


