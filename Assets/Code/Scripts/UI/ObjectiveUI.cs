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
    [SerializeField] private float fadeSpeed = 0.03f;

    private void OnEnable()
    {
        ObjectiveManager.OnAddObjective += RenderObjective;
    }


    private void OnDisable()
    {
        ObjectiveManager.OnAddObjective -= RenderObjective;
    }

    private void Start()
    {
            
    }

    private void RenderObjective(string obj)
    {
        // make new objective appear for 4 seconds
        objective.text = obj;
        // fade away after that
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
