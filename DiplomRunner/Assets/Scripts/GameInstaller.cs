using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class GameInstaller: MonoInstaller
    {
        [SerializeField] private LevelView levelViewPrefab;
        [SerializeField] private Transform targetPrefab;
        public override void InstallBindings()
        {
            Container.BindMemoryPool<LevelView, LevelView.Pool>()
                .WithInitialSize(2)
                .FromNewComponentOnNewPrefab(levelViewPrefab);
            Container.BindFactory<PlayerMovement, PlayerMovement.Factory>().FromNewComponentOnNewPrefab(targetPrefab);
            Container.BindInterfacesAndSelfTo<Test>().AsSingle().NonLazy();
        }
    }
}