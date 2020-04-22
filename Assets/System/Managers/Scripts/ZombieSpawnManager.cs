using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    public Transform zombieSpawnPoint;
    public GameObject ZombiePref;
    public PlatformTerrain platform;

    public void Spawn()
    {
        GameObject zombie = Instantiate(ZombiePref, zombieSpawnPoint) as GameObject;
        zombie.GetComponentInChildren<Combat>().platformTerrain = platform;
        zombie.GetComponentInChildren<Navigation>().platform = platform;
    }
    public void Spawn(int numberOf, float hp)
    {
        GameObject zombie;
        for (int a = 0; a < numberOf; a++)
        {
            zombie = Instantiate(ZombiePref, zombieSpawnPoint) as GameObject;
            Health health = zombie.GetComponentInChildren<Health>();
            health.current = hp;
            health.GetComponent<Combat>().platformTerrain = platform;
            Navigation navigation = zombie.GetComponentInChildren<Navigation>();
            navigation.platform = platform;
        }
    }
}