using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    private GlobalData globalData;
    [SerializeField] private SOBasePickable fuseScriptableObject;
    [SerializeField] AudioSource doorCannotOpenSound;
    void Start()
    {
        globalData = FindFirstObjectByType<GlobalData>();   
    }
    public void Interact()
    {
        if (PlayerHasFuse())
        {
            SceneSystem.Trigger("Level3", 1);
        }
        else
        {
            DialogueSystem.Trigger("Fuse is missing");
            doorCannotOpenSound.Play(); 
        }
    }
    
    private bool PlayerHasFuse()
    {
        if (globalData.GetItems().ContainsKey(fuseScriptableObject)) return true;
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
