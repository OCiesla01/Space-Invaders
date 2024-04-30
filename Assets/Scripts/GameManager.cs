using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(score);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
