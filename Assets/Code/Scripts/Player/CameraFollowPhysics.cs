using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPhysics : MonoBehaviour
{
    [SerializeField] private Transform _physicsTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _physicsTransform.position;
    }
}
