using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    [Header("Data Manager Config")]
    public static DataManager instance;

    public Sprite selectedSprite;
    public int highScore;
    public int totalWavesDefeated;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadInformation();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int score;
        public int waves;
    }

    // Save game information to json file
    public void SaveInformation()
    {
        SaveData data = new SaveData();
        data.score = highScore;
        data.waves = totalWavesDefeated;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // Load game information from json file
    public void LoadInformation()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.score;
            totalWavesDefeated = data.waves;
        }
    }
}
