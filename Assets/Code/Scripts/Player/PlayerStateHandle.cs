using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandle : MonoBehaviour
{
    public enum PlayerState {
        IsInteracting, 
        Playable
    }

    public PlayerState currentState;

    private void Start()
    {
        currentState = PlayerState.Playable;    
    }
    public void SwitchStateTo(PlayerState currState)
    {
        currentState = currState;
    }

    private void OnEnable()
    {
        Generator.OnEnablePlayer += EnablePlayer;
        Generator.OnDisablePlayer += DisablePlayer;
    }

    private void OnDisable()
    {
        Generator.OnEnablePlayer -= EnablePlayer;
        Generator.OnDisablePlayer -= DisablePlayer;
    }

    public void EnablePlayer()
    {
        currentState = PlayerState.Playable;
    }

    public void DisablePlayer()
    {
        currentState = PlayerState.IsInteracting;
    }

    public PlayerState GetCurrentState()
    {
        return currentState;
    }
}
