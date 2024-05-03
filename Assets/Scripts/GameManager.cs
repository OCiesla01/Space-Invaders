using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int wavesDefeated = 0;
    private int waveValue = 250;
    public bool isGameRunning = true;
    public bool isGamePaused = false;

    private PlayerSpaceship playerSpaceship;

    [Header("UI")]
    public GameObject gameOverScreen;
    public GameObject inGameUI;
    public GameObject pauseScreen;

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

        ManagePause();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddWaveDefeated()
    {
        wavesDefeated += 1;
        UpdateWaveDisplay();
        AddScore(waveValue);
    }

    public void UpdateWaveDisplay()
    {
        wavesDefeatedText.text = "Waves Defeated: " + wavesDefeated;
    }

    public void UpdatePlayerLivesDisplay()
    {
        livesText.text = "Lives Left: " + playerSpaceship.playerLives;
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

        bool shouldSave = false;
        if (score > DataManager.instance.highScore)
        {
            DataManager.instance.highScore = score;
            shouldSave = true;
        }
        if (wavesDefeated > DataManager.instance.totalWavesDefeated)
        {
            DataManager.instance.totalWavesDefeated = wavesDefeated;
            shouldSave = true;
        }
        if (shouldSave)
        {
            DataManager.instance.SaveInformation();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        pauseScreen.SetActive(false);
    }

    public void ManagePause()
    {
        if (SceneManager.GetActiveScene().name == "GameScene" && isGameRunning)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isGamePaused)
                {
                    ResumeGame();
                    pauseScreen.SetActive(false);
                    isGamePaused = false;
                }
                else if (!isGamePaused)
                {
                    PauseGame();
                    pauseScreen.SetActive(true);
                    isGamePaused = true;
                }
            }
        }
    }
}
