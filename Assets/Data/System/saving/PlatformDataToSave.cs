using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[System.Serializable]
public class PlatformDataToSave
{
    public int number;
    public ZombieDataToSave[] zombieDataToSave;

    public PlatformDataToSave(int number, int numberOfZombies, ZombieDataToSave[] zombieDataToSave)
    {
        this.number = number;
        this.zombieDataToSave = new ZombieDataToSave[numberOfZombies];
        this.zombieDataToSave = zombieDataToSave;
    }
}