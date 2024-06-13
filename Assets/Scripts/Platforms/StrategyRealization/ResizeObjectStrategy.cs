using UnityEngine;

public class ResizeObjectStrategy : IObjectManipulationStrategy
{
    private Transform _transform;
    private float _resizeSpeed;
    private float _minSizeX;
    private float _maxSizeX;

    public ResizeObjectStrategy(Transform transform, float resizeSpeed, float minSizeX, float maxSizeX)
    {
        _transform = transform;
        _resizeSpeed = resizeSpeed;
        _minSizeX = minSizeX;
        _maxSizeX = maxSizeX;
    }

    public void ManipulateObject(float input)
    {
        Vector3 newScale = _transform.localScale;
        newScale.x = Mathf.Clamp(newScale.x + input * _resizeSpeed * Time.deltaTime, _minSizeX, _maxSizeX);
        _transform.localScale = newScale;
    }
}
