using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objective system
/// 
/// </summary>
public class ObjectiveManager : MonoBehaviour { 

    [SerializeField] private List<string> objectives;
    public delegate void AddObjective(string obj);
    public static event AddObjective OnAddObjective;

    public delegate void AddObjectiveUI(string obj);
    public static event AddObjectiveUI OnAddObjectiveUI;
    [SerializeField] private AudioSource newObjective;

    private ObjectiveManager objectiveManager;

    private void OnEnable()
    {
        ObjectiveManager.OnAddObjective += AddObjectiveToList;
    }

    private void OnDisable()
    {
        ObjectiveManager.OnAddObjective -= AddObjectiveToList;
    }

    public void AddObjectiveToList(string objective)
    {
        objectives.Add(objective);
        // play new objective sound
        newObjective.Play();
        // Invoke event to show objective on UI.
        OnAddObjectiveUI?.Invoke(objective);
    }


    public static void Trigger(string objective)
    {
        OnAddObjective?.Invoke($"Objective: {objective}");
    }

    // Remove the latest objective
    public void RemoveObjective()
    {
        objectives.RemoveAt(objectives.Count - 1);
    }
}
