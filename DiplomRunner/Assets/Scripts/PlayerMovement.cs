using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidBody;
    
    [SerializeField] private float directForce;
    [SerializeField] private float turnForce;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float currentSpeed;
    
   private void Awake ()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
   

   private void FixedUpdate()
    {
        _rigidBody.AddForce(0,0,directForce*Time.fixedTime);
        var velocity = _rigidBody.velocity;
        _rigidBody.velocity = new Vector3(velocity.x, velocity.y, Math.Min(velocity.z, maxSpeed));
        if (Input.GetKey(KeyCode.D))
        {
            _rigidBody.AddForce(turnForce*Time.deltaTime, 0, directForce);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            _rigidBody.AddForce(-turnForce*Time.deltaTime, 0, directForce);
        }
    }

   public class Factory : PlaceholderFactory<PlayerMovement>
   {
       
   }

}
