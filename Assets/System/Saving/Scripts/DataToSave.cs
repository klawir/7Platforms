using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataToSave 
{
    public int score;
    public string name;
    public float gameTime;
    public float health;
    public bool unlockedDoubleJump;
    public bool unlockedSprint;
    public int keyNumber;
    public PlatformDataToSave[] platformDataToSaves;
    public bool gameSuccessed;

    public DataToSave(Transform playerRoot, PlatformDataToSave[] platformDataToSaves, bool gameSuccessed)
    {
        this.score = playerRoot.GetComponentInChildren<Score>().Value;
        name = playerRoot.GetComponentInChildren<Name>()._name;
        gameTime = TimeManager.instance.Gametime;
        health = playerRoot.GetComponentInChildren<Health>().current;
        unlockedDoubleJump = playerRoot.GetComponentInChildren<Abilities>().jump.Islocked;
        unlockedSprint = playerRoot.GetComponentInChildren<Abilities>().sprint.Islocked;
        keyNumber = playerRoot.GetComponentInChildren<KeyCollection>().KeyNumber;
        this.platformDataToSaves = platformDataToSaves;
        this.gameSuccessed = gameSuccessed;
    }
}
