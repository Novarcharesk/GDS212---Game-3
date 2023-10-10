using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance for easy access

    public GameObject gameOverUI; // Reference to the game over UI panel or canvas
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script

    private bool isGameOver = false;

    private void Awake()
    {
        // Ensure there's only one instance of the GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Check for game over conditions here if needed
        if (playerHealth != null && playerHealth.currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;

            // Perform game over actions here
            // For example, activate the game over UI and show a message
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }
        }
    }

    // ... Other methods ...

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}