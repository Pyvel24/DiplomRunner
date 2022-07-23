
using DG.Tweening;
using UnityEngine;
using Zenject;

public class EnemyView : MonoBehaviour
{
    public class Pool : MonoMemoryPool<Vector3, EnemyView>
    {
       
        protected override void Reinitialize(Vector3 item, EnemyView enemyView)
        {
            enemyView.transform.position = item;
            enemyView.transform.DOMoveZ(item.z + 115, 60);
        }

        protected override void OnDespawned(EnemyView item)
        {
            item.gameObject.transform.DOKill();

            base.OnDespawned(item);

        }
    }
}
