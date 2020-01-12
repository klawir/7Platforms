using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataToSave 
{
    public float score;
    public string name;
    public float gameTime;
    public float health;
    public bool unlockedDoubleJump;
    public bool unlockedSprint;
    public int keyNumber;
    public PlatformDataToSave[] platformDataToSaves;

    public DataToSave(Score score, Model model, PlatformDataToSave[] platformDataToSaves)
    {
        this.score = score.Value;
        name = model.name;
        gameTime = model.Gametime;
        health = model.GetComponent<Health>().current;
        unlockedDoubleJump = model.abilities.jump.IsBlockade;
        unlockedSprint = model.abilities.sprint.IsBlockade;
        keyNumber = model.KeyNumber;
        this.platformDataToSaves = platformDataToSaves;
    }
}
