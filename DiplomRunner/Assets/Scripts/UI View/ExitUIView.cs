using System;
using DefaultNamespace.UI_View;
using UnityEngine;
using UnityEngine.UI;

namespace UI_View
{
    public class ExitUIView : UIView
    {
        [SerializeField] private Button agreeButton;
        [SerializeField] private Button disagreeButton;

        private void Awake()
        {
            Initialize();
            disagreeButton.onClick.AddListener((() => GameContext.Instance.ShowView(nameof(MainMenuUIView))));
            agreeButton.onClick.AddListener(Application.Quit);
        }

        public override string ViewName => nameof(ExitUIView);
    }
}