using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public AudioSource backgroundAudio;
    public AudioSource buttonFX;

    private void Start()
    {
        backgroundAudio.Play();

    }
    public void PlaySound()
    { 
        buttonFX.Play(); 
    }
}
