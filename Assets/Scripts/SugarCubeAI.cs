using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarCubeAI : MonoBehaviour
{
    public float speed = 1.0f; // Enemy's speed.
    private GameObject player; // Player object.
    private float leftBoundary;
    private float rightBoundary;
    private float offset = 0.5f;
    private bool colliderEnabledOnce = false; // Flag to indicate if the collider was enabled once.

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Assume your player object has a tag named "Player".

        // Assume the camera is centered at (0,0) and the game is played in landscape mode.
        var halfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        leftBoundary = -halfWidth;
        rightBoundary = halfWidth;
    }

    void Update()
    {
        // If player is not null, move towards the player.
        if (player != null)
        {
            // Get the direction towards the player along the X axis only.
            float direction = Mathf.Sign(player.transform.position.x - transform.position.x);

            // Check if the enemy is inside or outside the boundaries.
            bool isInsideBoundaries = transform.position.x > leftBoundary + offset && transform.position.x < rightBoundary - offset;

            // Move the enemy along the X axis towards the player.
            transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);

            // If the enemy is outside the boundaries, keep it at a certain height.
            if (!isInsideBoundaries)
            {
                transform.position = new Vector3(transform.position.x, -3.477397f, transform.position.z);
            }
            
            // If the enemy has moved inside the player's boundaries, enable its collider.
            var collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                if (isInsideBoundaries)
                {
                    collider.enabled = true;
                    colliderEnabledOnce = true;
                }
                else if (!colliderEnabledOnce)
                {
                    collider.enabled = false;
                }
            }

            // Flip the sprite based on the direction of movement.
            Vector3 scale = transform.localScale;
            scale.x = direction > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}
