using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColor : MonoBehaviour
{
    [SerializeField] private BallSpawner _ballSpawner;
    private void OnEnable()
    {
        _ballSpawner.CreatedBall += OnCreatedBall;
    }
    private void OnCreatedBall(Ball ball)
    {
        if(ball.TryGetComponent(out Renderer renderer))
        {
            float r = (float)ball.Score / _ballSpawner.MaxScoreForOneBall;
            float g = (float)(_ballSpawner.MaxScoreForOneBall - ball.Score) / _ballSpawner.MaxScoreForOneBall;
            renderer.material.color = new Color(r, g, 0);
        }
    }
    private void OnDisable()
    {
        _ballSpawner.CreatedBall -= OnCreatedBall;
    }
}