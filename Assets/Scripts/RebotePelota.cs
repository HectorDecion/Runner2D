using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebotePelota : MonoBehaviour
{
    public float velocidad = 10f;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(1, 1).normalized;
        rb2D.velocity = direccion * velocidad;
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        Vector2 normal = collision.contacts[0].normal;
        rb2D.velocity = Vector2.Reflect(rb2D.velocity, normal) * velocidad;
 
    }

}
