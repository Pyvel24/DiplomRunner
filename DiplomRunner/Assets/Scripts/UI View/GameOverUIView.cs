using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI_View
{
    public class GameOverUIView : UIView
    {
        [SerializeField] private Button homeButton;
        [SerializeField] private Button replayButton;
        private void Awake()
        {
            homeButton.onClick.AddListener(() => GameContext.Instance.ShowView(nameof(MainMenuUIView)));
            replayButton.onClick.AddListener(Restart);
            Initialize();
        }
        private void Restart()
        {
            var asyncOperation = GameContext.Instance.SceneService.LoadScene("MainScene");
            asyncOperation.completed += operation =>
            {
                GameContext.Instance.HideView();
            };
            
        }

        public override string ViewName => nameof(GameOverUIView);
    }
}