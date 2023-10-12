using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TMPro namespace for TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // Maximum health
    public int currentHealth; // Current health
    public float invincibilityDuration = 3.0f; // Duration of invincibility after getting hit
    private float invincibilityTimer = 0.0f;   // Timer to track invincibility time
    private bool isInvincible = false;         // Flag to determine if the player is invincible
    public TextMeshProUGUI healthText; // Reference to the TextMeshProUGUI element for health display
    public GameObject gameOverUI; // Reference to the game over UI panel or canvas

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health
        UpdateHealthText();
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
            UpdateHealthText();

            if (currentHealth <= 0)
            {
                // Player has run out of health
                Die();
            }

            // Start invincibility
            isInvincible = true;
            invincibilityTimer = 0.0f;
        }
    }

    // Method to handle player's death
    private void Die()
    {
        // Deactivate the player object or trigger a game over screen
        gameObject.SetActive(false); // Deactivate the player GameObject
        GameManager.Instance.GameOver();

        // Optionally, you can add other game over effects here.
    }

    // Update the health display
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}