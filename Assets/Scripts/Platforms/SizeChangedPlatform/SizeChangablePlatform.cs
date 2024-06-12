using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangablePlatform : MonoBehaviour
{
    public bool IsPlayerOnObject;
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
