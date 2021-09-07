using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public string username;
    public string highscoreUsername;
    public int highscore;

    private string saveLocation;
    public static MenuManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        saveLocation = Application.persistentDataPath + "/savefile.json";
        DontDestroyOnLoad(gameObject);
        this.Load();
    }

    public void Load()
    {
        if (File.Exists(saveLocation))
        {
            string json = File.ReadAllText(saveLocation);

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            username = data.username;
            highscoreUsername = data.highscoreUsername;
            highscore = data.highscore;
        }
    }

    public void Save()
    {
        SaveData data = new SaveData()
        {
            username = this.username,
            highscoreUsername = this.highscoreUsername,
            highscore = this.highscore
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(saveLocation, json);
    }

    

    [System.Serializable]
    class SaveData
    {
        public string username;
        public string highscoreUsername;
        public int highscore;
    }
}
