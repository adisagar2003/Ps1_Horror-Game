using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This works as a slot for generator UI
/// </summary>
public class UI_Generator_Slot : MonoBehaviour
{
    [SerializeField] public Transform  modelPosition;
    public bool isOccupied = false;
    private float yRotationSpeed = 10.0f;

    private void Start()
    {
    
    }



    public void FillSlot(SOBasePickable so, float amount)
    {
        isOccupied = true;
        Instantiate(so.prefab, transform);
    }

   
    private void Update()
    {
         if (modelPosition != null)
        {
            float newRotationY = transform.rotation.y + Time.deltaTime * yRotationSpeed;
            modelPosition.rotation = Quaternion.Euler(transform.eulerAngles.x,
                newRotationY,
                transform.eulerAngles.z);
 ;        } 
    }
}
