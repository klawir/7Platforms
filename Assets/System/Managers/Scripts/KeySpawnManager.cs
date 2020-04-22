using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawnManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public GameObject pref;

    private void DeleteOneKey()
    {
        spawnPoints.RemoveAt(Random.Range(0, spawnPoints.Count));
    }
    public void Spawn()
    {
        foreach (Transform transform in spawnPoints)
            Instantiate(pref, transform);
    }
    public void LoadSpawnState(int numberOkKeysToDelete)
    {
        for(int a=0;a< numberOkKeysToDelete;a++)
            DeleteOneKey();
        foreach (Transform transform in spawnPoints)
            Instantiate(pref, transform);
    }
}
