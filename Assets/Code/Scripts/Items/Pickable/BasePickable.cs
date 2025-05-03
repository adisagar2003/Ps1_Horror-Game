using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickable : MonoBehaviour, IPickable
{
   
    [SerializeField] protected ScriptableObject _inventorySlot;
    [SerializeField] protected  int amount;
    public delegate void PickupEvent(ScriptableObject data, int amount);
    public static event PickupEvent OnPickupEvent;

    public virtual void Pickup()
    {
        // send a signal... 1 object is picked up, send object 
        OnPickupEvent(_inventorySlot, amount);
    }

    public void FloatingMovement()
    {
        
    }
}
