using System;
using Signal;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace
{
    public class LevelUiView: MonoBehaviour
    {
        [SerializeField] private Text timeText;
        [SerializeField] private Text coinView;
        private int _coins = 0;

        [Inject] private SignalBus _signalBus;
        
        public static float RealTime;

        private void Start()
        {
            _signalBus.Subscribe<CoinCollected>(() => _coins++);
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
        }
    }
}