using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        if (healthBar != null)
            healthBar.maxValue = maxHealth;
    }

    private void OnEnable()
    {
        PlayerStats.OnScoreChanged += UpdateScore;
        PlayerStats.OnHealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        PlayerStats.OnScoreChanged -= UpdateScore;
        PlayerStats.OnHealthChanged -= UpdateHealth;
    }

    private void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    private float maxHealth = 30f; 

    private void UpdateHealth(float currentHealth)
    {
        if (healthBar != null)
            healthBar.value = currentHealth;

        if (healthText != null)
            healthText.text = $"{Mathf.CeilToInt(currentHealth)}/{Mathf.CeilToInt(maxHealth)}";
    }


    public void ShowGameOver()
    {
        if (statusText != null)
            statusText.text = "GAME OVER!";
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void ShowWin(int score)
    {
        if (statusText != null)
            statusText.text = $"YOU WIN! Score: {score}";
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }
}

