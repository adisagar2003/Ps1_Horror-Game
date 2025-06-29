using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Displays text at start of level for ease of gameplay
/// </summary>
public class InitialLevelStartInstructions : MonoBehaviour
{

    [SerializeField] private string firstLevelInstruction = "Press [Tab] for inventory";

    void Start()
    {
        DialogueSystem.Trigger(firstLevelInstruction);       
    }

}
