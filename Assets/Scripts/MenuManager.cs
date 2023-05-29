using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
public static MenuManager sharedInstance;
        public Canvas pauseCanvas;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    public void ShowPauseCanvas()
    {
        pauseCanvas.enabled = true;
    }

    public void HidePauseCanvas()
    {
        pauseCanvas.enabled = false;

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
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

