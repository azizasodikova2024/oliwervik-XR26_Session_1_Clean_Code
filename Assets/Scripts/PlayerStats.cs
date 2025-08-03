using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    private int score = 0;
    private float health = 30f;
    private const int winScore = 30;

    // Events to notify about score and health changes
    public static event Action<int> OnScoreChanged;
    public static event Action<float> OnHealthChanged;

    private void Start()
    {
        // Initialize UI with current values
        OnScoreChanged?.Invoke(score);
        OnHealthChanged?.Invoke(health);
    }

    public void AddScore(int value)
    {
        score += value;
        OnScoreChanged?.Invoke(score);

        if (score >= winScore)
        {
            GameManager.Instance.WinGame(score);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        health = Mathf.Max(0, health);
        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public int GetScore() => score;
    public float GetHealth() => health;
}