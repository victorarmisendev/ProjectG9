using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerArena : MonoBehaviour
{
    public Gamepad pad;
    float speed = 0.0f;
    float direction = 0.0f;
    public Rigidbody rb;
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pad = Gamepad.all[0]; //El primer jugador lleva el menu.
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pad.rightTrigger.isPressed)
        {
            if(speed < 0.8f)
            {
                speed += 0.003f;
            }
            else if (speed >= 0.08f)
            {
                speed = 0.8f;
            }
        }
        else if (pad.leftTrigger.isPressed)
        {
            print("left");
            if (speed > -0.3f)
            {
                speed -= 0.003f;
            }
            else if (speed <= -0.3f)
            {
                speed = -0.3f;
            }
        }
        else if(!pad.rightTrigger.isPressed && !pad.leftTrigger.isPressed)
        {
            if(speed > 0.0f)
            {
                speed -= 0.005f;
            }
            else
            {
                speed = 0.0f;
            }
        }

        if (pad.leftStick.left.isPressed)
        {
            direction = -2.5f;
        }
        else if(pad.leftStick.right.isPressed)
        {
            direction = 2.5f;
        }
        else
        {
            direction = -0.0f;
        }
        //if (speed >= 0.0f)
        //{
        //    transform.Translate(Vector3.forward * speed);
        //}
        //else
        //{
        //    transform.Translate(Vector3.back * speed);
        //}
        
        //transform.Rotate(0.0f, direction, 0.0f);

        rb.MovePosition(rb.position + transform.forward * speed);
        Quaternion deltaRot = Quaternion.Euler(0.0f, direction, 0.0f);
        rb.MoveRotation(rb.rotation * deltaRot);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cliff")
        {
            speed = 0;
        }
    }
}
