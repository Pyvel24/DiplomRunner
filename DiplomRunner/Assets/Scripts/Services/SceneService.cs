using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using DefaultNamespace.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneService: ISceneService
    {
        private Scene _currentScene;
        private ISceneService _sceneServiceImplementation;
        public SceneService()
        {
            _currentScene = SceneManager.GetActiveScene();
        }

        public AsyncOperation LoadScene(string name)
        {
            
            var asyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
            IsLoading = true;
            asyncOperation.completed += operation =>
            {
                var scene = SceneManager.GetSceneByName(name);
                SceneManager.SetActiveScene(scene);
                _currentScene = scene;
                IsLoading = false;
                
            };
            return asyncOperation;
        }

        public AsyncOperation UnLoadScene(string name)
        {
            return SceneManager.UnloadSceneAsync(name);
        }

       

        public bool IsLoading { get; private set; }
        public IEnumerable<GameObject> GetActiveRoots()
        {
            return _currentScene.GetRootGameObjects();
        }
    }
}