using UnityEngine;

public class SizeChangablePlatform : MonoBehaviour
{
    public bool IsPlayerOnObject;
    private bool isManipulating;
    private IObjectManipulationStrategy manipulationStrategy;

    [SerializeField] private float resizeSpeed = 500f;
    [SerializeField] private float minSizeX = 0.5f;
    [SerializeField] private float maxSizeX = 3f;

    private void Start()
    {
        manipulationStrategy = new ResizeObjectStrategy(transform, resizeSpeed, minSizeX, maxSizeX);
    }

    private void Update()
    {
        if (isManipulating)
        {
            float scrollInput = Input.mouseScrollDelta.y;
            manipulationStrategy.ManipulateObject(scrollInput);
        }
    }

    public void StartManipulation()
    {
        isManipulating = true;
    }

    public void StopManipulation()
    {
        isManipulating = false;
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
