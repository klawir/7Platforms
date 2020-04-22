
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Abilities abilities;

    private Command pauseMenu;

    private void Start()
    {
        pauseMenu = new PauseGame();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || 
            Input.GetKey(KeyCode.A) || 
            Input.GetKey(KeyCode.S) || 
            Input.GetKey(KeyCode.D)) 
        {
            abilities.movement.Execute();

            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                abilities.sprint.Execute();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) {
                abilities.backToNormalSpeed.Execute();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            abilities.jump.Execute();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.Execute();
        }

        if (Input.GetMouseButton(0))
        {
            if (!(Input.GetKey(KeyCode.W)
                   || Input.GetKey(KeyCode.A)
                   || Input.GetKey(KeyCode.S)
                   || Input.GetKey(KeyCode.D)))
                abilities.shooting.Execute();
        }
    }
}