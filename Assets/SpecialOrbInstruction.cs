using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialOrbInstruction : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventoryUI.SetActive(true);
            CursorControl.ShowCursor();
            Time.timeScale = 0;
        }
    }

    public void CloseUIInstruction()
    {
        Time.timeScale = 1;
        CursorControl.HideCursor();
        inventoryUI.SetActive(false);
        GetComponent<Collider>().enabled = false;
    }

}
