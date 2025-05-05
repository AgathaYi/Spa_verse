using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    [SerializeField] private bool particleOnFly = true;
    [SerializeField] private ParticleSystem flyParticleSystem;

    public void ParticleFly()
    {
        if (particleOnFly)
        {
            flyParticleSystem.Play();
        }
    }
}
