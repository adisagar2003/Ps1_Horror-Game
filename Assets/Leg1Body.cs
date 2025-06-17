using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg1Body : MonoBehaviour
{
    [SerializeField] private float sphereRadius = 1.4f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
}
