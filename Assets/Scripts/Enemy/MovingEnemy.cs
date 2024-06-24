using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed = 1f;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = _pointB.position;
        FlipIfNeeded();
    }

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
        {
            ChangePoint();
            FlipIfNeeded();
        }
    }

    public void ChangePoint()
    {
        _targetPosition = _targetPosition == _pointB.position ? _pointA.position : _pointB.position;
    }

    private void FlipIfNeeded()
    {
        Vector3 direction = _targetPosition - transform.position;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
