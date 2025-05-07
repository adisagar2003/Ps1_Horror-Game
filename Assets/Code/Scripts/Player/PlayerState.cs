using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Generator;

public class PlayerState : MonoBehaviour
{
    public enum PlayerCurrentState {
        IsInteracting, 
        Playable
    }

    public PlayerCurrentState _currentState;

    private void Start()
    {
        _currentState = PlayerCurrentState.Playable;    
    }
    public void SwitchStateTo(PlayerCurrentState currState)
    {
        _currentState = currState;
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
        _currentState = PlayerCurrentState.Playable;
    }

    public void DisablePlayer()
    {
        _currentState = PlayerCurrentState.IsInteracting;
    }
}
