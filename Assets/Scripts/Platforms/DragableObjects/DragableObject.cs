using UnityEngine;

public class DragableObject : MonoBehaviour
{
    public bool IsPlayerOnObject;
    private bool isRotating;
    [SerializeField] private float rotationSpeed = 100f;

    private void Update()
    {
        if (isRotating)
        {
            RotateObject();
        }
    }

    private void RotateObject()
    {
        float scrollInput = Input.mouseScrollDelta.y;
        transform.Rotate(Vector3.forward, -scrollInput * rotationSpeed * Time.deltaTime);
    }

    public void StartRotation()
    {
        isRotating = true;
    }

    public void StopRotation()
    {
        isRotating = false;
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

