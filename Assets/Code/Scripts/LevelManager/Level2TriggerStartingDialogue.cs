using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2TriggerStartingDialogue : MonoBehaviour
{
    private void Start()
    {
        DialogueSystem.Trigger("Press [F] for flashlight");
    }
}
