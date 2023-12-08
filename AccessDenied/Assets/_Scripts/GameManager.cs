using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Singleton GameManager that holds score
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }    // Singleton B)))
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;

    private int score = 0;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount) {
        score += amount;
        UpdateScoreText();
    }

    public int GetScore() {
        return score;
    }

    public void GameOver() {
        gameOverScreen.active = true;
    }

    private void UpdateScoreText() {
        if (scoreText != null) {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
