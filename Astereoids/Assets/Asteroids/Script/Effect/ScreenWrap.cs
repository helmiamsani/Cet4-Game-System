using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public float padding = 3f; // Padding around the screen for screen wrapping
    public Color debugColor = Color.blue; // Color of gizmos

    private SpriteRenderer spriteRenderer; // Reference to sprite renderer

    // Awake runs before Start
    void Awake()
    {
        // Get reference to sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Draws Gizmos for debugging 
    void OnDrawGizmos()
    {
        // Get the bounds around the camera with given padding
        Bounds camBounds = Camera.main.GetBounds(padding);

        // Then Draw the Camera Bounds
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }

    // Updates position of entity (GameObject this script is attached to)
    void UpdatePosition()
    {
        // Get the Camera Dimensions using padding
        Bounds camBounds = Camera.main.GetBounds(padding);
        // Store position and size in a shorter variable name
        Vector3 pos = transform.position;
        // Store min and max vectors
        Vector3 min = camBounds.min;
        Vector3 max = camBounds.max;
        // Check left
        if (pos.x < min.x)
        {
            pos.x = max.x;
        }
        // Check right
        if (pos.x > max.x)
        {
            pos.x = min.x;
        }
        // Check up
        if (pos.y < min.y)
        {
            pos.y = max.y;
        }
        // Check down
        if (pos.y > max.y)
        {
            pos.y = min.y;
        }
        // Apply position
        transform.position = pos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Update the player's position
        UpdatePosition();
    }
}
