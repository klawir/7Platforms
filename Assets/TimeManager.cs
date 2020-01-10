using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public List<GameObject> gameComponents;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        //Resume();
    }

    /*private void OnLevelWasLoaded()
    {
        gameComponents.Clear();
        gameComponents.Add(Camera.main.gameObject);
        gameComponents.Add(GameObject.FindGameObjectWithTag("Overseer"));
    }*/
    public void Stop()
    {
        Time.timeScale = 0;
        FreezeAll();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        ResumeAll();
    }
    private void FreezeAll()
    {
        for (int a = 0; a < gameComponents.Count; a++)
            gameComponents[a].SetActive(false);
    }
    private void ResumeAll()
    {
        for (int a = 0; a < gameComponents.Count; a++)
            gameComponents[a].SetActive(true);
    }
}
