using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Adjust the maximum health as needed
    public int currentHealth;
    public float invincibilityDuration = 3.0f; // Duration of invincibility after getting hit
    private float invincibilityTimer = 0.0f;   // Timer to track invincibility time
    private bool isInvincible = false;         // Flag to determine if the whale is invincible

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to the maximum value
    }

    private void Update()
    {
        if (isInvincible)
        {
            // Update the invincibility timer
            invincibilityTimer += Time.deltaTime;

            // Check if the invincibility duration has elapsed
            if (invincibilityTimer >= invincibilityDuration)
            {
                // End invincibility
                isInvincible = false;
                invincibilityTimer = 0.0f;
            }
        }
    }

    // Method to handle taking damage
    public void TakeDamage(int damageAmount)
    {
        if (!isInvincible)
        {
            // Reduce the current health by the damage amount
            currentHealth -= damageAmount;

            // Check if the player's health has dropped to or below zero
            if (currentHealth <= 0)
            {
                // Player has died (you can implement game over logic here)
                Die();
            }

            // Start invincibility
            isInvincible = true;
            invincibilityTimer = 0.0f;

            // Optionally, you can add other effects here, such as visual feedback for invincibility
        }
    }

    // Method to handle player's death (you can customize this)
    private void Die()
    {
        // For example, you can deactivate the player object or trigger a game over screen
        gameObject.SetActive(false); // Deactivate the player (whale) GameObject
        GameManager.Instance.GameOver();
    }

    // Method to heal the player (you can customize this)
    public void Heal(int healAmount)
    {
        // Increase the current health by the heal amount
        currentHealth += healAmount;

        // Ensure that the current health does not exceed the maximum
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }
}