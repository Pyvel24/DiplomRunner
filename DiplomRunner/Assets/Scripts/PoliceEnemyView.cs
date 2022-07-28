
using DG.Tweening;
using UnityEngine;
using Zenject;

public class PoliceEnemyView : MonoBehaviour
{
    public class Pool : MonoMemoryPool<Vector3, PoliceEnemyView>
    {
       
        protected override void Reinitialize(Vector3 item, PoliceEnemyView policeEnemyView)
        {
            policeEnemyView.transform.position = item;
            policeEnemyView.transform.DOMoveZ(item.z + 115, 60);
        }

        protected override void OnDespawned(PoliceEnemyView item)
        {
            item.gameObject.transform.DOKill();

            base.OnDespawned(item);
        }
    }
}
