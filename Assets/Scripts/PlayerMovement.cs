using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float jumpForce = 10f;
    [SerializeField]public float speed = 10f;
    private Rigidbody2D playerRB;
    public bool grounded;

    public LayerMask groundMask;
  
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        grounded = true;
    }
    private void Update()
    {
        Debug.DrawRay(this.transform.position, Vector2.down * 2.0f, Color.red);

    }
 
    private void FixedUpdate()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
      //  movement.Normalize();
       // GetComponent<Rigidbody2D>().velocity = movement * speed * Time.deltaTime;
        playerRB.velocity = movement * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetButton("Fire1"))
        {
            Jump();

        }
    }

        void Jump()
        {
            if(IsTouchingTheGround())
            {
                playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
                }
 bool IsTouchingTheGround()
    {
        if(Physics2D.Raycast(this.transform.position,Vector2.down, 2.0f, groundMask)) 
        {
            grounded = true;
            return true;
        }
        else 
        {
            grounded = false;
            return false; 
        }
    }

}
