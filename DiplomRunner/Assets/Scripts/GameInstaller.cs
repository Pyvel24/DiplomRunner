using DefaultNamespace;
using Signal;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LevelView levelViewPrefab;
        [SerializeField] private PlayerMovement playerPrefab;
        [SerializeField] private Transform mainLevels;
        [SerializeField] private PoliceEnemyView copPrefab;
        [SerializeField] private Transform enemyPrefabs;
        [SerializeField] private CoinView coinPrefab;
        [SerializeField] private Transform coinPrefabs;
        [SerializeField] private TaxiEnemyView taxiPrefab;
        [SerializeField] private CarEnemyView carPrefab;
        [SerializeField] private LevelUiView levelUiView;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<CoinCollected>();
            Container.DeclareSignal<Health>();
            Container.BindMemoryPool<LevelView, LevelView.Pool>()
                .WithInitialSize(2)
                .FromNewComponentOnNewPrefab(levelViewPrefab).UnderTransform(parent: mainLevels);
            Container.BindInterfacesAndSelfTo<RoadGenerator>().AsSingle().NonLazy();
            Container.BindFactory<Vector3, PlayerMovement, PlayerMovement.Factory>().AsSingle();
            Container.Bind<PlayerMovement>().FromComponentInNewPrefab(playerPrefab).AsSingle();
            Container.BindMemoryPool<PoliceEnemyView, PoliceEnemyView.Pool>().WithInitialSize(3)
                .FromNewComponentOnNewPrefab(copPrefab).UnderTransform(enemyPrefabs);
            Container.BindInterfacesAndSelfTo<PoliceEnemyGenerator>().AsSingle().NonLazy();
            Container.BindMemoryPool<TaxiEnemyView, TaxiEnemyView.Pool>().WithInitialSize(3)
                .FromNewComponentOnNewPrefab(taxiPrefab).UnderTransform(enemyPrefabs);
            Container.BindInterfacesAndSelfTo<TaxiEnemyGenerator>().AsSingle().NonLazy();
            Container.BindMemoryPool<CoinView, CoinView.Pool>().WithInitialSize(15).FromComponentInNewPrefab(coinPrefab)
                .UnderTransform(coinPrefabs);
            Container.BindInterfacesAndSelfTo<CoinGenerator>().AsSingle().NonLazy();
            Container.BindMemoryPool<CarEnemyView, CarEnemyView.Pool>().WithInitialSize(3)
                .FromNewComponentOnNewPrefab(carPrefab).UnderTransform(enemyPrefabs);
            Container.BindInterfacesAndSelfTo<CarEnemyGenerator>().AsSingle().NonLazy();
            Container.Bind<LevelUiView>().FromInstance(levelUiView).AsSingle();
 
        }
    }
}