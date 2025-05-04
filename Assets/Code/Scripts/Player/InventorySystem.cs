using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private List<SOBasePickable> scriptableObjects;
    [SerializeField] private List<bool> isSlotOccupied;
    [SerializeField] private List<GameObject> slots;

    // Todo: Send an event for updated amount to the slot object.
    private void Start()
    {
        // initialize all the slots to false.
        isSlotOccupied = new List<bool> { false, false, false, false };
    }
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void OnEnable()
    {
        BasePickable.OnPickupEvent += AddItemToInventory;
    }


    private void OnDisable()
    {
        BasePickable.OnPickupEvent -= AddItemToInventory;
    }

    private void AddItemToInventory(SOBasePickable data, int amount)
    {
        bool found = false;
        foreach (SOBasePickable s in scriptableObjects)
        {
            // if data exists in inventory
            if (s.name == data.name)
            {
                found = true;
                s.amount += data.amount;


               
            }
            
            foreach (SOBasePickable d in scriptableObjects)
            {
                Debug.Log(d.name);
                Debug.Log(d.amount);
            }

        }

        // if data didn't exist inside
        if (!found)
        {
            scriptableObjects.Add(data);
            // add this in the inventory

            Debug.Log(scriptableObjects);
        }


        RenderSlots();


    }

    private void RenderSlots()
    {
        // take the scriptable objects, render them inside the inventory.

        // find an empty slot.

        for (int i = 0; i < scriptableObjects.Count; i++)
        {
            if (isSlotOccupied[i] == false && scriptableObjects[i])
            {   
                // fill the object in this slot;

                slots[i].GetComponent<UI_Slot>().FillSlot(scriptableObjects[i].sprite, scriptableObjects[i].name, scriptableObjects[i].amount);
                isSlotOccupied[i] = true;
                slots[i].SetActive(true);
            }

        }

        Debug.Log("Slots rendered");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);

        }
    }
}
