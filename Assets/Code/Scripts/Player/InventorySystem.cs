using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject InventoryUI;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
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
