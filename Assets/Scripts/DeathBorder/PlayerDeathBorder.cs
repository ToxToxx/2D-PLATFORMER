using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathBorder : MonoBehaviour
{
    [SerializeField] private GameObject _respawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementController>())
        {
            collision.gameObject.transform.position = _respawnPoint.gameObject.transform.position;
        }
    }

}
