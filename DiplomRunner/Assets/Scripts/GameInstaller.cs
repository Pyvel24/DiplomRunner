using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class GameInstaller: MonoInstaller
    {
        [SerializeField] private LevelView levelViewPrefab;
        
        public override void InstallBindings()
        {
            Container.BindMemoryPool<LevelView, LevelView.Pool>()
                .WithInitialSize(2)
                .FromNewComponentOnNewPrefab(levelViewPrefab);

            Container.BindInterfacesAndSelfTo<Test>().AsSingle().NonLazy();
        }
        
        
    }
}