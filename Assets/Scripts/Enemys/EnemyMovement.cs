using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float velocidadx = 2f;
    private float velocidady = 2f;
    private Animator animator;
    private Rigidbody2D enemyRB;

    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadx * Time.deltaTime, velocidady * Time.deltaTime, 0);
        if (transform.position.x > 4)
                
                velocidadx = -velocidadx;
            
        if (transform.position.y > 4)
            velocidady = -velocidady;
    }

}
