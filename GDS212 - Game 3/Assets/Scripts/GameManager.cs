using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverUI;
    public PlayerHealth playerHealth;
    public int pickupsToWin = 10;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI messageText;
    public GameObject winUI;
    public float messageDisplayDuration = 5.0f;

    private bool isGameOver = false;
    private int pickupsCollected = 0;

    public int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Display the initial message
        DisplayMessage();

        // Other initialization logic...
    }

    private void DisplayMessage()
    {
        if (messageText != null)
        {
            messageText.enabled = true;
            StartCoroutine(HideMessage());
        }
    }

    private IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(messageDisplayDuration);

        if (messageText != null)
        {
            messageText.enabled = false;
        }
    }

    private void Update()
    {
        if (playerHealth != null && playerHealth.currentHealth <= 0 && !isGameOver)
        {
            GameOver();
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void CollectPickup(GameObject pickup)
    {
        if (pickup != null)
        {
            score += 1;
            scoreText.text = "Score: " + score;
            pickupsCollected++;

            if (score >= pickupsToWin)
            {
                GameWin();
            }

            Destroy(pickup);

            // Spawn a new pickup at a random spawn point (you can implement this).
        }
    }

    public void GameWin()
    {
        Debug.Log("You won the game!");
        // Add any additional logic for winning the game.

        winUI.SetActive(true);
    }
}