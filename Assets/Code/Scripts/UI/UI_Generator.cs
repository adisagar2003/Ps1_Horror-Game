using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Generator : MonoBehaviour
{
   private List<GameObject> inventoryData;
    [SerializeField] private List<GameObject> generatorUISlots;

    private void Start()
    {
        inventoryData = FindFirstObjectByType<InventorySystem>().GetCurrentItems();

    }

    /// <summary>
    /// to implement
    /// </summary>
    public void PopulateData()
    {
        inventoryData = FindFirstObjectByType<InventorySystem>().GetCurrentItems();
        // add each item in inventory
        foreach (GameObject s in inventoryData)
        {
            // extract ui slot
            UI_Slot uiSlot = s.GetComponent<UI_Slot>();
            // implement in 
        }

        Debug.Log(generatorUISlots);    
    }



    private void Update()
    {
        
    }
}
