using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _speed = 2.5f;
    private Vector3 _direction;

    public void SetDitection(Vector3 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        if(_direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_direction);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
        }
    }
}