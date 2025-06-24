using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardPickable : BasePickableInventoryItem
{
    [SerializeField] private Material newMaterial;
    private void OnEnable()
    {
        MonsterVision.SwitchMaterialSignal += SwitchKeycardMaterial;
    }

    private void OnDisable()
    {
        MonsterVision.SwitchMaterialSignal -= SwitchKeycardMaterial;
    }
     
    // future Implementation
    private void SwitchKeycardMaterial()
    {
    }
}
