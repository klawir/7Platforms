using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public List<GameObject> gameComponents;

    private float loadedTime;
    private float gamePlayTime;
    private float totalApplicationRunTime;

    public Text gameTime;

    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        totalApplicationRunTime = Time.time;
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
        gamePlayTime = Time.time + loadedTime - totalApplicationRunTime;
    }
    private void UpdateGUI()
    {
        gameTime.text = gamePlayTime.ToString();
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
        get { return gamePlayTime; }
    }
    public float LoadedTime
    {
        set { loadedTime = value; }
    }
}
