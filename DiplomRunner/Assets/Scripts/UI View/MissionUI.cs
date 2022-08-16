using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI_View
{
    public class MissionUI :UIView
    {
        [SerializeField] private Button exitButton;
        [SerializeField] private AudioSource clickToExit;
        private void Awake()
        {
            exitButton.onClick.AddListener((() =>
            {
                GameContext.Instance.ShowView(nameof(MainMenuUIView));
                clickToExit.Play();
            }));
            Initialize();
        }
        public override string ViewName => nameof(MissionUI);
    }
}