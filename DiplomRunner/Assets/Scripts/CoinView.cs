using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class CoinView: MonoBehaviour
    {
        private float rotationSpeed = 100;
       
        private void Start()
        {
            rotationSpeed += Random.Range(0, rotationSpeed / 4.0f);
        }

        private void Update()
        {
            transform.Rotate(0,0,rotationSpeed*Time.deltaTime);
        }
        
        
        public class Pool : MonoMemoryPool<Vector3, CoinView>
        {
            protected override void Reinitialize(Vector3 p1, CoinView item)
            {
                item.transform.position = p1;
            }
           
        }
    }
}