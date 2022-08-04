using System;
using System.Linq;
using DefaultNamespace.Interfaces;
using Models;
using Services;
using UI_View;
using UnityEngine;

namespace UI_View
{
    public class GameContext : MonoBehaviour, IGameContext
    {
        public static GameContext Instance;
        [SerializeField] private UIView[] views;
        private UIView _currentView;
        public ISceneService SceneService { get; private set; }
        public ISaveService SaveService { get; private set; }
        public ICameraService CameraService { get; set; }
        private void Awake()
        {
            SceneService = new SceneService();
            SaveService = new SaveService();
            CameraService = new CameraService(Camera.main);
            if (Instance == null)
            {
                Instance = this;
            }
            CheckModels();
        }
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
        private void CheckModels()
        {
            var pm = SaveService.Load<ProgressModel>();
            if (pm == null)
            {
                pm = new ProgressModel();
                SaveService.Write(pm);
            }
           
        }
    }
}