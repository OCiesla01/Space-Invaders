using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameManager : MonoBehaviour
{

    [Header("Game Manager Config")]
    [SerializeField] private int score = 0;
    [SerializeField] private int wavesDefeated = 0;
    [SerializeField] private int waveValue = 250;
    public bool isGameRunning = true;
    public bool isGamePaused = false;

    private PlayerSpaceship playerSpaceship;

    [Header("UI")]
    public GameObject gameOverScreen;
    public GameObject inGameUI;
    public GameObject pauseScreen;
    public GameObject confirmationQuitScreen;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI wavesDefeatedText;
    public TextMeshProUGUI livesText;

    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverWavesDefeatedText;

    void Start()
    {
        playerSpaceship = GameObject.Find("Player").GetComponent<PlayerSpaceship>();
        AudioManager.instance.PlayBackgroundMusic();
    }

    void Update()
    {
        if (!isGameRunning)
        {
            GameOver();
        }

        ManagePause();
    }

    // Add specified score
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreDisplay();
    }

    // Update score UI
    public void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }

    // Add wave defeated to score
    public void AddWaveDefeated()
    {
        wavesDefeated += 1;
        UpdateWaveDisplay();
        AddScore(waveValue);
    }

    // Update wave UI
    public void UpdateWaveDisplay()
    {
        wavesDefeatedText.text = "Waves Defeated: " + wavesDefeated;
    }

    // Update player's lives UI
    public void UpdatePlayerLivesDisplay()
    {
        livesText.text = "Lives Left: " + playerSpaceship.playerLives;
    }

    // Reset game - reset scene
    public void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Go to menu scene
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Show quit confirmation UI
    public void ShowQuitGameConfirmation()
    {
        confirmationQuitScreen.SetActive(true);
    }

    // Quit game
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Handle data when game over
    public void GameOver()
    {
        gameOverScoreText.text = "Your Score: " + score;
        gameOverWavesDefeatedText.text = "Total Waves Defeated: " + wavesDefeated;
        gameOverScreen.SetActive(true);
        inGameUI.SetActive(false);
        AudioManager.instance.StopBackgroundMusic();

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

    // Pause game
    public void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
        AudioManager.instance.PauseBackgroundMusic();
    }

    // Resume game
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        pauseScreen.SetActive(false);
        AudioManager.instance.UnPauseBackgroundMusic();
    }

    // Handle game pause logic
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
                    AudioManager.instance.UnPauseBackgroundMusic();
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
