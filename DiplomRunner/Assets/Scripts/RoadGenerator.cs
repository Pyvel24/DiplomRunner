using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class RoadGenerator: IDisposable 
{
    private int offset = 115;
    private readonly LevelView.Pool _pool;
    private int _counter = 1;
    private Queue<LevelView> _roadQueue;
    private readonly PlayerMovement.Factory _factory;
    private readonly CancellationTokenSource _cts;
    public RoadGenerator(LevelView.Pool pool, PlayerMovement.Factory factory)
    {
        _pool = pool;
        _factory = factory;
        _factory.Create(new Vector3(-0.01f,1.6f,4f));
        _roadQueue = new Queue<LevelView>();
        _roadQueue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, 0)));
        _roadQueue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, offset)));
        _cts = new CancellationTokenSource();
        Drug(_cts.Token);
    }
    
    public async UniTaskVoid Drug(CancellationToken cts)
    {
        
        var pos = Camera.main.transform.position;
        await Camera.main.transform.DOMove(new Vector3(pos.x, pos.y, offset * _counter), 20).SetEase(Ease.Linear).ToUniTask();
        _counter++;
        var roadQueue = _roadQueue.Dequeue();
        if (cts.IsCancellationRequested)
        {
            return;
        }
        _pool.Despawn(roadQueue);
        _roadQueue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, offset * _counter)));
        Drug(cts);
    }

    public void Dispose()
    {
        _cts.Cancel();
    }
}