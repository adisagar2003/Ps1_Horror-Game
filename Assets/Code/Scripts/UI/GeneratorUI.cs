using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shows UI Generator
/// </summary>
public class GeneratorUI : MonoBehaviour
{
    private GlobalData globalData;
    private Dictionary<SOBasePickable, int> pickableAmountPairs;
    
    private void Start()
    {
        globalData = FindFirstObjectByType<GlobalData>();
        pickableAmountPairs = globalData.GetItems();
    }

    /// <summary>
    /// On Start clicked
    /// </summary>
    public void OnStartButtonPressed()
    {

        bool isCogValid = false;
        bool isBatteryValid = false;

        // check for 3 batteries, 2 cogs
        CheckForValidPartsGenerator(ref isCogValid, ref isBatteryValid,3,2);

        if (isBatteryValid && isCogValid)
        {
            Debug.Log("Generator Will Run");
        }
        else
        {
            Debug.Log("No way generator runs");
        }

    }

    private void CheckForValidPartsGenerator(ref bool isCogValid, ref bool isBatteryValid, int batteryAmount, int cogAmount)
    {
        foreach (KeyValuePair<SOBasePickable, int> keyValue in pickableAmountPairs)
        {
            bool checkForBattery = (keyValue.Key.name == "Battery" && keyValue.Value >= batteryAmount);
            bool checkForCog = (keyValue.Key.name == "Cog" && keyValue.Value >= cogAmount);
            if (checkForBattery)
            {
                isBatteryValid = true;
            }

            if (checkForCog)
            {
                isCogValid = true;
            }
        }
    }

}
