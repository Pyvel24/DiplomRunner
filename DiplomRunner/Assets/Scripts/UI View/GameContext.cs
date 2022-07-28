using System.Linq;
using DefaultNamespace.Interfaces;
using UI_View;
using UnityEngine;

namespace DefaultNamespace.UI_View
{
    public class GameContext : MonoBehaviour, IGameContext
    {
        public static GameContext Instance;
        [SerializeField] private UIView[] views;
        private UIView _currentView;
        private void Start()
        {
            _currentView = views.First(v => v.ViewName == nameof(MainMenuUIView));
            _currentView.Show();
        }

        public void ShowView(string viewName)
        {
            var tweener = _currentView.Hide();
            tweener.onComplete += () =>
            {
                _currentView = views.First(v => v.ViewName == viewName);
                _currentView.Show();
            };
        }

        public void HideView()
        {
            _currentView.Hide();
        }
    }
}