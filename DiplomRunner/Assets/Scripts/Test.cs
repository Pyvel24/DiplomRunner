using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class Test
    {
        private int offset = 30;
        private float speed = 0.1f;
        private readonly LevelView.Pool _pool;
        private int _counter = 1;
        private Queue<LevelView> _queue;
 
        public Test(LevelView.Pool pool)
        {
            _pool = pool;
            _queue = new Queue<LevelView>();
            _queue.Enqueue(_pool.Spawn(new Vector3(0, 2, 0)));
            _queue.Enqueue(_pool.Spawn(new Vector3(0, 2, offset)));
            Drug();
        }

        public async UniTaskVoid Drug()
        {
            var pos = Camera.main.transform.position;
            await Camera.main.transform.DOMove(new Vector3(pos.x, pos.y, offset * _counter), 8).SetEase(Ease.Linear).ToUniTask();
            _counter++;
            _pool.Despawn(_queue.Dequeue());
            _queue.Enqueue(_pool.Spawn(new Vector3(0, 2, offset * _counter)));
            Drug();
        }
    }
}