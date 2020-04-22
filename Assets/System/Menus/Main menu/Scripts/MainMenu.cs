using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameState savedData;
    public GameObject continueButton;
    public Popup GameUserInput;

    private void Start()
    {
        if (savedData.IsSaveExist)
            continueButton.SetActive(true);
    }
    public void RenderNewGameUserInput()
    {
        GameUserInput.TurnOnWindow();
    }
}
