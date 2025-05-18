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


    public delegate void TurnGeneratorOn();
    public static event TurnGeneratorOn OnGeneratorTurned;
    
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
            OnGeneratorTurned?.Invoke();
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("No way generator runs");
        }

    }


    /// <summary>
    /// Checks for generator parts
    /// </summary>
    /// <param name="isCogValid">bool reference to declare on parent func</param>
    /// <param name="isBatteryValid"></param>
    /// <param name="batteryAmount">Number of batteries required to turn on Generator</param>
    /// <param name="cogAmount"> Number of cogs to turn on Generator</param>
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
