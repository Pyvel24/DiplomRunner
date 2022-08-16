using System;
using DefaultNamespace.UI_View;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI_View
{
    public class ExitUIView : UIView
    {
        [SerializeField] private Button agreeButton;
        [SerializeField] private Button disagreeButton;
        [SerializeField] private AudioSource agree;
        [SerializeField] private AudioSource disagree;

        private void Awake()
        {
            disagreeButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(MainMenuUIView));
                disagree.Play();
            });
            agreeButton.onClick.AddListener(() =>
            {
                Application.Quit();
                agree.Play();
                
            });
        }

        public override string ViewName => nameof(ExitUIView);
    }
}