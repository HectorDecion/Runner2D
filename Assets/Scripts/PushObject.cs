using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float force = 10f;
    private Rigidbody2D rb;

        private void Start ()
    {
        rb =GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.AddForce(transform.forward * force);   
    }
}
