using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int score;
    public bool isGameRunning = true;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
