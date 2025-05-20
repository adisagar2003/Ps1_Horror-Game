using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Only displays data for flashlight health.
/// </summary>
public class FlashlightUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject flashlight;
    private FlashLight flashlightComponent;
    private float lerpSpeed = 10.0f;
    [SerializeField] private Image sliderForUI;
    void Start()
    {
        flashlightComponent = flashlight.GetComponent<FlashLight>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();

    }

    private void UpdateUI()
    {
        if (!flashlightComponent) return;
        float newValue = flashlightComponent.GetCurrentBattery()
        / flashlightComponent.GetMaxFlashlightCapacity();

        sliderForUI.fillAmount = Mathf.Lerp(sliderForUI.fillAmount, newValue, Time.deltaTime * lerpSpeed);
    }
}
