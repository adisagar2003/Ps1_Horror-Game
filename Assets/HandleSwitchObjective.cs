using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Attaches to a collider, invokes objective for player
/// </summary>
public class HandleSwitchObjective : MonoBehaviour
{
    private ObjectiveManager objectiveManager;

    private void Start()
    {
        objectiveManager = FindFirstObjectByType<ObjectiveManager>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag  == "Player" )
        {
            // handle event firing
            objectiveManager.AddObjectiveToList("Find the switch to main power");
            StartCoroutine(DisableCollider());
        }
    }

    private IEnumerator DisableCollider()
    {
        yield return null;
        gameObject.SetActive(false);
    }
}
