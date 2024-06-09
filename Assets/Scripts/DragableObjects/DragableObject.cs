using UnityEngine;

public class DragableObject : MonoBehaviour
{
    public bool IsPlayerOnObject { get; private set; }
    private bool _isCollidingWithGround;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isCollidingWithGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isCollidingWithGround = false;
        }
    }

    public bool IsCollidingWithGround()
    {
        return _isCollidingWithGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerOnObject = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerOnObject = false;
        }
    }
}
