using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the player's inventory and updates UI slots 
/// when items are picked up.
/// </summary>
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private List<GameObject> slots; // store all the inventory slot references

    private GlobalData globalData;

    // Todo: Send an event for updated amount to the slot object
    public delegate void SendAmountUpdate(float amount);
    public static event SendAmountUpdate OnSendAmountUpdate;

    void OnEnable()
    {
        GlobalData.OnAddItem += RenderItems;
    }

    private void Start()
    {
        globalData = FindFirstObjectByType<GlobalData>();
    }

    private void OnDisable()
    {
        GlobalData.OnAddItem -= RenderItems;
    }

    private void RenderItems(SOBasePickable p)
    {
        // get items from global data
        Dictionary<SOBasePickable, int> globalDataRetrieved = globalData.GetItems();

        foreach (GameObject slot in slots)
        {
            InventorySlot inventorySlotScript = slot.GetComponent<InventorySlot>();
            if (!inventorySlotScript.IsFilled())
            {
                inventorySlotScript.FillSlot(p, globalDataRetrieved[p]);
                slot.gameObject.SetActive(true);
                return;
            }
        }
    }


    [Obsolete]
    /// <summary>
    /// add the picked-up item to the inventory slots.
    /// </summary>
    /// 
    private void AddItemToInventory(BasePickable pickable)
    {
       
    }


    [Obsolete]
    private static bool FindSlotsWithContent(GameObject g)
    {
        return g.GetComponent<UI_Slot>() != null;
    }

    //[Obsolete]
    //Predicate<GameObject> getObjectsPredicate = FindSlotsWithContent;


    //[Obsolete]
    //public List<GameObject> GetCurrentItems()
    //{
    //    return slots.FindAll(getObjectsPredicate);
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

}
