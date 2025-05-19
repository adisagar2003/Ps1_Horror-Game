using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour,IInteractable
{
    private Generator generator;

    public void Interact()
    {
       
        if (generator.GetIsGeneratorRunning())
        {
            gameObject.layer = 0; // silly workaround to stop interact UI
            SceneSystem.Trigger("level2", 4);
            // Invoke scene shift event 
        }
        else
        {
            Debug.Log("Generator is not running");
            DialogueSystem.Trigger("No power... Check generator");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        generator = FindFirstObjectByType<Generator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
