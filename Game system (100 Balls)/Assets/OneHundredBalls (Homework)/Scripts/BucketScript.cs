using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour {

    public float movementSpeed = 10.0f;

    private Rigidbody2D rigid2D;
    private Renderer[] renderers;


	// Use this for initialization
	void Start ()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        renderers = GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandlePosition();
        HandleBoundary();
	}

    // Handle bucket position
    void HandlePosition()
    {
        rigid2D.velocity = Vector3.left * movementSpeed;
    }

    // Handles the screen boundaries for game object
    void HandleBoundary()
    {
        Vector3 transformPos = transform.position;
        // Get the viewport position of where the bucket is
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transformPos);
        // Is the GameObject visible from the camera and on the left hand side of it?
        if(IsVisible() == false && viewportPos.x < 0)
        {
            Destroy(gameObject); // Then destroy the GameObject
        }
    }

    // Checks whether or not any renderer attached to this GameObject
    // and it's children is visible
    bool IsVisible()
    {
        foreach (var renderer in renderers)
        {
            if (renderer.isVisible)
            {
                return true;
            }
        }
        return false;
    }

}
