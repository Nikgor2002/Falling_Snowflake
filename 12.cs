
using System.Collections;
using System.Collections.Generic;
// using UnityEngine;

// public class 12 : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }

using UnityEngine;

public class SnowGenerator : MonoBehaviour
{
    public ParticleSystem snowParticleSystem;
    public float snowflakeSize = 0.1f;
    public float temperature = 0f;
    public float windSpeed = 0f;
    public float time = 0f;

    private ParticleSystem.Particle[] particles;
    private int numParticles = 1000;

    void Start()
    {
        particles = new ParticleSystem.Particle[numParticles]; 
        // Инициализируйте массив particles размером numParticles
        snowParticleSystem.Emit(numParticles); 
        // Выбрасывtть снежинки numParticles из системы snow Particle System
    }

    void Update()
    {
        snowParticleSystem.GetParticles(particles); 
        // Получаем текущие частицы из системы частиц снега и сохраните их в массиве частиц

        float adjustedWindSpeed = windSpeed + Mathf.Sin(time * Mathf.PI * 2f) * 2f;
        // Рассчитываем скорректированную скорость ветра на основе параметров скорости ветра и времени. Используя синусоидальную волну 
        // для регулировки скорости ветра, мы создаем более естественный и динамичный эффект ветра, который меняется с течением времени. 
        // Это может сделать симуляцию снега более реалистичной и захватывающей.

        for (int i = 0; i < numParticles; i++) // // Повторяем цикл по каждой частице в массиве частиц
        {
            particles[i].position += new Vector3(Random.Range(-adjustedWindSpeed, adjustedWindSpeed), -0.1f, 0f);
            // Обновление положения частиц на основе скорректированной скорости ветра
            particles[i].startSize = snowflakeSize;
            particles[i].startColor = Color.white;
            particles[i].remainingLifetime = Mathf.Infinity;
        }

        snowParticleSystem.SetParticles(particles, numParticles); 
        // Устанавливаем обновлённые частицы обратно в систему частиц снега
    }
}
