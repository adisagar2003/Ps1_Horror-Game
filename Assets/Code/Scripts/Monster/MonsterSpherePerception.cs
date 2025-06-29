using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
   // Hanldes detection for things inside. 
   // Make a raycast for periperal detection
/// </summary>
public class MonsterSpherePerception : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private List<GameObject> objectsHit;
    [SerializeField] private float monsterVisionLength = 20.0f;
    [SerializeField] private Vector3 visionOffset; // sets the vision accurately
    // event handle -> sends event to scene system to change to chase
    public delegate void SendPerceptionSignal();
    public static event SendPerceptionSignal OnSendPerceptionSignal;

    private void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerPlayerDetection(other);
    }

    private void OnTriggerPlayerDetection(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaycastHit hit;
            Vector3 direction = (playerMovement.transform.position - transform.position).normalized;
            float maxDistance = Vector3.Distance(transform.position, playerMovement.transform.position);
            if (Physics.Raycast(transform.position, direction, out hit, maxDistance, layerMask))
            {
                Debug.DrawRay(transform.position, direction * maxDistance, Color.red, 1f);
                objectsHit.Add(hit.transform.gameObject);
            }

            bool hasPassedThroughWall = false;
            foreach (GameObject hitObject in objectsHit)
            {
                if (hitObject.layer == LayerMask.GetMask("Walls"))
                {
                    hasPassedThroughWall = true;
                }
            }

            if (!hasPassedThroughWall)
            {
                OnSendPerceptionSignal?.Invoke();
                Debug.Log("Chase Implemented");
                objectsHit.Clear();
            } else
            {
                objectsHit.Clear();
            }
        }
    }

    private void SeePlayerAtADistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, monsterVisionLength, LayerMask.GetMask("Player")))
        {
            Debug.DrawRay(transform.position, (Vector3.forward + visionOffset) * monsterVisionLength, Color.red, 1f);
            OnSendPerceptionSignal?.Invoke();
        }

    }

    private void Update()
    {
        Debug.DrawRay(transform.position, playerMovement    .transform.position, Color.cyan) ;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector3.forward + visionOffset) * monsterVisionLength);
    }
}
