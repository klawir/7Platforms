using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    private string gameScene;
    private string mainMenu;
    private string scoreBoard;

    private void Awake()
    {
        gameScene = "game";
        mainMenu = "main menu";
        scoreBoard = "score board";
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void LoadScoreBoard()
    {
        SceneManager.LoadScene(scoreBoard);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public bool IsGameSceneCurrentlyLoaded
    {
        get { return Application.loadedLevelName == gameScene; }
    }
}
