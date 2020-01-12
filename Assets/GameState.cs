using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameState : MonoBehaviour
{
    private string path;
    public Score playersScore;
    public Model model;
    public Scene scene;
    public KeySpawnManager keySpawnManager;
    public PowerUpSpawnManager powerUpSpawnManager;
    public Map map;

    private void Awake()
    {
        path = Application.persistentDataPath + "/save.binary";
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
    public void Save()
    {
        PlatformDataToSave[] platformDataToSave = new PlatformDataToSave[map.platforms.Count];

        List<ZombieDataToSave[]> zombieDataToSave= new List<ZombieDataToSave[]>();
        ZombieDataToSave[] numberOfzombies;
        List<GameObject> zombies;
        int platformIndexWithZombies = 0;

        for (int a = 0; a < map.platforms.Count; a++)
        {
            Debug.Log("platform "+a);
           
               Transform parent = map.platforms[a].GetComponent<ZombieSpawnManager>().zombieSpawnPoint;
            if (parent.childCount > 0)
            {
                Debug.Log(parent.childCount+" zombies");
                numberOfzombies = new ZombieDataToSave[parent.childCount];
                zombies = new List<GameObject>();

                foreach (Transform zombie in parent)
                    zombies.Add(zombie.gameObject);
                for (int b = 0; b < numberOfzombies.Length; b++)
                {
                    numberOfzombies[b] = new ZombieDataToSave(zombies[b]);
                    Debug.Log(b + " " + numberOfzombies[b]);
                }
                Debug.Log("ZombieDataToSave[] " + numberOfzombies.Length);
                zombieDataToSave.Add(numberOfzombies);
                Debug.Log(a+" zombieDataToSave list counter " + zombieDataToSave.Count);

                //foreach (ZombieDataToSave _zombieDataToSave in _zombie)
                // Debug.Log(map.platforms[a] + " " + _zombieDataToSave.hp);
                platformDataToSave[a] = new PlatformDataToSave(
                    map.platforms.IndexOf(map.platforms[a]),
                    map.platforms[a].GetComponent<ZombieSpawnManager>().zombieSpawnPoint.transform.childCount,
                    zombieDataToSave[platformIndexWithZombies]
                    );
                platformIndexWithZombies++;
            }
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        DataToSave data = new DataToSave(playersScore, model, platformDataToSave);
        binaryFormatter.Serialize(stream, data);
        stream.Close();
    }
    public void Load()
    {
        if (IsSaveExist)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataToSave score = formatter.Deserialize(stream) as DataToSave;

            if (!score.unlockedSprint)
                model.UnlockSprint();

            if (!score.unlockedDoubleJump)
                model.UnlockDoubleJump();

            playersScore.Value = score.score;
            model.name = score.name;
            model.LoadedTime = score.gameTime;
            model.GetComponent<Health>().current= score.health;

            for (int a = 0; a < score.keyNumber; a++)
                model.TakeKey();
            int b = 0;
            for (int a = 0; a < score.platformDataToSaves.Length; a++)
            {
                if (score.platformDataToSaves[a] != null && score.platformDataToSaves[a].zombieDataToSave.Length>0)
                {
                    map.platforms[score.platformDataToSaves[a].number].GetComponent<ZombieSpawnManager>().Spawn(
                        score.platformDataToSaves[a].zombieDataToSave.Length,
                        score.platformDataToSaves[a].zombieDataToSave[b].hp);
                    b++;
                }
                b = 0;
            }
            stream.Close();
        }
        else
            Debug.LogError("data not found at " + path);
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
