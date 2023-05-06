using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] GameState currentGameState = GameState.menu;
    private void Awake()
    {
        #region Singleton
        if (sharedInstance == null)
            sharedInstance = this;
        #endregion
    }
    void Start()
    {
        currentGameState = GameState.gameOver;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }
    }

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
        }
    else if(newGameState == GameState.pause) 
        { 
        }
    else if(newGameState == GameState.gameOver)
        {

        }
    }
    }

