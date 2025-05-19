using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour,IInteractable
{
    private AudioSource carAudio;

    [SerializeField] private List<MeshRenderer> carHeadLights;
    public enum CarState
    {
        On, 
        Off
    }
    
    private CarState currentCarState;


    //key cooldown
    private bool canPressAgain = true;
    [SerializeField] private float keyCooldownTime = 1.2f;
    public void Interact()
    {
        if (canPressAgain) ToggleCarState();

    }

    private void ToggleCarState()
    {
        canPressAgain = false;
        StartCoroutine(KeyCooldown());
        if (currentCarState == CarState.On)
        {
            currentCarState = CarState.Off;
            carAudio.Stop();
            foreach (MeshRenderer headlight in carHeadLights)
            {
                headlight.enabled = false;
            }
        }
        else
        {
            currentCarState = CarState.On;
            carAudio.Play();
            foreach (MeshRenderer headlight in carHeadLights)
            {
                headlight.enabled = true;
            }
        }
    }

    private IEnumerator KeyCooldown()
    {
        yield return new WaitForSeconds(keyCooldownTime);
        canPressAgain = true;
    }

    // Start is called before the first frame update

    void Start()
    {
        carAudio = GetComponent<AudioSource>();
        currentCarState = CarState.On;
        PopulateCarHeadlights();
    }

    /// <summary>
    /// Adds headlights in car classlist
    /// </summary>
    private void PopulateCarHeadlights()
    {
        MeshRenderer[] s = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer headlight in s)
        {
            // ignore first 
            carHeadLights.Add(headlight);
        }

        carHeadLights.RemoveAt(0);
        Debug.Log("Added shit");    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
