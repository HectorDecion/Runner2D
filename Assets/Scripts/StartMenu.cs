using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public float delay = .1f;

    public void NextScene()
    {
        GameManager.sharedInstance.StartGame();
        SceneManager.LoadScene(1);
    }
}