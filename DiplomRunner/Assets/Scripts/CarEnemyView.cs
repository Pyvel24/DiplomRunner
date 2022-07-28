using DG.Tweening;
using Scripts;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class CarEnemyView : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<Vector3, CarEnemyView>
        {
            protected override void Reinitialize(Vector3 offset, CarEnemyView item)
            {
                item.transform.position = offset;
                item.transform.DOMoveZ(offset.z + 115f, 60);
            }

            protected override void OnDespawned(CarEnemyView item)
            {
                item.gameObject.transform.DOKill();
                base.OnDespawned(item);
            }
        }
    }
}