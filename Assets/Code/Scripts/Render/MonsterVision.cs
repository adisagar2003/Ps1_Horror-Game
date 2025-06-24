using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;


/// <summary>
/// Special ability of player to see through walls and 
/// detect monster for a small period of time.
/// Sets culling mask from nothing to spider in spiderXray camera
/// 
/// </summary>
public class MonsterVision : MonoBehaviour
{
    // post processing
    [SerializeField] private Color specialAbilityColor = Color.blue;
    [SerializeField] private Volume volume;
    [SerializeField] private float lerpTime = 5.0f;
    private UnityEngine.Rendering.Universal.ColorAdjustments colorAdjustments;
    private Color currentColor;

    // culling handle
    [SerializeField] private Camera spiderXRayCamera;
    [SerializeField] private LayerMask spiderDetectionLayer;
    private bool canUseVision = true;


    // material switch signal
    public delegate void SwitchMaterial();
    public static event SwitchMaterial SwitchMaterialSignal;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void Start()
    {
        volume.profile.TryGet<UnityEngine.Rendering.Universal.ColorAdjustments>(out this.colorAdjustments);
        currentColor = colorAdjustments.colorFilter.value;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VisionEnable()
    {
        if (!canUseVision) return;
        StartCoroutine(LerpColorAndHandleCanUseVision(colorAdjustments.colorFilter.value, specialAbilityColor, lerpTime));
        SwitchMaterialSignal?.Invoke();
        spiderXRayCamera.cullingMask = spiderDetectionLayer;
    }

    public void VisionDisable()
    {
        if (!canUseVision) return;
        Debug.Log("Disable special");
        StartCoroutine(LerpColorAndHandleCanUseVisionOnce(specialAbilityColor, currentColor, lerpTime));
        SwitchMaterialSignal?.Invoke();
        spiderXRayCamera.cullingMask = 0;
    }

    private IEnumerator LerpColorAndHandleCanUseVision(Color fromColor, Color toColor, float duration)
    {

        canUseVision = false;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration; // 0 to 1
            colorAdjustments.colorFilter.value = Color.Lerp(fromColor, toColor, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        colorAdjustments.colorFilter.value = toColor;
        canUseVision = true;
        VisionDisable(); // reset all changes
    }

    private IEnumerator LerpColorAndHandleCanUseVisionOnce(Color fromColor, Color toColor, float duration)
    {

        canUseVision = false;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration; // 0 to 1
            colorAdjustments.colorFilter.value = Color.Lerp(fromColor, toColor, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        colorAdjustments.colorFilter.value = toColor;
        canUseVision = true;
    }


}
