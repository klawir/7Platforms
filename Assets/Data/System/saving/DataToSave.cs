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

    public DataToSave(Score score, Model model, PlatformDataToSave[] platformDataToSaves, bool gameSuccessed)
    {
        this.score = score.Value;
        name = model.name;
        gameTime = TimeManager.instance.Gametime;
        health = model.GetComponent<Health>().current;
        unlockedDoubleJump = model.abilities.jump.IsBlockade;
        unlockedSprint = model.abilities.sprint.IsBlockade;
        keyNumber = model.KeyNumber;
        this.platformDataToSaves = platformDataToSaves;
        this.gameSuccessed = gameSuccessed;
    }
}
