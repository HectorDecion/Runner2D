using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public bool isPause = false;
    public GameObject PauseObjects;

    private void Start()
    {
        PauseObjects.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause) 
                   ResumeGame();

                else
                   PauseGame();
            }
            }

    private void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0f;
        PauseObjects.SetActive(true);
    }
    private void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1f;
        PauseObjects.SetActive(false);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

#else
      Application.Quit();
#endif

    }
}
