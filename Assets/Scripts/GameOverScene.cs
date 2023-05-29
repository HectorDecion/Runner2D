using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public float delay = .1f;

    public void NextScene()
    {
        //   GameManager.sharedInstance.StartGame(); Cuidado con este error si lo activas el singleton no dejara que regrese de main menu
        SceneManager.LoadScene(1);
    }
}
