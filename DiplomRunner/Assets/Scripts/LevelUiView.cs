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
        private int _coins = 0;
        private int _health = 5;

        [Inject] private SignalBus _signalBus;
        [Inject] private SignalBus _signal;
        [SerializeField] private GameObject lifeOne;
        [SerializeField] private GameObject lifeTwo;
        [SerializeField] private GameObject lifeThree;
        [SerializeField] private GameObject lifeFour;
        [SerializeField] private GameObject lifeFive;
        public static float RealTime;

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
            RealTime += Time.deltaTime;
            DisplayTime(RealTime);
            scoreText.text = ((int)(Camera.main.transform.position.z)).ToString();
           
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
                Debug.Log("game over");
                GameContext.Instance.ShowView(nameof(GameOverUIView));
                var scene = SceneManager.GetActiveScene().name;
                GameContext.Instance.SceneService.UnLoadScene(scene);
                Debug.Log(scene);
            }
        }
    }
}