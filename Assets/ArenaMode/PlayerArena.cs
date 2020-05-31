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

    // Start is called before the first frame update
    void Start()
    {
        pad = Gamepad.all[0]; //El primer jugador lleva el menu.
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pad.rightTrigger.isPressed)
        {
            if(speed < 1.0f)
            {
                speed += 0.005f;
            }
            else if (speed >= 1.0f)
            {
                speed = 1.0f;
            }
        }
        else if(!pad.rightTrigger.isPressed)
        {

                if (speed > 0.0f)
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
            direction = -1.5f;
        }
        else if(pad.leftStick.right.isPressed)
        {
            direction = 1.5f;
        }
        else
        {
            direction = -0.0f;
        }
        if (speed >= 0.0f)
        {
            transform.Translate(Vector3.forward * speed);
        }
        else
        {
            transform.Translate(Vector3.back * speed);
        }
        
        transform.Rotate(0.0f, direction, 0.0f);
    }
}
