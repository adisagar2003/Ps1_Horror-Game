using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Spider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _target;
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(_target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
