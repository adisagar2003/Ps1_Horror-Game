using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Kills the player with this script
/// </summary>
public class MonsterPlayerKill : MonoBehaviour
{
    private MonsterStateHandle monsterState;

    private void Start()
    {
        monsterState = GetComponent<MonsterStateHandle>();
    }
    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
            {
                SceneSystem.Trigger("Died", 0.3f);
            }
    }
}
