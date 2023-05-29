using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float jumpForce = 10f;
    [SerializeField]public float speed = 10f;
    private Rigidbody2D playerRB;
    public bool grounded;
    [SerializeField] private float runningSpeed = 2f;
    Vector3 startPosition;
    private Animator animator;

    public LayerMask groundMask;
  
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPosition = this.transform.position;
        animator = GetComponent<Animator>();

        grounded = true;
    }
   public void StartGame()
    {
        this.transform.position = startPosition;
        this.playerRB.velocity = Vector2.zero;
    }
    private void Update()
    {
        Debug.DrawRay(this.transform.position, Vector2.down * 2.0f, Color.red);


    }
 
    private void FixedUpdate()
    {
        if(playerRB.velocity.x < runningSpeed
            
            )
        {
            playerRB.velocity = new Vector2(runningSpeed, playerRB.velocity.y);

        }
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
        movement.Normalize();
        GetComponent<Rigidbody2D>().velocity = movement * speed * Time.deltaTime;
        playerRB.velocity = movement * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Fire1")) //|| Input.GetMouseButtonDown(0)
        {
            Jump();

        }
        if (horizontalMovement != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
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
    public void Die()
    {
        //Animaciones die
        GameManager.sharedInstance.GameOver();
       
        StartGame();
        
    }

    }
