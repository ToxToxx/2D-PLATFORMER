using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed = 1f;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = _pointB.position;
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
        }
    }

    public void ChangePoint()
    {
        _targetPosition = _targetPosition == _pointB.position ? _pointA.position : _pointB.position;
    }
}
