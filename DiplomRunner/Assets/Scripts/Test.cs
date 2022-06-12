using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class Test : ITickable
    {
        private int offset = 31;
        private float speed = 0.5f;
        private readonly LevelView.Pool _pool;
        private int counter = 2;
        private Queue<LevelView> _queue;

        public Test(LevelView.Pool pool)
        {
            _pool = pool;
            _queue = new Queue<LevelView>();
            _queue.Enqueue(_pool.Spawn(new Vector3(0, 2, 0)));
            _queue.Enqueue(_pool.Spawn(new Vector3(0, 2, offset)));
            _queue.Enqueue(_pool.Spawn(new Vector3(0, 2, offset * counter)));

        }

        public void Tick()
        {
            var pos = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(pos.x, pos.y, pos.z + speed);
            if (pos.z / offset > counter)
            {
                counter++;
                _pool.Despawn(_queue.Dequeue());
                _queue.Enqueue(_pool.Spawn(new Vector3(0, 2, offset * counter)));
            }
        }
    }
}