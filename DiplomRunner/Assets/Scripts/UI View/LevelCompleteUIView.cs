using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI_View
{
    public class LevelCompleteUIView : UIView
    {   [SerializeField] private Button homeButton;
        [SerializeField] private Button replayButton;
        private void Awake()
        {
            homeButton.onClick.AddListener(() => GameContext.Instance.ShowView(nameof(MainMenuUIView)));
            replayButton.onClick.AddListener(Restart);
            Initialize();
        }
        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
        
        public override string ViewName => nameof(LevelCompleteUIView);
    }
}