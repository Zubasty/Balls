using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private float _speed;
    private int _score;
    private Rigidbody _rb;
    public event Action<int> Died;
    public event Action<int> Killed;
    public event Action<Ball> EndedLife;
    public int Score => _score;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void Initialization(float speed, int score)
    {
        _speed = speed;
        _score = score;
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(new Vector3(transform.position.x,transform.position.y-_speed, transform.position.z));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out DieZone dieZone))
        {
            Died?.Invoke(_score);
            EndLife();
        }
    }
    private void OnMouseDown()
    {
        Killed?.Invoke(_score);
        EndLife();
    }
    private void EndLife()
    {
        EndedLife?.Invoke(this);
        Destroy(gameObject);
    }
}
