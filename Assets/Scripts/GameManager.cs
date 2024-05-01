using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int score = 0;
    private int wavesDefeated = 0;
    public bool isGameRunning = true;

    private PlayerSpaceship playerSpaceship;

    [Header("UI")]
    public GameObject gameOverScreen;
    public GameObject inGameUI;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI wavesDefeatedText;
    public TextMeshProUGUI livesText;

    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverWavesDefeatedText;

    void Start()
    {
        playerSpaceship = GameObject.Find("Player").GetComponent<PlayerSpaceship>();
    }

    void Update()
    {
        if (!isGameRunning)
        {
            GameOver();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void AddWaveDefeated()
    {
        wavesDefeated += 1;
        wavesDefeatedText.text = "Waves Defeated: " + wavesDefeated;
        AddScore(100);
    }

    public void DecreasePlayerLives()
    {
        livesText.text = "Lives: " + playerSpaceship.playerLives;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        gameOverScoreText.text = "Your Score: " + score;
        gameOverWavesDefeatedText.text = "Total Waves Defeated: " + wavesDefeated;
        gameOverScreen.SetActive(true);
        inGameUI.SetActive(false);
    }
}
