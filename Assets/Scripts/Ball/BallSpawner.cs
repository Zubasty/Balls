using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private float _startSpeed;
    [SerializeField] private int _maxScoreForOneBall;
    [SerializeField] private float _boostSpeed;
    [SerializeField] private float _minTimeSpawn;
    [SerializeField] private float _maxTimeSpawn;
    [SerializeField] private Ball _ballPrefab;
    private float _timerForSpawn;
    private float _nowSpeed;
    public event Action<Ball> CreatedBall;
    public int MaxScoreForOneBall => _maxScoreForOneBall;
    private float TimeNextSpawn => UnityEngine.Random.Range(_minTimeSpawn, _maxTimeSpawn);
    private void Awake()
    {
        _timerForSpawn = TimeNextSpawn;
        _nowSpeed = _startSpeed;
    }
    private void Update()
    {
        _nowSpeed += Time.deltaTime * _boostSpeed;
        TickForSpawn();
    }
    private void TickForSpawn()
    {
        _timerForSpawn -= Time.deltaTime;
        if (_timerForSpawn <= 0)
        {
            Spawn();
            ResetTimer();
        }
    }
    private void Spawn()
    {
        Vector3 position = new Vector3(UnityEngine.Random.Range(-_position.x, _position.x), _position.y, _position.z);
        Ball ball = Instantiate(_ballPrefab, position, Quaternion.identity);
        ball.Initialization(_nowSpeed, UnityEngine.Random.Range(1, _maxScoreForOneBall + 1));
        CreatedBall?.Invoke(ball);
    }
    private void ResetTimer()
    {
        _timerForSpawn = TimeNextSpawn;
    }
}
