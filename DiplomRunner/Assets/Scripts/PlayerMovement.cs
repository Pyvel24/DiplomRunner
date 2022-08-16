using System;
using System.Runtime.InteropServices;
using DefaultNamespace;
using DG.Tweening;
using Scripts;
using Services;
using Signal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Zenject;

public class PlayerMovement: MonoBehaviour
{
    [Inject] private SignalBus _signalBus;
    [Inject] private CoinView.Pool _pool;
    [Inject] private SignalBus _signal;
    [SerializeField] private AudioSource moveLeft;
    [SerializeField] private AudioSource moveRight;
    [SerializeField] private AudioSource moveCenter;
    [SerializeField] private AudioSource coin;
    [SerializeField] private AudioSource damage;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.DOMoveX(-0.94f, 1.2f);
            moveLeft.Play();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.DOMoveX(-0.01f, 1.2f);
            moveCenter.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.DOMoveX(0.94f, 1.2f);
            moveRight.Play();
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CoinView>(out var coin))
        {
            _signalBus.Fire<CoinCollected>();
            this.coin.Play();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacle"))
        {
            _signal.Fire<Health>();
            damage.Play();
        }
        
    }

   

    public class Factory: PlaceholderFactory<Vector3,PlayerMovement>
    {
        private readonly DiContainer _container;
        public Factory(DiContainer container)
        {
            _container = container;
            
        }
        public override PlayerMovement Create(Vector3 param)
        {
            var playerMovement =_container.Resolve<PlayerMovement>();

            Transform transform;
            (transform = playerMovement.transform).Rotate(0,0,0);
            transform.position = param;
            transform.parent = Camera.main.transform;
            return playerMovement;
        }
    }
}