using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Switches materials recursively on this object and its children.
/// Listens to MonsterVision events.
/// </summary>
public class MonsterMaterialSwitch : MonoBehaviour
{
    [SerializeField] private Material materialToSwitch;

    private Dictionary<Renderer, Material[]> originalMaterials = new Dictionary<Renderer, Material[]>();

    private void OnEnable()
    {
        MonsterVision.SwitchMaterialSignal += SwitchMaterialSignalListener;
    }

    private void OnDisable()
    {
        MonsterVision.SwitchMaterialSignal -= SwitchMaterialSignalListener;
    }

    private void SwitchMaterialSignalListener()
    {
        if (originalMaterials.Count > 0)
        {
            RestoreOriginalMaterials();
        }
        else
        {
            SwitchMaterialRecursively(transform);
        }
    }

    private void SwitchMaterialRecursively(Transform obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            if (!originalMaterials.ContainsKey(renderer))
            {
                originalMaterials[renderer] = renderer.sharedMaterials;

                Material[] visionMats = new Material[renderer.sharedMaterials.Length];
                for (int i = 0; i < visionMats.Length; i++)
                {
                    visionMats[i] = materialToSwitch;
                }

                renderer.sharedMaterials = visionMats;
            }
        }

        // Recurse into children
        foreach (Transform child in obj)
        {
            SwitchMaterialRecursively(child);
        }
    }

    private void RestoreOriginalMaterials()
    {
        foreach (var kvp in originalMaterials)
        {
            if (kvp.Key != null)
            {
                kvp.Key.sharedMaterials = kvp.Value;
            }
        }

        originalMaterials.Clear();
    }
}
