using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private BallSpawner _ballSpawner;
    private int _score = 0;
    public event Action<int> SetedScore;
    public int Score => _score;
    private void OnEnable()
    {
        _ballSpawner.CreatedBall += OnCreatedBall;
    }
    private void OnCreatedBall(Ball ball)
    {
        ball.Killed += OnKilledBall;     
    }
    private void OnKilledBall(int score)
    {
        _score += score;
        SetedScore?.Invoke(_score);
    }
    private void OnDisable()
    {
        _ballSpawner.CreatedBall -= OnCreatedBall;
    }
}
