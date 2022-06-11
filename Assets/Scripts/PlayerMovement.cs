using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController movement;
    private Vector3 direction;
    public float forward;

    private int lane = 1;
private int inputBuffer = 0;
    void Start()
    {
        movement = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (inputBuffer < 60) {
            inputBuffer++;
            return;
        }
        direction.z = forward;

        float x = Input.GetAxis("Horizontal");

        if (x < 0 && lane != 0 && inputBuffer > 60) {
            lane -= 1;
            inputBuffer = 0;
        } else if (x > 0 && lane != 2 && inputBuffer > 60) {
            lane += 1;
            inputBuffer = 0;
        }


        if (lane == 0) {
            Debug.Log("left");
            transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
        } else if (lane == 1) {
            Debug.Log("center");

       transform.position = new Vector3(-0.1f, transform.position.y, transform.position.z);
        } else {
            Debug.Log("right");

       transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
        }

        inputBuffer++;

    }

    private void FixedUpdate(){
        movement.Move(direction * Time.fixedDeltaTime);
    }
}
