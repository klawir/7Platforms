using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public List<GameObject> gameComponents;

    private float loadedTime;
    private float gametime;
    private float startTime;

    public Text gameTime;

    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        startTime = Time.time;
    }
    private void Update()
    {
        TakeTime();
        UpdateGUI();
    }
    public void Stop()
    {
        Time.timeScale = 0;
        FreezeAll();
    }
    private void TakeTime()
    {
        gametime = Time.time + loadedTime - startTime;
    }
    private void UpdateGUI()
    {
        gameTime.text = "time: " + gametime.ToString();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        ResumeAll();
    }
    public void FreezeAll()
    {
        for (int a = 0; a < gameComponents.Count; a++)
            gameComponents[a].SetActive(false);
    }
    private void ResumeAll()
    {
        for (int a = 0; a < gameComponents.Count; a++)
            gameComponents[a].SetActive(true);
    }

    public float Gametime
    {
        get { return gametime; }
    }
    public float LoadedTime
    {
        set { loadedTime = value; }
    }
}
