using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = System.Random;
namespace Scripts
{
    public enum TaxiPosition{
     Left,
     Right,
     Center
    }
    public class TaxiEnemyGenerator : ITickable
    {
        private const float _road = 115f;
        private readonly PlayerMovement _playerMovement;
        private List<TaxiEnemyView> _taxiViews = new List<TaxiEnemyView>();
        private TaxiEnemyView.Pool _pool;
        private readonly Random _random = new Random();

        public TaxiEnemyGenerator(PlayerMovement playerMovement, TaxiEnemyView.Pool taxiPool)
        {
            _playerMovement = playerMovement;
            _pool = taxiPool;
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < 5; i++)
            {
                AddEnemy((TaxiPosition) _random.Next( 0, 3), i * 15);
            }
        }
        
        public void Tick()
        {
            var removeList = new List<int>();
            for (var i = 0; i < _taxiViews.Count; i++)
            {
                if (_playerMovement.transform.position.z - 2f > _taxiViews[i].transform.position.z)
                {
                    removeList.Add(i);
                }
            }
            foreach (var i in removeList)
            {
                _pool.Despawn(_taxiViews[i]);
                _taxiViews.RemoveAt(i);
                AddEnemy((TaxiPosition) _random.Next( 0, 3), _playerMovement.transform.position.z - 5f + _road);
            }
            
        }

        private void AddEnemy(TaxiPosition taxiPosition, float z)
        {
            switch (taxiPosition)
            {
                case TaxiPosition.Left:
                    _taxiViews.Add(_pool.Spawn(new Vector3(0.94f,1.62f,z)));
                    break;
                case TaxiPosition.Center:
                    _taxiViews.Add(_pool.Spawn(new Vector3(-0.01f,1.62f,z)));
                    break;
                case TaxiPosition.Right:
                    _taxiViews.Add(_pool.Spawn(new Vector3(-0.94f,1.62f,z)));
                    break;
            }
        }
    }
}