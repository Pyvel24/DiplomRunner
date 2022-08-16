using System;
using DefaultNamespace;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI_View
{
    public class LevelCompleteUIView : UIView
    {
        [SerializeField] private Button homeButton;
        [SerializeField] private Button replayButton;
        [SerializeField] private TextMeshProUGUI textScore;
        [SerializeField] private TextMeshProUGUI textTime;
        [SerializeField] private TextMeshProUGUI textCoin;
        [SerializeField] private TextMeshProUGUI textHighScore;
        [SerializeField] private AudioSource replay;
        [SerializeField] private AudioSource home;
        [SerializeField] private AudioSource win;
        private void Start()
        {
            
        }

        private void Awake()
        {
            win.Play();
            homeButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(MainMenuUIView));
                home.Play();
            });
            replayButton.onClick.AddListener(Restart);
            Initialize();
        }

        private void Restart()
        {
            var asyncOperation = GameContext.Instance.SceneService.LoadScene("MainScene");
            asyncOperation.completed += operation => { GameContext.Instance.HideView(); };
            replay.Play();
            
        }

        private void Update()
        {
            textCoin.text = LevelUiView.CoinDisp.ToString();
            textTime.text = LevelUiView.RealTime.ToString();
            textScore.text = LevelUiView.ScoreDisp.ToString();
            textHighScore.text = LevelUiView.HighScoreDisp.ToString();
        }

        public override string ViewName => nameof(LevelCompleteUIView);
    }
}