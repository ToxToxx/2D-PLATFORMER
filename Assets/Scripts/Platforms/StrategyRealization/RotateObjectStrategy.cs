using UnityEngine;

public class RotateObjectStrategy : IObjectManipulationStrategy
{
    private Transform _transform;
    private float _rotationSpeed;

    public RotateObjectStrategy(Transform transform, float rotationSpeed)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    public void ManipulateObject(float input)
    {
        _transform.Rotate(Vector3.forward, -input * _rotationSpeed * Time.deltaTime);
    }
}
