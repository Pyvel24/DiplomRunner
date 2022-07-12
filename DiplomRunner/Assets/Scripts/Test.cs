using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Test 
{
    private int offset = 30;
    private readonly LevelView.Pool _pool;
    private int _counter = 1;
    private Queue<LevelView> _queue;
    private readonly PlayerMovement.Factory _factory;

    public Test(LevelView.Pool pool, PlayerMovement.Factory factory)
    {
        _pool = pool;
        _factory = factory;
        _factory.Create(new Vector3(0,1.6f,3.6f));
        _queue = new Queue<LevelView>();
        _queue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, 0)));
        _queue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, offset)));
        Drug();
    }
        

    public async UniTaskVoid Drug()
    {
        var pos = Camera.main.transform.position;
        await Camera.main.transform.DOMove(new Vector3(pos.x, pos.y, offset * _counter), 8).SetEase(Ease.Linear).ToUniTask();
        _counter++;
        _pool.Despawn(_queue.Dequeue());
        _queue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, offset * _counter)));
        Drug();
    }
}