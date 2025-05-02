using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState currentState { get; private set; }

    public void Initialize(BaseState state)
    {
        if (currentState != null) currentState.ExitState();
        currentState = state;
        currentState.EnterState();
    }

    public void ChangeState(BaseState state)
    {
        currentState.ExitState();
        currentState = state;
        currentState.EnterState();
    }

}
