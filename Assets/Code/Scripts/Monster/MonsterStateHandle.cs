using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateHandle : MonoBehaviour
{
    public enum MONSTER_TYPE  {
        Attack,
        Patrol
    }

    private MONSTER_TYPE currentState = MONSTER_TYPE.Patrol;
    
    public MONSTER_TYPE GetCurrentState()
    {
        return currentState;
    }

    public void SetMonsterType(MONSTER_TYPE state)
    {
        currentState = state;
    }


}
