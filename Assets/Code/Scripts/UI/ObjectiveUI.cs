using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ObjectiveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI objective;
    private bool startFade = false;
    [SerializeField] private float fadeSpeed = 10.3f;

    private void OnEnable()
    {
        ObjectiveManager.OnAddObjectiveUI += RenderObjective;
    }


    private void OnDisable()
    {
        ObjectiveManager.OnAddObjectiveUI -= RenderObjective;
    }

    private void Start()
    {
            
    }

    private void RenderObjective(string obj)
    {
        // make new objective appear for 4 seconds
        startFade = false;  // prevents text to fade right away
        objective.GetComponent<TMP_Text>().alpha = 1f; // reappear 
        objective.text = obj;
        StartCoroutine(FadeTextToTransparent(3.0f));
    }


    private void Update()
    {
        FadeTextToTransparent();
    }

    private void FadeTextToTransparent()
    {
        if (startFade)
        {
            objective.GetComponent<TMP_Text>().alpha -= Time.deltaTime * fadeSpeed;
        }

        
    }

 
    private IEnumerator FadeTextToTransparent(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        startFade = true; // slowly turns text transparent in Update();
    }
}
