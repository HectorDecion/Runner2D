using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
            {
            if(collision.tag == "Player")
            {
                PlayerMovement movement = collision.GetComponent<PlayerMovement>();
                movement.Die();
        }                

        }
    }
