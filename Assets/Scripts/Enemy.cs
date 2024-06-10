using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Vector3 _direction;
    private Mover _mover;

    private void Start()
    {
        _mover = GetComponent<Mover>();
        _mover.SetDitection(_direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DestroyZone>())
            Die();
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}