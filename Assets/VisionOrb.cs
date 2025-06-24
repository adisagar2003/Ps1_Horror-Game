using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionOrb : MonoBehaviour
{
    private MonsterVision monsterVision;
    [SerializeField] private AudioClip itemAcquiredAudio;

    private void Start()
    {
        monsterVision = FindFirstObjectByType<MonsterVision>();
    }
    private void OnTriggerEnter(Collider other)
    {
        monsterVision.VisionEnable();
        AudioSource.PlayClipAtPoint(itemAcquiredAudio, transform.position);
        Destroy(gameObject);
    }
}
