using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RemoveOnEnding : MonoBehaviour
{
    ParticleSystem particle;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (particle.isPlaying==false)
        {
            Destroy(gameObject);
        }
    }
}
