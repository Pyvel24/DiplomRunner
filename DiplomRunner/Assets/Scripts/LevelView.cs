using UnityEngine;
using Zenject;

public class LevelView : MonoBehaviour
{
    public class Pool : MonoMemoryPool<Vector3, LevelView>
    {
        protected override void Reinitialize(Vector3 p1, LevelView item)
        {
            item.transform.position = p1;
            
        }
    }
}
