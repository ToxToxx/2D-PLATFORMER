using UnityEngine;

public class RotatablePlatform : MonoBehaviour
{
    public bool IsPlayerOnObject;
    private bool isManipulating;
    private IObjectManipulationStrategy manipulationStrategy;
    [SerializeField] private float rotationSpeed = 100f;

    private void Start()
    {
        manipulationStrategy = new RotateObjectStrategy(transform, rotationSpeed);
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
