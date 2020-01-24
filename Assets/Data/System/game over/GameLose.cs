using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLose : MonoBehaviour
{
    public Transform player;
    public Text text;
    private Delay delay;
    public float duration;
    public ManagerScene managerScene;
    public GameState gameState;
    public CursorManager cursorManager;

    private void Start()
    {
        delay = new Delay();
    }
    private void Update()
    {
        if (player != null)
        {
            if (player.position.y < -10)
            {
                delay.Init(duration);
                Destroy(player.gameObject);
            }
        }
        else
        {
            text.enabled = true;
            if (delay.IsOver)
            {
                gameState.DeleteLastGameState();
                cursorManager.Enable();
                managerScene.LoadMainMenu();
            }
        }
    }
}
