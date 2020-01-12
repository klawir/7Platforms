using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void Load(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public bool IsGameSceneCurrentlyLoaded
    {
        get { return Application.loadedLevelName == "game"; }
    }
}
