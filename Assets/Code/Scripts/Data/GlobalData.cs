using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Holds shared game data such as inventory items.
/// Acts as a data layer between systems (UI, puzzles, player, etc.).
/// </summary>
public class GlobalData : MonoBehaviour
{

    private Dictionary<SOBasePickable, int> items;

    [SerializeField] private string debugString;
    // adding event 
    public delegate void AddItemDelegate(SOBasePickable item);
    public static event AddItemDelegate OnAddItem;
    
    // removing event
    public delegate void RemoveItemDelegate(SOBasePickable item);
    public static event RemoveItemDelegate OnRemoveItem;

    private void Start()
    {
       items = new Dictionary<SOBasePickable, int>();

    }

    private void Update()
    {
        debugString = items.ToString();
    }
    private void OnEnable()
    {
        BasePickableInventoryItem.OnPickupEvent += AddItem;
    }

    private void OnDisable()
    {
        BasePickableInventoryItem.OnPickupEvent -= AddItem;
    }

    private void AddItem(SOBasePickable so)
    {
        bool foundItem = false;
        if (items.ContainsKey(so))
        {
            items[so] += 1;
            foundItem = true;
        }
        else
        {
            items.Add(so, 1);
            foundItem = true;
        }
        OnAddItem?.Invoke(so);
        Debug.Log(string.Join(',',items));
    }

    //private void RemoveItem(BasePickable item)
    //{
    //    items.Remove(item);
    //    OnRemoveItem?.Invoke(item);
    //    Debug.Log(items);
    //}

    public Dictionary<SOBasePickable, int> GetItems()
    {
        return items;
    }

}
