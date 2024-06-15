using UnityEngine;

public class RotatablePlatform : MonoBehaviour
{
    public bool _isPlayerOnObject;
    private bool _isManipulating;
    private IObjectManipulationStrategy manipulationStrategy;
    [SerializeField] private float rotationSpeed = 1000f;

    private void Start()
    {
        manipulationStrategy = new RotateObjectStrategy(transform, rotationSpeed);
    }

    private void Update()
    {
        if (_isManipulating)
        {
            float scrollInput = Input.mouseScrollDelta.y;
            manipulationStrategy.ManipulateObject(scrollInput);
        }
    }

    public void StartManipulation()
    {
        _isManipulating = true;
    }

    public void StopManipulation()
    {
        _isManipulating = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementController>())
        {
            _isPlayerOnObject = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementController>())
        {
            _isPlayerOnObject = false;
        }
    }
}
