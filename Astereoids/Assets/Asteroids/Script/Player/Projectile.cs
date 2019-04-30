using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Travel speed of projectile
    private Rigidbody2D rigid;

    void Awake()
    {
        // Get reference to Rigidbody
        rigid = GetComponent<Rigidbody2D>();      
    }

    // Fire's this bullet in a given direction (using defined speed)
    public void Fire(Vector3 direction)
    {
        // Add force in the given direction by speed
        rigid.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    // Projectile destroys Asteroids when it hits is
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Try Getting Asteroid Script from Collision
        Asteroid asteroid = collision.GetComponent<Asteroid>();
        // If it is an Asteroid
        if (asteroid)
        {
            // Destroy the Asteroid
            asteroid.Destroy();
            // Destroy the Projectile
            Destroy(gameObject);
        }
    }
}
