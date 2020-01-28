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
    public Model playerModel;
    public Name name;
    public Health health;
    public Transform playerRoot;
    public KeyCollection keyCollection;

    public UIAbilityUnlocker uiAbilityUnlocker;
    public ManagerScene scene;
    public KeySpawnManager keySpawnManager;
    public PowerUpSpawnManager powerUpSpawnManager;
    public Map map;
    private DataToSave gameDataState;
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
                playersScore.UpdateGUI(gameDataState);
                name.Update(gameDataState);
                health.Update(gameDataState);
                keySpawnManager.LoadSpawnState(keyCollection.KeyNumber);
                powerUpSpawnManager.Spawn(playerModel);
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
    public void Save(bool playerWon)
    {
        platformDataToSave = new PlatformDataToSave[map.platforms.Count];
        
        SavePlatformsState();
        binaryFormatter = new BinaryFormatter();
        stream = new FileStream(path, FileMode.Create);

        gameDataState = new DataToSave(playerRoot, platformDataToSave, playerWon);
        binaryFormatter.Serialize(stream, gameDataState);
        stream.Close();
    }
    private void LoadPlatformsState()
    {
        int b = 0;
        for (int a = 0; a < gameDataState.platformDataToSaves.Length; a++)
        {
            if (gameDataState.platformDataToSaves[a] != null && gameDataState.platformDataToSaves[a].zombieDataToSave.Length > 0)
            {
                map.platforms[gameDataState.platformDataToSaves[a].number].GetComponent<ZombieSpawnManager>().Spawn(
                    gameDataState.platformDataToSaves[a].zombieDataToSave.Length,
                    gameDataState.platformDataToSaves[a].zombieDataToSave[b].hp);
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
            gameDataState = binaryFormatter.Deserialize(stream) as DataToSave;

            if (!gameDataState.unlockedSprint)
                uiAbilityUnlocker.UnlockSprint();

            if (!gameDataState.unlockedDoubleJump)
                uiAbilityUnlocker.UnlockDoubleJump();

            playersScore.Value = gameDataState.score;
            playerModel.name = gameDataState.name;
            TimeManager.instance. LoadedTime = gameDataState.gameTime;
            health.current= gameDataState.health;

            for (int a = 0; a < gameDataState.keyNumber; a++)
                keyCollection.TakeKey();
            
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
        gameDataState = binaryFormatter.Deserialize(stream) as DataToSave;

        _score.name.text = gameDataState.name;
        _score.points.text = gameDataState.score.ToString();
        _score.time.text = gameDataState.gameTime.ToString();
        stream.Close();
        return _score;
    }
    public void Delete()
    {
        if (IsSaveExist)
        {
            if (gameDataState.gameSuccessed)
                DeleteLastGameState();
        }
    }
    public DataToSave GameDataState
    {
        get { return gameDataState; }
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
