using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEngine;
#endif
public class ExitGame : MonoBehaviour
{

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#elif PLATAFORM_STANDALONE_WIN
        
        Application.Quit();
#endif
        }
}