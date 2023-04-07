using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSimulation : MonoBehaviour
{
    public Material snowMaterial;
    public float particleSize = 0.1f;
    public float windStrength = 0.1f;

    private ParticleSystem particleSystem;
    private ParticleSystem.MainModule mainModule;
    private ParticleSystem.EmissionModule emissionModule;
    private ParticleSystemRenderer particleSystemRenderer;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        mainModule = particleSystem.main;
        emissionModule = particleSystem.emission;
        particleSystemRenderer = GetComponent<ParticleSystemRenderer>();

        mainModule.startLifetime = new ParticleSystem.MinMaxCurve(10f, 20f);
        mainModule.startSpeed = new ParticleSystem.MinMaxCurve(0.1f, 0.5f);
        mainModule.startSize = new ParticleSystem.MinMaxCurve(particleSize, particleSize * 2f);
        mainModule.maxParticles = 1000000000;
        mainModule.loop = true;
        mainModule.simulationSpace = ParticleSystemSimulationSpace.World;
        mainModule.scalingMode = ParticleSystemScalingMode.Shape;

        emissionModule.rateOverTime = 100f;

        particleSystemRenderer.material = snowMaterial;

        ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = particleSystem.velocityOverLifetime;
        velocityOverLifetime.x = new ParticleSystem.MinMaxCurve(-windStrength, windStrength);
        velocityOverLifetime.y = new ParticleSystem.MinMaxCurve(-windStrength, windStrength);
        velocityOverLifetime.z = new ParticleSystem.MinMaxCurve(-windStrength, windStrength);
    }

    void Update()
    {
        mainModule.startSize = new ParticleSystem.MinMaxCurve(particleSize, particleSize * 2f);
        ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = particleSystem.velocityOverLifetime;
        velocityOverLifetime.x = new ParticleSystem.MinMaxCurve(-windStrength, windStrength);
        velocityOverLifetime.y = new ParticleSystem.MinMaxCurve(-windStrength, windStrength);
        velocityOverLifetime.z = new ParticleSystem.MinMaxCurve(-windStrength, windStrength);
    }
}

