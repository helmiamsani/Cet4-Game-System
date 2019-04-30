using System.Collections; // Player Script for Game Systems (Asteroids)
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids //
{
    public class Player : MonoBehaviour
    {
        [Header("Player Attributes")]
        public GameObject projectilePrefab; // Prefab to spawn when shooting
        [Range(0,20)]
        public float movementSpeed = 10f;
        [Range(0, 360)]
        public float rotationSpeed = 360f;

        private Rigidbody2D rigid; //referencing to rigidbody

        // Use this for initialization
        void Start()
        {
            // Geting reference to rigidbody
            rigid = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            print("A COLLISION HAPPENED!");
        }

        void Control()
        {
            // If player hits Space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Shoot a projectile
                Shoot();
            }

            // If keyCode A is pressed
            if (Input.GetKey(KeyCode.W))
            {
                // Add force in the up direction of player
                rigid.AddForce(transform.up * movementSpeed);
            }

            // If keyCode S is pressed
            if (Input.GetKey(KeyCode.S))
            {
                // Add force in the down direction of player
                rigid.AddForce(-transform.up * movementSpeed);
            }

            // If keyCode D is pressed
            if (Input.GetKey(KeyCode.D))
            {
                // Rotate counter-clockwise
                rigid.rotation -= rotationSpeed * Time.deltaTime;
            }

            // If keyCode A is pressed
            if (Input.GetKey(KeyCode.A))
            {
                // Rotate clockwise
                rigid.rotation += rotationSpeed * Time.deltaTime;
            }

        }

        // Shoots a projectile in a set direction
        void Shoot()
        {
            // Spawn projectile at position and rotation of Player
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Get Rigidbody2D from projectile
            Projectile bullet = projectile.GetComponent<Projectile>();
            bullet.Fire(transform.up);
        }

        // Update is called once per frame
        void Update()
        {
            Control();
        }
    } 
}
