using System;
using Models;
using Services;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI_View
{
    public class PauseUI : UIView
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private Button buttonreplay;
        [SerializeField] private Button buttonPause;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button menuButton;
        private bool PauseGame;

        public void Awake()
        {  Initialize();
           buttonPause.onClick.AddListener(Pause);
           continueButton.onClick.AddListener(Resume);
           buttonreplay.onClick.AddListener(Restart);
           menuButton.onClick.AddListener(() =>
           {   Debug.Log("game over");
               GameContext.Instance.ShowView(nameof(GameOverUIView));
               var scene = SceneManager.GetActiveScene().name;
               GameContext.Instance.SceneService.UnLoadScene(scene);
               Debug.Log(scene);
           });
        }

        public void Start()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (PauseGame)
                {
                    Resume();
                }
                else 
                {
                    Pause();
                }
            }
        }

        private void Resume()
        {
           pauseMenu.SetActive(false);
           Time.timeScale = 1f;
           PauseGame = false;
        }

        private void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseGame = true;
        }

        private void Restart()
        {
            
        }
        public override string ViewName => nameof(PauseUI);
    }
}