using System;
using System.Linq;
using DefaultNamespace.Interfaces;
using Interfaces;
using Models;
using Services;
using UI_View;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI_View
{
    public class GameContext : MonoBehaviour, IGameContext
    {
        public static GameContext Instance;
        [SerializeField] private UIView[] views;
        [SerializeField] private AudioService.Sound[] sounds;
        private UIView _currentView;
        public ISceneService SceneService { get; private set; }
        public ISaveService SaveService { get; private set; }
        public ICameraService CameraService { get; set; }
        public IAudioService AudioService { get; private set; }
        private void Awake()
        {
            foreach (var sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.loop = sound.loop;
            }
            AudioService = new AudioService(sounds);
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
            AudioService.Play("Main");
            
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
            var s = SaveService.Load<SettingModel>();
            if (s == null)
            {
                s = new SettingModel();
                SaveService.Write(s);
            }
           
        }
    }
}