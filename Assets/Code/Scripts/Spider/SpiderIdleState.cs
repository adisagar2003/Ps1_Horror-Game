using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderIdleState : BaseState
{
    public SpiderIdleState(string stateName, Spider spiderRef, StateMachine enemyStateMachine) : base(stateName, spiderRef, enemyStateMachine)
    {
        this._stateName = "Idle";
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override string GetStateName()
    {
        throw new System.NotImplementedException();
    }

    public override void OnFixedUpdateState()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdateState()
    {
        throw new System.NotImplementedException();
    }
}
