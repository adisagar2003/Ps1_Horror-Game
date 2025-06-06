using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour,IInteractable
{
    private Generator generator;

    private void OnEnable()
    {
        GeneratorUI.OnGeneratorTurned += ChangeColorToGreen;
    }

    private void OnDisable()
    {
        GeneratorUI.OnGeneratorTurned -= ChangeColorToGreen;
    }

    [ContextMenu("Change Color")]
    private void ChangeColorToGreen()
    {
        Material buttonMaterial = gameObject.GetComponent<Renderer>().material;
        buttonMaterial.SetColor("_BaseColor",Color.green);
        buttonMaterial.SetColor("_EmissionColor", Color.green);
        buttonMaterial.EnableKeyword("_EMISSION");
    }

    public void Interact()
    {
       
        if (generator.GetIsGeneratorRunning())
        {
            gameObject.layer = 0; // silly workaround to stop interact UI
            SceneSystem.Trigger("Level2", 4);
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
