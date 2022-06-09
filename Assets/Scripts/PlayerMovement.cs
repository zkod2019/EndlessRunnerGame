using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController movement;
    private Vector3 direction;
    public float forward;
    void Start()
    {
        movement = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forward;
    }

    private void FixedUpdate(){
        movement.Move(direction * Time.fixedDeltaTime);
    }
}
