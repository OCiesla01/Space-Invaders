using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public Sprite[] spaceshipSprites;

    public TextMeshProUGUI highestScore;
    public TextMeshProUGUI highestWave;

    private void Start()
    {
        if (DataManager.instance != null)
        {
            UpdateBestScoresDisplay();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");

    }

    public void SelectSpaceship(int index)
    {
        if (index >= 0 && index < spaceshipSprites.Length)
        {
            DataManager.instance.selectedSprite = spaceshipSprites[index];
        }
    }

    public void UpdateBestScoresDisplay()
    {
        highestScore.text = "Highest Score: " + DataManager.instance.highScore;
        highestWave.text = "Highest Wave: " + DataManager.instance.totalWavesDefeated;
    }
}
