using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float jumpForce = 5000f;
    [SerializeField]public float speed = 10000f;
    [SerializeField] private float runningSpeed = 2000f;
    public float fuerzaGolpe;
    private Rigidbody2D playerRB;
    private Rigidbody2D rigidBody;
    public bool grounded;
    Vector3 startPosition;
    private Animator animator;
    public LayerMask groundMask;
   // private bool puedeMoverse = true;
    
  
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
        Debug.DrawRay(this.transform.position, Vector2.down * 20.0f, Color.red);
      
    }
 
    private void FixedUpdate()
    {
        if(playerRB.velocity.x < runningSpeed)

        {
            playerRB.velocity = new Vector2(runningSpeed, playerRB.velocity.y);

        }
       float horizontalMovement = Input.GetAxis("Horizontal");
        //  float verticalMovement = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalMovement, 0); //verticalMovement);
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
        // if (Input.GetKeyDown(KeyCode.Space))
        //{ 
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //}
        //  if(IsTouchingTheGround())
        // {
        //     playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        // }
        //     }
        // bool IsTouchingTheGround()
        //    {
        //        if(Physics2D.Raycast(this.transform.position,Vector2.down, 20.0f, groundMask)) 
        //       {
        //           grounded = true;
        //           return true;
        //       }
        //       else 
        //       {
        //         grounded = false;
        //       return false; 
        // }
    }
    public void ResetGame()
    {
        //  this.transform.position = startPosition;
        //  this.playerRB.velocity = Vector2.zero;
        //  GameManager.sharedInstance.StartGame();
        GameManager.sharedInstance.GameOver();
        SceneManager.LoadScene(2);
    }
    public void Die()
    {
        //Animaciones die
     //GameManager.sharedInstance.GameOver();   //Quite esto para ver si solucionaba el error
       
       ResetGame();
        
    }
    public void DieEnemy()
    {
        //Animaciones die
        //GameManager.sharedInstance.GameOver();   //Quite esto para ver si solucionaba el error

        ResetGame();
        Destroy(gameObject);

    }
    public void AplicarGolpe()
    {

    //    puedeMoverse = false;

        Vector2 direccionGolpe;

        if (rigidBody.velocity.x > 0)
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1, 1);
        }

        rigidBody.AddForce(direccionGolpe * fuerzaGolpe);

        StartCoroutine(EsperarYActivarMovimiento());
    }

    IEnumerator EsperarYActivarMovimiento()
    {
        // Esperamos antes de comprobar si esta en el suelo.
        yield return new WaitForSeconds(0.1f);

  //      while (!EstaEnSuelo())
    //    {
            // Esperamos al siguiente frame.
      //      yield return null;
       // }

        // Si ya está en suelo activamos el movimiento.
        //puedeMoverse = true;
    }
}