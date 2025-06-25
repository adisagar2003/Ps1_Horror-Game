using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Handles Movement of monster
/// Milestone 1 :- Get Spider to patrol different points in the navmesh
/// </summary>
public class MonsterMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float patrolRadius = 100.0f;

    // Patrol logic
    private Vector3 currentDestination;
    [SerializeField] private float minDistanceToSetNewDestination = 3.0f;

    // State Handle
    private PlayerMovement playerMovement; 
    private MonsterStateHandle monsterStateHandle;

    void Start()
    {
        monsterStateHandle = GetComponent<MonsterStateHandle>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        SetNewDestination();
    }

    // Returns random point in maze
    private Vector3 GetRandomMazePoint()
    {
        // get a random point till this range
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1);
        return hit.position;
    }

    // sets and moves 
    private void SetNewDestination()
    {
        currentDestination = GetRandomMazePoint();
        navMeshAgent.SetDestination(currentDestination);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(currentDestination, minDistanceToSetNewDestination);
    }

    private void Update()
    {
        if (monsterStateHandle.GetCurrentState() == MonsterStateHandle.MONSTER_TYPE.Patrol)
        {
            ResetPathIfTooClose();
        } 
        else
        {
            ChasePlayer();
        }
    }

    private void ResetPathIfTooClose()
    {
        if (Vector3.Distance(currentDestination, transform.position) < minDistanceToSetNewDestination)
        {
            SetNewDestination();
        }
       
    }

    private void ChasePlayer()
    {
        navMeshAgent.destination = playerMovement.transform.position;
    }
}
