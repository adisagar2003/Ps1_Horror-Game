using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    private GlobalData globalData;
    [SerializeField] private List<SOBasePickable> objectsNeededToTriggerDoor;
    [SerializeField] AudioSource doorCannotOpenSound;
    [SerializeField] private string missingObjectsDialogue = "";
    [SerializeField] private string nextLevelName;
    void Start()
    {
        globalData = FindFirstObjectByType<GlobalData>();   
    }
    public void Interact()
    {
        if (PlayerHasFuse())
        {
            SceneSystem.Trigger(nextLevelName, 1);
        }
        else
        {
            DialogueSystem.Trigger(missingObjectsDialogue);
            doorCannotOpenSound.Play(); 
        }
    }
    
    private bool PlayerHasFuse()
    {
        foreach (SOBasePickable s in objectsNeededToTriggerDoor)
        {
            if (!globalData.GetItems().ContainsKey(s)) return false;
        }

        return true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
