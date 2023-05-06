using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        { 
            Debug.Log("Space Click"); 
        }
        if(Input.GetKeyDown(KeyCode.W))
        { 
            Debug.Log("W Click"); 
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A Click");
                }
    }
}
