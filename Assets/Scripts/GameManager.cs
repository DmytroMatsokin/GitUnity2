using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    MenuScript menuScript;
    public int hiScore = 0;

    public string userName = "";

    private void Awake()
    {
        menuScript = GameObject.Find("Canvas").GetComponent<MenuScript>();
        userName = menuScript.userName;

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //SaveHiScore();

        LoadHiScore();
        
    }

    [System.Serializable]
    public class SaveData
    {
        public string userNameS;
        public int hiScoreS;
    }

    public void SaveHiScore()
    {
        SaveData data = new SaveData();
        data.userNameS = userName;
        data.hiScoreS = hiScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        //File.WriteAllText(Application.persistentDataPath + "/savefile.json", "sdgsdgf");
        Debug.Log(json);
    }

    public void LoadHiScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hiScore = data.hiScoreS;
            userName = data.userNameS;
        }
    }
    



}
