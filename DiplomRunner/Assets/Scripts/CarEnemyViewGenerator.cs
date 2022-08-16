using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace Scripts
{
    public enum CarPosition
    {
        Left,
        Center,
        Right
    }

    public class CarEnemyGenerator : ITickable
    {
        private const float RoadLenght = 115f;
        private readonly Random _random = new Random();
        private CarEnemyView.Pool _enemyPool;
        private readonly List<CarEnemyView> _enemyViews = new List<CarEnemyView>();
        private readonly PlayerMovement _playerMovement;

        public CarEnemyGenerator(CarEnemyView.Pool enemyPool, PlayerMovement playerMovement)
        {
            _enemyPool = enemyPool;
            _playerMovement = playerMovement;
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < 5; i++)
            {
                AddEnemy((CarPosition) _random.Next(0, 3), i * 25);
            }
        }

        public void Tick()
        {
            var removeList = new List<int>();
            for (var i = 0; i < _enemyViews.Count; i++)
            {
                if (_playerMovement.transform.position.z - 2f > _enemyViews[i].transform.position.z)
                {
                    removeList.Add(i);
                }
            }

            foreach (var i in removeList)
            {
                _enemyPool.Despawn(_enemyViews[i]);
                _enemyViews.RemoveAt(i);
                AddEnemy((CarPosition) _random.Next(0, 3), _playerMovement.transform.position.z + 5f  + RoadLenght);
            }
        }

        private void AddEnemy(CarPosition carPosition, float z)
        {
            switch (carPosition)
            {
                case CarPosition.Left:
                    _enemyViews.Add(_enemyPool.Spawn(new Vector3(0.94f, 1.62f, z)));
                    break;
                case CarPosition.Center:
                    _enemyViews.Add(_enemyPool.Spawn(new Vector3(-0.01f, 1.62f, z)));
                    break;
                case CarPosition.Right:
                    _enemyViews.Add(_enemyPool.Spawn(new Vector3(-0.94f, 1.62f, z)));
                    break;
            }
        }
    }
}