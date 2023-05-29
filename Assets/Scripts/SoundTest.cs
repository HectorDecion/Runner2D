using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public AudioSource backgroundaudioSource;
    public AudioSource fx00;
    public AudioSource fxbutton;
    internal static object sharedInstance;

    private void Start()
    {
        backgroundaudioSource.Play();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            fx00.Play();
        }
    }
    public void PlaySound()
    {
        fxbutton.Play();
    }
}
