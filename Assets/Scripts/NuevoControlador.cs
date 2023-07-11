using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoControlador : MonoBehaviour
{
    private Rigidbody2D playerRB;

    public float jumpForce = 5f;
    public float playerSpeed = 5f;
    public LayerMask groundMask;
    private Animator animator;

    public bool grounded; //Raycast para evitar doble salto con grounded

    private SpriteRenderer spriteRenderer;  //Flip X


    //  public float SegEspera = 5f; //Corutina para espera

    //   Vector3 startPosition;


    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        //        currentHealth = maxHealth;
        //Debug.Log(currentHealth);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); //Flip X
                                                         //      startPosition = this.transform.position;
    }

    public void StartGame()
    {
        PlayerMovement();
        //    this.transform.position = startPosition;
        //      this.playerRB.velocity = Vector2.zero;
    }
    private void Update()
    {
        PlayerMovement();
        Jump();
        Debug.DrawRay(this.transform.position, Vector2.down * 2f, Color.red);
        Debug.DrawRay(this.transform.position, Vector2.one * 2f, Color.red);
        IsTouchingTheGround();
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsTouchingTheGround())
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isShooting", false);
            // if (Equals(KeyCode.Space))
            // {
            //     animator.SetBool("isJumping", true);

        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
    bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.5f, groundMask) || (Physics2D.Raycast(this.transform.position, Vector2.one, 1.5f, groundMask)))
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
    //     IEnumerator Esperar()
    // {
    //     float Espera = 1f;
    //     yield return new WaitForSeconds(Espera);
    // }

    void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");


        Vector2 movement = new Vector2(moveHorizontal, 0);
        playerRB.AddForce(movement * playerSpeed); //movement * speed * Time.deltaTime;
        if (moveHorizontal != 0f)
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
            //   spriteRenderer.flipX = false; // Hace que gire a la derecha con FLIP X
        }

        if (moveHorizontal > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveHorizontal < 0f)
        {
            spriteRenderer.flipX = true;
        }

        //      if (spriteRenderer.flipX) //Flip X
        //     {
        //   spriteRenderer.flipX = false;
        //     }
        //      else
        //          spriteRenderer.flipX = true;

    }

}
