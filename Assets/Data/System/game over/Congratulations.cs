using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Congratulations : MonoBehaviour
{
    public Text text;
    private Delay delay;
    public float duration;
    public GameState gameState;
    public ManagerScene scene;
    public CursorManager cursorManager;

    private void OnEnable()
    {
        delay = new Delay();
        delay.Init(duration);
        text.enabled = true;
        gameState.Save(true);
    }
    private void Update()
    {
        if (delay.IsOver)
        {
            scene.LoadScoreBoard();
            cursorManager.Enable();
        }
    }
}
