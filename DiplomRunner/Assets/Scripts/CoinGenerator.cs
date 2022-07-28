using System.Collections.Generic;
using UnityEngine; 
using Zenject;
using Random = System.Random;
namespace DefaultNamespace
{
    public enum CoinsPosition
    {
        Left,
        Center,
        Right
    }
    public class CoinGenerator : ITickable
    {
        private const float RoadLenght = 115f;
        
        private readonly CoinView.Pool _coinPool;
        private readonly List<CoinView> _coinsViews = new List<CoinView>();
        private readonly Random _random = new Random();
        private readonly PlayerMovement _playerMovement;
        public CoinGenerator(PlayerMovement playerMovement, CoinView.Pool coinPool)
        {
            
            _coinPool = coinPool;
            _playerMovement = playerMovement;
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < 15; i++)
            {
                AddCoin((CoinsPosition) _random.Next(0, 3), i*6);
            }
        }
        public void Tick()
        {
            var removeList = new List<int>();
            for (int i = 0; i < _coinsViews.Count; i++)
            {
                if (_playerMovement.transform.position.z - 2f > _coinsViews[i].transform.position.z)
                {
                    removeList.Add(i);
                }
            }

            foreach (var i in removeList)
            {
                _coinPool.Despawn(_coinsViews[i]);
                _coinsViews.RemoveAt(i);
                AddCoin((CoinsPosition)_random.Next(0,3), _playerMovement.transform.position.z + RoadLenght);
            }
        }

        private void AddCoin(CoinsPosition coinsPosition, float z)
        {
            switch (coinsPosition)
            {
                case CoinsPosition.Left:
                    _coinsViews.Add(_coinPool.Spawn(new Vector3(0.94f,2f,z)));
                    break;
                case CoinsPosition.Center:
                    _coinsViews.Add(_coinPool.Spawn(new Vector3(-0.01f,2f,z)));
                    break;
                case CoinsPosition.Right:
                    _coinsViews.Add(_coinPool.Spawn(new Vector3(-0.94f,2f,z)));
                    break;
            }
        }
    }
}