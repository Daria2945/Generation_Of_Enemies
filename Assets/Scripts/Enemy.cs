using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Mover))]
public class Enemy : MonoBehaviour
{
    private Vector3 _direction;
    private Mover _mover;

    private Action<Enemy> _destroyAction;

    public void InitializeAction(Action<Enemy> destroyAction)
    {
        _destroyAction = destroyAction;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void Start()
    {
        _mover = GetComponent<Mover>();
        _mover.SetDitection(_direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        _destroyAction(this);
    }
}