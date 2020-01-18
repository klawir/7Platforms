using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnManager : MonoBehaviour
{
    public GameObject powerUpSprint;
    public GameObject powerUpDoubleJump;
    public List<Transform> spawnPoints;

    public void Spawn()
    {
        int randomNumber = Random.Range(0, spawnPoints.Count);
        Instantiate(powerUpSprint, spawnPoints[randomNumber]);
        spawnPoints.RemoveAt(randomNumber);
        Instantiate(powerUpDoubleJump, spawnPoints[Random.Range(0, spawnPoints.Count)]);
    }
    public void Spawn(Model model)
    {
        int randomNumber = Random.Range(0, spawnPoints.Count);

        if (model.abilities.sprint.Islocked)
        {
            Instantiate(powerUpSprint, spawnPoints[randomNumber]);
            spawnPoints.RemoveAt(randomNumber);
        }
        if (model.abilities.jump.Islocked)
            Instantiate(powerUpDoubleJump, spawnPoints[Random.Range(0, spawnPoints.Count)]);
    }
}
