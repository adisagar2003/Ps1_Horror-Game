using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handles Level 3 scene
/// </summary>
public class LevelManager3 : MonoBehaviour
{
    private void Start()
    {
        ObjectiveManager.Trigger("Find 2 keycards");
    }
}
