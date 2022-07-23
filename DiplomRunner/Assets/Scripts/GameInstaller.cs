using DefaultNamespace;
using UnityEngine;
using Zenject;

public class GameInstaller: MonoInstaller
{
    [SerializeField] private LevelView levelViewPrefab;
    [SerializeField] private PlayerMovement playerPrefab;
    [SerializeField] private Transform mainLevels;
    [SerializeField] private EnemyView enemyPrefab;
    [SerializeField] private Transform enemyPrefabs;
    public override void InstallBindings()
    {
        Container.BindMemoryPool<LevelView, LevelView.Pool>()
            .WithInitialSize(2)
            .FromNewComponentOnNewPrefab(levelViewPrefab).UnderTransform(parent:mainLevels);
        Container.BindInterfacesAndSelfTo<RoadGenerator>().AsSingle().NonLazy();
        Container.BindFactory<Vector3, PlayerMovement, PlayerMovement.Factory>().AsSingle();
        Container.Bind<PlayerMovement>().FromComponentInNewPrefab(playerPrefab).AsSingle();
        Container.BindMemoryPool<EnemyView, EnemyView.Pool>().WithInitialSize(3)
            .FromComponentInNewPrefab(enemyPrefab).UnderTransform(enemyPrefabs);
        Container.BindInterfacesAndSelfTo<EnemyGenerator>().AsSingle().NonLazy();
        Container.BindFactory<EnemyPrefabs, EnemyPrefabs.Factory>().AsSingle().NonLazy();
    }
}