using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemyView : MonoBehaviour
{
   
    private void Update()
    {
        
    }

    public class Pool : MonoMemoryPool<Vector3, EnemyView>
    {
       
        protected override void Reinitialize(Vector3 item, EnemyView enemyView)
        {
            enemyView.transform.position = item;
        }
    }
}
