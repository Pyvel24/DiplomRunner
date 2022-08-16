using System;
using System.Runtime.InteropServices;
using DefaultNamespace.UI_View;
using Signal;
using UI_View;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace
{
    public class LevelUiView: MonoBehaviour
    {
        [SerializeField] private Text timeText;
        [SerializeField] private Text coinView;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text highScoreText;
        private int _coins = 0;
        private int _health = 5;
        private int _highscore;

        [Inject] private SignalBus _signalBus;
        [Inject] private SignalBus _signal;
        [SerializeField] private GameObject lifeOne;
        [SerializeField] private GameObject lifeTwo;
        [SerializeField] private GameObject lifeThree;
        [SerializeField] private GameObject lifeFour;
        [SerializeField] private GameObject lifeFive;
        public static float RealTime;
        public static float CoinDisp;
        public static float ScoreDisp;
        public static float HighScoreDisp;
        private void Start()
        {
            _signalBus.Subscribe<CoinCollected>(() => _coins++);
            _signal.Subscribe<Health>((() => _health = _health - 1));
            
        }

        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
            float seconds = timeToDisplay % 60;
            timeText.text = $"{minutes:0}:{seconds:00}";
        }
        private void Update()
        {
            coinView.text = _coins.ToString();
            CoinDisp = _coins;
            RealTime += Time.deltaTime;
            DisplayTime(RealTime);
           int lastScore =  int.Parse(scoreText.text = ((int) (Camera.main.transform.position.z)).ToString());
           PlayerPrefs.SetInt("lastScore", lastScore);
           
           int recordScore = PlayerPrefs.GetInt("recordScore");
           if (lastScore > recordScore)
           {
               recordScore = lastScore;
               PlayerPrefs.SetInt("recordScore", recordScore);
               highScoreText.text = recordScore.ToString();
           }
           else
           {
               highScoreText.text = recordScore.ToString();
           }
           ScoreDisp = ((int) (Camera.main.transform.position.z));
           HighScoreDisp = recordScore;
            if (_health == 4)
            {
                lifeFive.SetActive(false);
            }
            if (_health == 3)
            {
                lifeFive.SetActive(false);
                lifeFour.SetActive(false);
                
            }

            if (_health == 2)
            {
                lifeFive.SetActive(false);
                lifeFour.SetActive(false);
                lifeThree.SetActive(false);
            }

            if (_health == 1)
            {
                lifeFive.SetActive(false);
                lifeFour.SetActive(false);
                lifeThree.SetActive(false);
                lifeTwo.SetActive(false);
            }

            if (_health == 0)
            {
                lifeFive.SetActive(false);
                lifeFour.SetActive(false);
                lifeThree.SetActive(false);
                lifeTwo.SetActive(false);
                lifeOne.SetActive(false);
                GameContext.Instance.ShowView(nameof(LevelCompleteUIView));
                var scene = SceneManager.GetActiveScene().name;
                GameContext.Instance.SceneService.UnLoadScene(scene);
            }
            

        }
    }
}