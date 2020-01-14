using Enemy;
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
        zombie.transform.Find("model").GetComponent<Combat>().platformTerrain = platform;
        zombie.transform.Find("navigation").GetComponent<Navigation>().platform = platform;
    }
    public void Spawn(int numberOf, float hp)
    {
        GameObject zombie;
        for (int a = 0; a < numberOf; a++)
        {
            zombie = Instantiate(ZombiePref, zombieSpawnPoint) as GameObject;
            Health health = zombie.transform.Find("model").GetComponent<Health>();
            health.current = hp;
            health.GetComponent<Combat>().platformTerrain = platform;
            Navigation navigation = zombie.transform.Find("navigation").GetComponent<Navigation>();
            navigation.platform = platform;
        }
    }
}