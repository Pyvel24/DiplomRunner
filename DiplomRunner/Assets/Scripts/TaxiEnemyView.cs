using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class TaxiEnemyView : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<Vector3, TaxiEnemyView>
        {
            protected override void Reinitialize(Vector3 offset, TaxiEnemyView item)
            {
                item.transform.position = offset;
                item.transform.DOMoveZ(offset.z + 115f, 60);
            }

            protected override void OnDespawned(TaxiEnemyView item)
            {
                item.gameObject.transform.DOKill();
                base.OnDespawned(item);
            }
        }
    }
}