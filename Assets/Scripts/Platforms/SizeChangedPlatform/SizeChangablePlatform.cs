using UnityEngine;

public class SizeChangablePlatform : MonoBehaviour
{
    public bool IsPlayerOnObject;
    private bool _isManipulating;
    private IObjectManipulationStrategy _platformManipulationStrategy;

    [SerializeField] private float resizeSpeed = 500f;
    [SerializeField] private float minSizeX = 0.5f;
    [SerializeField] private float maxSizeX = 3f;

    private void Start()
    {
        _platformManipulationStrategy = new ResizeObjectStrategy(transform, resizeSpeed, minSizeX, maxSizeX);
    }

    private void Update()
    {
        if (_isManipulating)
        {
            float scrollInput = Input.mouseScrollDelta.y;
            _platformManipulationStrategy.ManipulateObject(scrollInput);
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
            IsPlayerOnObject = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementController>())
        {
            IsPlayerOnObject = false;
        }
    }
}
