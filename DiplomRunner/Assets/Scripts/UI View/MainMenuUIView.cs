using DefaultNamespace.UI_View;
using UnityEngine;
using UnityEngine.UI;

namespace UI_View
{
    public class MainMenuUIView : UIView
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button settingButton;

        private void Awake()
        {
            Initialize();
            exitButton.onClick.AddListener((() => GameContext.Instance.ShowView(nameof(ExitUIView))));
            settingButton.onClick.AddListener((() => GameContext.Instance.ShowView(nameof(SettingUIView))));
        }

        public override string ViewName => nameof(MainMenuUIView);
    }
}