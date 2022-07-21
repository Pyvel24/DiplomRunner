using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Test 
{
    private int offset = 115;
    private readonly LevelView.Pool _pool;
    private int _counter = 1;
    private Queue<LevelView> _queue;
    private readonly PlayerMovement.Factory _factory;
    private readonly EnemyView.Pool _enemyPool;
    private readonly List<EnemyView> _enemyViews = new List<EnemyView>();

    public Test(LevelView.Pool pool, PlayerMovement.Factory factory, EnemyView.Pool enemyPool)
    {
        _pool = pool;
        _factory = factory;
        _enemyPool = enemyPool;
        _factory.Create(new Vector3(-0.06f,1.7f,4f));
        _enemyViews.Add(_enemyPool.Spawn(new Vector3(0.89f,1.7f,20)));
        _enemyViews.Add(_enemyPool.Spawn(new Vector3(-0.06f,1.7f,50)));
        _enemyViews.Add(_enemyPool.Spawn(new Vector3(-0.89f,1.7f,80)));
        _queue = new Queue<LevelView>();
        _queue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, 0)));
        _queue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, offset)));
        Drug();
    }
        

    public async UniTaskVoid Drug()
    {
        var pos = Camera.main.transform.position;
        await Camera.main.transform.DOMove(new Vector3(pos.x, pos.y, offset * _counter), 25).SetEase(Ease.Linear).ToUniTask();
        _counter++;
        _pool.Despawn(_queue.Dequeue());
        _queue.Enqueue(_pool.Spawn(new Vector3(0, 3.8f, offset * _counter)));
        _enemyViews.Add(_enemyPool.Spawn(new Vector3(0.89f,1.7f,20+offset*_counter)));
        _enemyViews.Add(_enemyPool.Spawn(new Vector3(-0.06f,1.7f,50+offset*_counter)));
        _enemyViews.Add(_enemyPool.Spawn(new Vector3(-0.89f,1.7f,80+offset*_counter)));
        var enemy = _enemyViews[0];
        _enemyPool.Despawn(enemy);
        _enemyViews.Remove(enemy);
        Drug();
    }

}