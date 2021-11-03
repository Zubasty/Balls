using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallParticle : MonoBehaviour
{
    [SerializeField] private BallSpawner _ballSpawner;
    [SerializeField] private ParticleSystem _particleSystemPrefab;
    private void OnEnable()
    {
        _ballSpawner.CreatedBall += OnCreatedBall;
    }
    private void OnCreatedBall(Ball ball)
    {
        ball.EndedLife += OnBallEndLife;
    }
    private void OnBallEndLife(Ball ball)
    {
        ParticleSystem particleSystem = Instantiate(_particleSystemPrefab, ball.transform.position, _particleSystemPrefab.transform.rotation);
        if(ball.TryGetComponent(out Renderer renderer))
        {
            ParticleSystem.MainModule main = particleSystem.main;
            main.startColor = renderer.sharedMaterial.color;
            Destroy(particleSystem.gameObject, main.duration + main.startLifetime.constant + 1);
        }
    }
    private void OnDisable()
    {
        _ballSpawner.CreatedBall -= OnCreatedBall;
    }
}
