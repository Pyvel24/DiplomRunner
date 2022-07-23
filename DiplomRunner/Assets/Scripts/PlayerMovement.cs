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
            gameObject.transform.DOMoveX(-0.94f, 1.2f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.DOMoveX(-0.01f, 1.2f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.DOMoveX(0.94f, 1.2f);
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