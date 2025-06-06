using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Attaches to switch prefab, on interacting turns on all lights in maze
/// </summary>
public class LeverSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject lights;
    private ObjectiveManager objectiveManager;
    private bool isTurnedOn = false;

    private void Start()
    {
        objectiveManager = FindFirstObjectByType<ObjectiveManager>();    
    }

    public void Interact()
    {
        objectiveManager.AddObjectiveToList("Find fuse");
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().SetTrigger("Flick"); // to tired rn to make it efficient..
        foreach(Light light in lights.GetComponentsInChildren<Light>())
        {
            light.enabled = true;
            gameObject.layer = 0; // makes the gameobject non interactable
        }

        
    }

}
