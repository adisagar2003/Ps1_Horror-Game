using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogPickable : BasePickable
{
    [SerializeField] private AudioSource pickupSound;
    public override void Pickup()
    {
        base.Pickup();
        pickupSound.Play();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) Pickup();
        Destroy(gameObject);
    }

    private void Update()
    {
       
    }

}
