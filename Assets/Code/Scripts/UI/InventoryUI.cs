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
        Dictionary<SOBasePickable, int> valuePairs = globalData.GetItems();
        bool objectFound = TryUpdateExistingSlot(p);
        if (objectFound) return;
        AddNewItemToSlot(p);
    }

    private void AddNewItemToSlot(SOBasePickable p)
    {
        foreach (GameObject slot in slots)
        {
            InventorySlot slotComponent = slot.GetComponent<InventorySlot>();
            SOBasePickable slotScriptableObject = slotComponent.GetScriptableObject();
            if (slotScriptableObject == null)
            {
                slotComponent.FillSlot(p, 1);
                Debug.Log("Added to inventory");
                slot.SetActiveRecursively(true);
                break;
            }
        }
    }

    private bool TryUpdateExistingSlot(SOBasePickable p)
    {
        bool objectFound = false;

        // find the corresponding inventory slot,
        foreach (GameObject slot in slots)
        {
            SOBasePickable slotScriptableObject = slot.GetComponent<InventorySlot>().GetScriptableObject();
            if (slotScriptableObject?.name == p.name)
            {
                objectFound = true;
                Debug.Log("Corresponding slot found, will update value");
                slot.GetComponent<InventorySlot>().IncreaseAmount();
            }
            else
            {
                continue;
            }
        }

        return objectFound;
    }

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
