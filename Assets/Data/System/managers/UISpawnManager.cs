using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UISpawnManager : MonoBehaviour
{
    public static UISpawnManager instance;

    public Text infoUnlockedSprint;
    public Text infoUnlockedDoubleJump;
    public Transform thePlace;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnSprintInfo()
    {
        Instantiate(infoUnlockedSprint, thePlace);
    }
    public void SpawnDoubleJumpInfo()
    {
        Instantiate(infoUnlockedDoubleJump, thePlace);
    }
}
