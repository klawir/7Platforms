using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class PauseMenuManagment : MonoBehaviour
    {
        public GameObject pause;

        public static PauseMenuManagment instance;

        private Command resumeGame;
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            TurnOffWindow();
            resumeGame = new ResumeGame();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                if (pause.activeInHierarchy)
                    resumeGame.Execute();
        }
        public void TurnOffWindow()
        {
            pause.SetActive(false);
            TimeManager.instance.Resume(); 
        }
        public void TurnOnWindow()
        {
            pause.SetActive(true);
            TimeManager.instance.Stop();
        }
    }
}