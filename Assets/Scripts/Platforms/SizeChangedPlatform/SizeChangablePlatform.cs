using UnityEngine;

public class SizeChangablePlatform : MonoBehaviour
{
    public bool IsPlayerOnObject;
    private bool isManipulating;
    private IObjectManipulationStrategy manipulationStrategy;
    [SerializeField] private float resizeSpeed = 0.1f;

    private void Start()
    {
        manipulationStrategy = new ResizeObjectStrategy(transform, resizeSpeed);
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
