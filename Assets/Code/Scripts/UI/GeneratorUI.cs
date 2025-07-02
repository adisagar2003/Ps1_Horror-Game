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

            if (globalData == null)
            {
                Debug.LogError("GlobalData not found in scene!");
                return;
            }
            pickableAmountPairs = globalData.GetItems();
            if (pickableAmountPairs == null)
            {
                Debug.LogError("pickableAmountPairs is null from GlobalData.GetItems()");
            }
        }

    
        /// <summary>
        /// On Start clicked
        /// </summary>
        public void OnStartButtonPressed()
        {
            pickableAmountPairs = globalData.GetItems();

            bool isCogValid = false;
            bool isBatteryValid = false;

            // check for 1 battery, 1 cog
            CheckForValidPartsGenerator(ref isCogValid, ref isBatteryValid,1,1);

            if (isBatteryValid && isCogValid)
            {
                Debug.Log("Generator Will Run");
                OnGeneratorTurned?.Invoke();
            }
            else
            {
                Debug.Log("No way generator runs");
                DialogueSystem.Trigger("Not enough parts...");
            }

        }


        /// <summary>
        /// Checks for generator parts
        /// </summary>
        /// <param name="isCogValid">bool reference to declare on parent func</param>
        /// <param name="isBatteryValid"></param>
        /// <param name="batteryAmount">Number of batteries required to turn on Generator</param>
        /// <param name="cogAmount"> Number of cogs to turn on Generator</param>
        public void CheckForValidPartsGenerator(ref bool isCogValid, ref bool isBatteryValid, int batteryAmount, int cogAmount)
        {
            pickableAmountPairs = globalData.GetItems();

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
