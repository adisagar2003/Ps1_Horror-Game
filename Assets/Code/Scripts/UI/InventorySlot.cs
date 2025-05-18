using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private bool isFilled = false;
    private SOBasePickable so;
    private int amount;

    // UI Components
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private Image itemSprite;

    public void FillSlot(SOBasePickable so, int amount)
    {
        this.so = so;
        this.amount = amount;
        isFilled = true;

        // render ui 
        itemSprite.sprite = so.sprite;
        textUI.text = amount.ToString();
        this.isFilled = true;
        gameObject.SetActive(true);
    }
    public void ClearSlot()
    {
        isFilled = false;
        so = null;
        amount = 0;

        itemSprite.sprite = null;
        textUI.text = "";
    }

    public bool GetIsFilled()
    {
        return isFilled;
    }

    public SOBasePickable GetScriptableObject()
    {
        return so;
    }

    public void IncreaseAmount()
    {
        amount += 1;
        textUI.text = amount.ToString();
    }

}
