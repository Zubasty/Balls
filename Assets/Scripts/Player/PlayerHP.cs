using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private BallSpawner _ballSpawner;
    public event Action<int> SetedHp;
    public event Action LosePlayer;
    public int HP
    {
        private set
        {
            _hp = value;
            if(_hp < 0)
            {
                _hp = 0;
                LosePlayer?.Invoke();
                Time.timeScale = 0;
            }
            SetedHp?.Invoke(_hp);
        }
        get
        {
            return _hp;
        }
    }
    private void OnEnable()
    {
        _ballSpawner.CreatedBall += OnCreatedBall;
    }
    private void OnCreatedBall(Ball ball)
    {
        ball.Died += OnBallDied;
    }
    private void OnBallDied(int score)
    {
        HP -= score;
    }
    private void OnDisable()
    {
        _ballSpawner.CreatedBall -= OnCreatedBall;
    }
}
