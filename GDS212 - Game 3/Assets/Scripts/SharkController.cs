using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public Transform player; // Reference to the player (whale)
    public float moveSpeed = 3.0f; // Adjust the move speed as needed
    public int damageAmount = 10; // Adjust the damage amount as needed
    public float pauseDuration = 3.0f; // Duration for which the shark pauses
    private float pauseTimer = 0.0f;   // Timer to track the pause time
    private bool isPaused = false;     // Flag to determine if the shark is paused

    private void Start()
    {
        // Find the player (whale) GameObject in the scene by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isPaused)
        {
            // Check if the player (whale) is not null (in case it's destroyed)
            if (player != null)
            {
                // Calculate the direction towards the player
                Vector3 direction = (player.position - transform.position).normalized;

                // Move the shark towards the player
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            // Update the pause timer
            pauseTimer += Time.deltaTime;

            // Check if the pause duration has elapsed
            if (pauseTimer >= pauseDuration)
            {
                // Resume chasing the player
                isPaused = false;
                pauseTimer = 0.0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPaused)
        {
            // Check if the collided object is the player (whale)
            // Apply damage to the player (whale)
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Pause the shark and start the pause timer
            isPaused = true;
            pauseTimer = 0.0f;

            // Optionally, you can add other effects here, such as visual feedback
        }
    }
}