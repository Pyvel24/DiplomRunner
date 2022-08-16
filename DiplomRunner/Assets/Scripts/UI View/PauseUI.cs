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
        [SerializeField] private Button buttonPause;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private AudioSource menu;
        [SerializeField] private AudioSource resume;
        [SerializeField] private AudioSource pause;
        
        private bool PauseGame;

        public void Awake()
        {  Initialize();
           buttonPause.onClick.AddListener(Pause);
           continueButton.onClick.AddListener(Resume);
           menuButton.onClick.AddListener(ToMenu);
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
           resume.Play();
        }

        private void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseGame = true;
            pause.Play();
        }

        private void ToMenu()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
            menu.Play();
        }

       
        public override string ViewName => nameof(PauseUI);
    }
}