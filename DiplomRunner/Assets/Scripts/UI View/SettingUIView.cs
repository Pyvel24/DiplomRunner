using UnityEngine;
using UnityEngine.UI;

namespace UI_View
{
    public class SettingUIView : UIView
    {
        [SerializeField] private Button exitButton;
        private void Awake()
        {
            exitButton.onClick.AddListener(() => GameContext.Instance.ShowView(nameof(MainMenuUIView)));
        }

        public override string ViewName => nameof(SettingUIView);
    }
}