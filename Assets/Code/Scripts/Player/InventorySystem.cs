using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private List<SOBasePickable> scriptableObjects;

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

        }   
      
        // if data didn't exist inside
        if (!found)
        {
            scriptableObjects.Add(data);
            Debug.Log(scriptableObjects);
        }


    }

    private void RenderSlots()
    {
       
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
