using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This works as a slot for generator UI
/// </summary>
public class UI_Generator_Slot : MonoBehaviour
{
    [SerializeField] private GameObject modelPrefab;
    private bool isOccupied = false;
    private float yRotationSpeed = 10.0f;
    private void Start()
    {
    
    }



    public void FillSlot(SOBasePickable so, float amount)
    {
        modelPrefab = so.prefab;
        isOccupied = true;
    }

   
    private void Update()
    {
         if (modelPrefab != null)
        {
            float newRotationY = transform.rotation.y + Time.deltaTime * yRotationSpeed;
            modelPrefab.transform.rotation = Quaternion.Euler(transform.eulerAngles.x,
                newRotationY,
                transform.eulerAngles.z);
 ;        } 
    }
}
