using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoRebote : MonoBehaviour
{

    public float speed = 5f;
    public float minBaounceAngle = 30F;
    public float maxBaounceAngle = 150f;

    public float minBounceSpeedMulti = 0.05f;
    public float maxBounceSpeedMulti = 1.5f;

    public int bounceBeforeSpeed = 3;
    public float speedIncrease = 1f;

    private int bounceSinceSpeedIncrease = 0;

    private Rigidbody2D rb2D;
 

    private void Start()
    {
        rb2D = GetComponent <Rigidbody2D>();
        rb2D.velocity = new Vector2(speed, speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        float angle = Vector2.Angle(rb2D.velocity, normal);
        if (angle < maxBaounceAngle)

        {
            float speedMulti = Mathf.Lerp(minBounceSpeedMulti, maxBounceSpeedMulti, angle / maxBaounceAngle);

            Vector2 bounceDirection = Vector2.Reflect(rb2D.velocity.normalized, normal);
            rb2D.velocity = bounceDirection * speed * speedMulti;

            bounceSinceSpeedIncrease++;

            if (bounceSinceSpeedIncrease >= bounceBeforeSpeed)
            {
                bounceSinceSpeedIncrease = 0;
                speed += speedIncrease;
            }
                    }

    }
}
