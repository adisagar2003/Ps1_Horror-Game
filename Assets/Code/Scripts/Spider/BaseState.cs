using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public bool _isCompleted { get; private set; }
    protected float startTime;

    // spider should have a base 
    protected Spider _spider;
    protected StateMachine _stateMachine;
    protected string _stateName;
    public float time => Time.time - startTime;

    public BaseState(string stateName, Spider spiderRef, StateMachine enemyStateMachine)
    {
        this._stateName = stateName;
        this._spider = spiderRef;
        this._stateMachine = enemyStateMachine;
    }   

    public abstract void EnterState();

    public abstract void ExitState();

    public abstract string GetStateName();
    public abstract void OnUpdateState();

    public abstract void OnFixedUpdateState();
}
