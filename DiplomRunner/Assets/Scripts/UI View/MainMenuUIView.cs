using System;
using System.Collections.Generic;
using DefaultNamespace.UI_View;
using DG.Tweening;
using Interfaces;
using Models;
using Services;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI_View
{
    public class MainMenuUIView : UIView
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button messageButton;
        [SerializeField] private Button missionButton;
        [SerializeField] private AudioSource clickToGame;
        [SerializeField] private AudioSource clickToExit;
        [SerializeField] private AudioSource clickToSettings;
        [SerializeField] private AudioSource clickToMessage;
        [SerializeField] private AudioSource clickToMission;
        
        private void Awake()
        {
            Initialize();
            startButton.onClick.AddListener(() =>
            {
                clickToGame.Play();
                
                var asyncOperation = GameContext.Instance.SceneService.LoadScene("MainScene");
                asyncOperation.completed += operation =>
                {
                    GameContext.Instance.HideView();
                };
            });
            exitButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(ExitUIView));
                clickToExit.Play();
            });
            settingButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(SettingUIView));
                clickToSettings.Play();
            });
            messageButton.onClick.AddListener((() =>
            {
                GameContext.Instance.ShowView(nameof(MessageUI));
                clickToMessage.Play();
            }));
            missionButton.onClick.AddListener((() =>
            {
                GameContext.Instance.ShowView(nameof(MissionUI));
                clickToMission.Play();
            }));
        }

        public override string ViewName => nameof(MainMenuUIView);
    }
}