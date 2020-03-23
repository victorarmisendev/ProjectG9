using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Rigidbody RB;
    Vector3 Mov;
 
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {      
        Mov.x = Input.GetAxisRaw("Horizontal");
        Mov.z = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        //Acelerar con el de RT. 
        if (gamepad.rightTrigger.isPressed)
        {
            RB.MovePosition(RB.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        }

        Vector2 gp = gamepad.leftStick.ReadValue();

        if(gp.x > 0.0f)
        {
            RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f , 100.0f * Time.fixedDeltaTime, 0.0f));
        }
        if (gp.x < 0.0f)
        {
            RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f, -100.0f * Time.fixedDeltaTime, 0.0f));
        }

        //RB.MovePosition(RB.position + Mov * moveSpeed * Time.fixedDeltaTime); // Movimiento en XY.       

    }
}
