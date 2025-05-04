using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickable : MonoBehaviour, IPickable
{
   
    [SerializeField] protected SOBasePickable _inventorySlot;
    [SerializeField] protected  int amount;

    public delegate void PickupEvent(SOBasePickable data, int amount);
    public static event PickupEvent OnPickupEvent;

    public virtual void Pickup()
    {
        // send a signal... 1 object is picked up, send object 
        OnPickupEvent?.Invoke(_inventorySlot, amount);
        Debug.Log("Event Invoked");
    }

    public void FloatingMovement()
    {
        
    }
}
