using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class PlayerMovement: MonoBehaviour

{
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.DOMoveX(-0.89f, 1.5f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.DOMoveX(0.89f, 1.5f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.DOMoveX(-0.08f, 1.5f);
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
            var playerMovement =Instantiate(_container.Resolve<PlayerMovement>(), Camera.main.transform);
            Transform transform1;
            (transform1 = playerMovement.transform).Rotate(-6,0,0);
            transform1.position = param;
            return playerMovement;
        }
        
    }
    
}