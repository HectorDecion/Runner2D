using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public enum GameState
{
    menu,
    inGame,
    pause,
    gameOver
}
public class GameManager : MonoBehaviour

{
    #region Singleton
    public static GameManager sharedInstance;
    #endregion
 //   [SerializeField] GameState currentGameState;
    private PlayerMovement movement;
  //  private EnemyMovement enemymovement;
    private void Awake()
    {
        #region Singleton
        if (sharedInstance == null)
            sharedInstance = this;

        #endregion
        
    }public static GameManager Instance { get; private set; }
    void Start()
    {
      //  currentGameState = GameState.gameOver;
        movement = GameObject.Find("Player").GetComponent<PlayerMovement>(); //Find ocupa mucho en la memoria no usar mucho, tal vez usar referencias pero otra cosa
     //   enemymovement = GameObject.Find("Warrior").GetComponent<EnemyMovement>();
        //     SceneManager.LoadScene(0); //BORRA ESTO SI NO SIRVE ES PARA EMPEZAR EN MENU
    }


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartGame();
        }
    }

    private int vidas = 3;
    public HUD hud;
    public int PuntosTotales { get; private set; }
   
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }
    public void BackToGame()
    {
        SetGameState(GameState.menu);
    }
    private void SetGameState(GameState newGameState)
    { 
    if(newGameState == GameState.menu)
        {
        }
    else if (newGameState == GameState.inGame)
        {
            //Panel de In Game
            movement.StartGame();

            // Ocultar menu de pausa
            MenuManager.sharedInstance.HidePauseCanvas();
        }
    else if(newGameState == GameState.pause) 
        {
            // Mostar Menu de Pausa
            MenuManager.sharedInstance.ShowPauseCanvas();
        
        }
    else if(newGameState == GameState.gameOver)
        {
            // Panel de Muerte
            MenuManager.sharedInstance.ShowPauseCanvas();
        }
    }
    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
        hud.ActualizarPuntos(PuntosTotales);
    }
    public void PerderVida()
    {
        vidas -= 1;

        if (vidas == 0)
        {
            // Reiniciamos el nivel.
            SceneManager.LoadScene(0);
        }

        hud.DesactivarVida(vidas);
    }
    public bool RecuperarVida()
    {
        if (vidas == 3)
        {
            return false;
        }

        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }
}


