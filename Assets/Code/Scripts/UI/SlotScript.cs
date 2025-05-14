using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Slot : MonoBehaviour
{
    // Start is called before the first frame update
    public SOBasePickable so;
    public float amount;

    public bool isFilled { get; private set; } = false;
    public UI_Slot(SOBasePickable scriptableObject, int amt)
    {
        this.so = scriptableObject;
        this.amount = amt;
    }

    void Start()
    {
        UpdateDataInUI();
    }

    public void UpdateDataInUI()
    {
        GetComponentInChildren<Image>().sprite = so.sprite;
        GetComponentInChildren<TextMeshProUGUI>().text = amount.ToString();
    }

    public void FillSlot(Sprite image, string name, float amount)
    {
        this.so.sprite = image;
        this.name = name;
        this.amount = amount;
        isFilled = true;
    }
    // Update is called once per frame
    
    void Update()
    {
        
    }
}
