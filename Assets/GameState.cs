using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using Player;

public class GameState : MonoBehaviour
{
    private string path;
    public Score playersScore;
    public Model model;
    public Scene scene;
    public KeySpawnManager keySpawnManager;
    public PowerUpSpawnManager powerUpSpawnManager;
    public Map map;
    private DataToSave score;
    private PlatformDataToSave[] platformDataToSave;
    private BinaryFormatter binaryFormatter;
    private FileStream stream;

    private void Awake()
    {
        path = Application.persistentDataPath + "/save.binary";
        Debug.Log(Application.persistentDataPath);
    }
    private void Start()
    {
        if (scene.IsGameSceneCurrentlyLoaded)
        {
            if (IsSaveExist)
            {
                Load();
                playersScore.UpdateGUI();
                model.UpdateName();
                keySpawnManager.Spawn(model.KeyNumber);
                powerUpSpawnManager.Spawn(model);
            }
            else
            {
                keySpawnManager.Spawn();
                powerUpSpawnManager.Spawn();
            }
        }
            
    }
    private void SavePlatformsState()
    {
        List<ZombieDataToSave[]> zombieDataToSave = new List<ZombieDataToSave[]>();
        ZombieDataToSave[] numberOfzombies;

        List<GameObject> zombies;
        int platformIndexWithZombies = 0;

        for (int a = 0; a < map.platforms.Count; a++)
        {
            Transform parent = map.platforms[a].GetComponent<ZombieSpawnManager>().zombieSpawnPoint;
            if (parent.childCount > 0)
            {
                numberOfzombies = new ZombieDataToSave[parent.childCount];
                zombies = new List<GameObject>();

                foreach (Transform zombie in parent)
                    zombies.Add(zombie.gameObject);
                for (int b = 0; b < numberOfzombies.Length; b++)
                    numberOfzombies[b] = new ZombieDataToSave(zombies[b]);
                zombieDataToSave.Add(numberOfzombies);

                platformDataToSave[a] = new PlatformDataToSave(
                    map.platforms.IndexOf(map.platforms[a]),
                    map.platforms[a].GetComponent<ZombieSpawnManager>().zombieSpawnPoint.transform.childCount,
                    zombieDataToSave[platformIndexWithZombies]
                    );
                platformIndexWithZombies++;
            }
        }
    }
    public void Save()
    {
        platformDataToSave = new PlatformDataToSave[map.platforms.Count];
        
        SavePlatformsState();
        binaryFormatter = new BinaryFormatter();
        stream = new FileStream(path, FileMode.Create);

        score = new DataToSave(playersScore, model, platformDataToSave);
        binaryFormatter.Serialize(stream, score);
        stream.Close();
    }
    private void LoadPlatformsState()
    {
        int b = 0;
        for (int a = 0; a < score.platformDataToSaves.Length; a++)
        {
            if (score.platformDataToSaves[a] != null && score.platformDataToSaves[a].zombieDataToSave.Length > 0)
            {
                map.platforms[score.platformDataToSaves[a].number].GetComponent<ZombieSpawnManager>().Spawn(
                    score.platformDataToSaves[a].zombieDataToSave.Length,
                    score.platformDataToSaves[a].zombieDataToSave[b].hp);
                b++;
            }
            b = 0;
        }
    }
    public void Load()
    {
        if (IsSaveExist)
        {
            binaryFormatter = new BinaryFormatter();
            stream = new FileStream(path, FileMode.Open);
            score = binaryFormatter.Deserialize(stream) as DataToSave;

            if (!score.unlockedSprint)
                model.UnlockSprint();

            if (!score.unlockedDoubleJump)
                model.UnlockDoubleJump();

            playersScore.Value = score.score;
            model.name = score.name;
            TimeManager.instance. LoadedTime = score.gameTime;
            model.GetComponent<Health>().current= score.health;

            for (int a = 0; a < score.keyNumber; a++)
                model.TakeKey();
            
            LoadPlatformsState();
            stream.Close();
        }
        else
            Debug.LogError("data not found at " + path);
    }
    public ScoreBoard.Score Load(ScoreBoard.Score _score)
    {
        binaryFormatter = new BinaryFormatter();
        stream = new FileStream(path, FileMode.Open);
        score = binaryFormatter.Deserialize(stream) as DataToSave;

        _score.name.text = score.name;
        _score.points.text = score.score.ToString();
        _score.time.text = score.gameTime.ToString();
        return _score;
    }
    public DataToSave Score
    {
        get { return score; }
    }
    public bool IsSaveExist
    {
        get { return File.Exists(path); }
    }
    public void DeleteLastGameState()
    {
        try
        {
            File.Delete(path);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
