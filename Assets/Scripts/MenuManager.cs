using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [Header("Main Menu Manager Config")]
    [SerializeField] private Sprite[] spaceshipSprites;

    public TextMeshProUGUI highestScore;
    public TextMeshProUGUI highestWave;

    private void Start()
    {
        if (DataManager.instance != null)
        {
            UpdateBestScoresDisplay();
        }

        AudioManager.instance.PlayMenuMusic();
    }

    // Load Intel scene
    public void LoadIntelScene()
    {
        AudioManager.instance.StopMenuMusic();
        AudioManager.instance.PlayStartButton();
        SceneManager.LoadScene("IntelScene");
    }

    // Handle spaceship selection
    public void SelectSpaceship(int index)
    {
        if (index >= 0 && index < spaceshipSprites.Length)
        {
            AudioManager.instance.PlaySelectButton();
            DataManager.instance.selectedSprite = spaceshipSprites[index];
        }
    }


    // Display best scores from saved data
    public void UpdateBestScoresDisplay()
    {
        highestScore.text = "Highest Score: " + DataManager.instance.highScore;
        highestWave.text = "Highest Wave: " + DataManager.instance.totalWavesDefeated;
    }
}
