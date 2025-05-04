using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Slot : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite sprite;
    public string name;
    public float amount;

    public bool isFilled { get; private set; } = false;
    
    void Start()
    {
        GetComponentInChildren<Image>().sprite = sprite;
        GetComponentInChildren<TextMeshProUGUI>().text = amount.ToString();
    }


    public void FillSlot(Sprite image, string name, float amount)
    {
        this.sprite = image;
        this.name = name;
        this.amount = amount;
        isFilled = true;
    }
    // Update is called once per frame
    
    void Update()
    {
        
    }
}
