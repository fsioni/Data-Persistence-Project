using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEditor;

public class MainDataManager : MonoBehaviour
{
    public string playerName;

    public string playerNameHighScore;
    public int highScore;

    private string _saveFilePath;

    public static MainDataManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        _saveFilePath = Application.persistentDataPath + "/savefile.json";
    }
    
    [Serializable]
    public class HighScoreData
    {
        public int score;
        public string name;
    }

    public void SaveHighScore(int newHighScore)
    {
        highScore = newHighScore;
        playerNameHighScore = playerName;
        HighScoreData data = new HighScoreData
        {
            score = highScore,
            name = playerNameHighScore
        };

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(_saveFilePath, json);
    }

    public void LoadHighScore()
    {
        if (!File.Exists(_saveFilePath))
        {
            playerNameHighScore = null;
            highScore = 0;
            return;
        }

        string json = File.ReadAllText(_saveFilePath);
        HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

        playerNameHighScore = data.name;
        highScore = data.score;
    }
}