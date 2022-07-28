﻿using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace DefaultNamespace
{
    public enum EnemyPosition
    {
        Left,
        Center,
        Right
    }
    
    public class PoliceEnemyGenerator: ITickable
    {
        private const float RoadLenght = 115f;
        private readonly Random _random = new Random();
        private PoliceEnemyView.Pool _enemyPool;
        private readonly List<PoliceEnemyView> _enemyViews = new List<PoliceEnemyView>();
        private readonly PlayerMovement _playerMovement;
        
        public PoliceEnemyGenerator( PoliceEnemyView.Pool enemyPool, PlayerMovement playerMovement)
        {
            _enemyPool = enemyPool;
            _playerMovement = playerMovement;
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < 5; i++)
            {
                AddEnemy((EnemyPosition) _random.Next( 0, 3), i * 20);
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
                AddEnemy((EnemyPosition) _random.Next(0, 3), _playerMovement.transform.position.z + 5f + RoadLenght);
            }
        }

        private void AddEnemy(EnemyPosition enemyPosition, float z)
        {
            switch (enemyPosition)
            {
                case EnemyPosition.Left:
                    _enemyViews.Add(_enemyPool.Spawn(new Vector3(0.94f,1.7f,z)));
                    break;
                case EnemyPosition.Center:
                    _enemyViews.Add(_enemyPool.Spawn(new Vector3(-0.01f,1.7f,z)));
                    break;
                case EnemyPosition.Right:
                    _enemyViews.Add(_enemyPool.Spawn(new Vector3(-0.94f,1.7f,z)));
                    break;
            }
        }
    }
}