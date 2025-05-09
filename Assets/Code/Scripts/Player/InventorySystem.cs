using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manages the player's inventory and updates UI slots when items are picked up.
/// </summary>
public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject InventoryUI;

    [SerializeField] private List<GameObject> slots; // store all the inventory slot references

    // Todo: Send an event for updated amount to the slot object
    public delegate void SendAmountUpdate(float amount);
    public static event SendAmountUpdate OnSendAmountUpdate;

    // Start is called before the first frame update
    void OnEnable()
    {
        BasePickable.OnPickupEvent += AddItemToInventory;
    }


    private void OnDisable()
    {
        BasePickable.OnPickupEvent -= AddItemToInventory;
    }

    /// <summary>
    /// add the picked-up item to the inventory slots.
    /// </summary>
    private void AddItemToInventory(SOBasePickable scriptableObjectData, int amount)
    {
        // loop through the slots to check an empty(not active slot)
        foreach (GameObject s in slots)
        {
            UI_Slot currentSlotData = s.GetComponent<UI_Slot>();

            // if the slot exists and with the same name, just update the amount
            if (currentSlotData != null && scriptableObjectData.name == currentSlotData.so.name)
            {
                currentSlotData.amount += amount;
                currentSlotData.UpdateDataInUI();
                break;
            }


            // fill the slot with the inventory data in an empty slot.
            if (s.GetComponent<UI_Slot>() == null)
            {
                s.AddComponent<UI_Slot>();
                s.GetComponent<UI_Slot>().so = scriptableObjectData;
                s.GetComponent<UI_Slot>().amount = amount;
                s.SetActive(true);
                break; // break loop to prevent filling further slots
            }

        }
    }

    private static bool FindSlotsWithContent(GameObject g)
    {
        return g.GetComponent<UI_Slot>() != null;
    }

    Predicate<GameObject> getObjectsPredicate = FindSlotsWithContent;

    public List<GameObject> GetCurrentItems()
    {
        return slots.FindAll(getObjectsPredicate);
    }

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
        InventoryUI.SetActive(!InventoryUI.activeSelf);
    }

}
