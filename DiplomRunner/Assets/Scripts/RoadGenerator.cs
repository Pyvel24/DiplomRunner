using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class RoadGenerator 
{
    private int offset = 115;
    private readonly LevelView.Pool _pool;
    private int _counter = 1;
    private Queue<LevelView> _roadQueue;
    private readonly PlayerMovement.Factory _factory;

    public RoadGenerator(LevelView.Pool pool, PlayerMovement.Factory factory)
    {
        _pool = pool;
        _factory = factory;
        _factory.Create(new Vector3(-0.01f,1.7f,4f));
        _roadQueue = new Queue<LevelView>();
        _roadQueue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, 0)));
        _roadQueue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, offset)));
        Drug();
    }
    
    public async UniTaskVoid Drug()
    {
        var pos = Camera.main.transform.position;
        await Camera.main.transform.DOMove(new Vector3(pos.x, pos.y, offset * _counter), 20).SetEase(Ease.Linear).ToUniTask();
        _counter++;
        _pool.Despawn(_roadQueue.Dequeue());
        _roadQueue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, offset * _counter)));
        Drug();
    }
    
}