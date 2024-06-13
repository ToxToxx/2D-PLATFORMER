using UnityEngine;

public class ResizeObjectStrategy : IObjectManipulationStrategy
{
    private Transform _transform;
    private float _resizeSpeed;

    public ResizeObjectStrategy(Transform transform, float resizeSpeed)
    {
        _transform = transform;
        _resizeSpeed = resizeSpeed;
    }

    public void ManipulateObject(float input)
    {
        Vector3 newScale = _transform.localScale;
        newScale.x += input * _resizeSpeed * Time.deltaTime;
        _transform.localScale = newScale;
    }
}
