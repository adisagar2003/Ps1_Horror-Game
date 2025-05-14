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
        foreach(GameObject obj in inventoryData)
        {
            Debug.Log(obj.name);
            Debug.Log("--- inventoryGameObject ");
        }

        foreach (GameObject s in inventoryData)
        {
            // extract ui slot
            UI_Slot uiSlot = s.GetComponent<UI_Slot>();
            // add that UI slot data to the corresponding generator slot data
            foreach (GameObject slot in generatorUISlots)
            {
                UI_Generator_Slot slotUI = slot.GetComponent<UI_Generator_Slot>();
                if (!slotUI.isOccupied)
                {
                    // populate data in slot
                    slotUI.FillSlot(uiSlot.so, 1);
                    break;
                }
            }
            // implement in 
        }

        Debug.Log(generatorUISlots);    
    }



    private void Update()
    {
        
    }
}
