using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Listens to Vision Signal and switches layer
/// </summary>
public class SwitchMonsterLayer : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;
    private LayerMask currentLayer;

    private bool switchLayerToggle = true;


    private void Start()
    {
        currentLayer = gameObject.layer;
    }
    private void OnEnable()
    {
        MonsterVision.SwitchMaterialSignal += SwitchLayer;
    }

    private void OnDisable()
    {
        MonsterVision.SwitchMaterialSignal -= SwitchLayer;
    }

    private void SwitchLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("Spider");
    }
}
