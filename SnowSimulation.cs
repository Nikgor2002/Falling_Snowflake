using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snowflake : MonoBehaviour
{
    public Material snowMaterial;
    public float particleSize = 0.1f;

    private ParticleSystem particleSystem;
    private ParticleSystem.MainModule mainModule;
    private ParticleSystem.EmissionModule emissionModule;
    private ParticleSystemRenderer particleSystemRenderer;
    private float _tick = 0;
    private Vector3 _startLocation;

    void Start()
    {
        _startLocation = transform.localPosition;
        particleSystem = GetComponent<ParticleSystem>();
        mainModule = particleSystem.main;
        emissionModule = particleSystem.emission;
        particleSystemRenderer = GetComponent<ParticleSystemRenderer>();

        mainModule.startLifetime = new ParticleSystem.MinMaxCurve(25f, 30f);
        mainModule.startSpeed = new ParticleSystem.MinMaxCurve(0.2f, 0.3f);
        mainModule.startSize = new ParticleSystem.MinMaxCurve(0.1f, 0.2f);
        mainModule.maxParticles = 1000000000;
        mainModule.loop = true;

        mainModule.simulationSpace = ParticleSystemSimulationSpace.World;
        mainModule.scalingMode = ParticleSystemScalingMode.Shape;

        emissionModule.rateOverTime = 10000f;

    }

    void Update()
    {
        _tick += 0.002f;
        float x = (float)(10 * Math.Sin(_tick));
        float y = _tick / 10;
        float z = (float)(10 * Math.Cos(_tick));
        Vector3 addVector = new Vector3(x, y, z);

        Vector3 alfa = _startLocation - addVector;
        if (alfa[1] < -4.0f)
        {
            alfa = _startLocation;
            _tick = 0f;
        }
        transform.localPosition = alfa;

    }
}