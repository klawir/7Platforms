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
        //string paltformName = platform.name;
        //paltformName = Regex.Match(platform.name, @"\d+").Value;
        this.number = number; //int.Parse(paltformName);
        this.zombieDataToSave = new ZombieDataToSave[numberOfZombies];
        this.zombieDataToSave = zombieDataToSave;
    }
}