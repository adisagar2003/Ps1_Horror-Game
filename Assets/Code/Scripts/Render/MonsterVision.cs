using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;


/// <summary>
/// Special ability of player to see through walls and 
/// detect monster for a small period of time.
/// </summary>
public class MonsterVision : MonoBehaviour
{
    [SerializeField] private Color specialAbilityColor = Color.blue;
    [SerializeField] private Volume volume;
    private UnityEngine.Rendering.Universal.ColorAdjustments colorAdjustments;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet<UnityEngine.Rendering.Universal.ColorAdjustments>(out this.colorAdjustments);
    }

    // Update is called once per frame
    void Update()
    {

        // Future migration 
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Enable special");
            Debug.Log(colorAdjustments);
            colorAdjustments.colorFilter.value = specialAbilityColor;
        }
    }
}
