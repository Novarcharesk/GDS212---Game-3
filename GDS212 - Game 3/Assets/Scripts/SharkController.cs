using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public Transform player; // Reference to the player (whale)
    public float moveSpeed = 3.0f; // Adjust the move speed as needed
    public int damageAmount = 10; // Adjust the damage amount as needed
    public float pauseDuration = 3.0f; // Duration for which the shark pauses
    private float pauseTimer = 0.0f;   // Timer to track the pause time
    private bool isPaused = false;     // Flag to determine if the shark is paused
    private Vector3 currentVelocity = Vector3.zero;
    public float currentSpeed = 0f;
    public float acceleration = 1f;
    private Vector3 targetRotation;
    public float maxSpeed = 5f;
    private Quaternion savedRotation; // Store the rotation when paused
    private Vector3 savedVelocity;    // Store the velocity when paused

    private void Start()
    {
        // Find the player (whale) GameObject in the scene by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isPaused)
        {
            if (player != null)
            {
                transform.position = Vector3.SmoothDamp(transform.position, player.position, ref currentVelocity, acceleration, maxSpeed);
                if (Vector3.Distance(transform.position, player.position) >= 0.3f)
                {
                    targetRotation = Quaternion.LookRotation(player.position - transform.position).eulerAngles + (Vector3.up * 90);
                }
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * 2f);
            }
        }

        else
        {
            // Shark is paused
            // Store the rotation and velocity
            savedRotation = transform.rotation;
            savedVelocity = currentVelocity;

            // Update the pause timer
            pauseTimer += Time.deltaTime;

            if (pauseTimer >= pauseDuration)
            {
                // Resume chasing the player
                isPaused = false;
                pauseTimer = 0.0f;

                // Restore the rotation and velocity
                transform.rotation = savedRotation;
                currentVelocity = savedVelocity;
            }
            else
            {
                // Set the velocity to zero to stop the shark
                currentVelocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
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