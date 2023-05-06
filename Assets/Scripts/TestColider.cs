using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColider : MonoBehaviour
{
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision Detectada");
        Destroy(collision.gameObject);
      
        // Aqui es donde puedes agregar cualquier accion que quieras realizar cuando ocurra una colision

    }
}
