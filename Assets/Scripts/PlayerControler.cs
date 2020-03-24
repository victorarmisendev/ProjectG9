using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Rigidbody RB;
    Vector3 Mov;
    public bool canmove = true;
    GameObject a = null;
    private int StunDuration=0;
   /* void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }*/

    void Update()
    {
        Mov.x = Input.GetAxisRaw("Horizontal");
        Mov.z = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if (canmove)
        {
            if(a==null)
            {
                moveSpeed = 5.0f;
            }
            var gamepad = Gamepad.current;
            if (gamepad == null)
                return;

            //Acelerar con el de RT. 
            if (gamepad.rightTrigger.isPressed)
            {
                RB.MovePosition(RB.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
            }

            Vector2 gp = gamepad.leftStick.ReadValue();

            if (gp.x > 0.0f)
            {
                RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f, 100.0f * Time.fixedDeltaTime, 0.0f));
            }
            if (gp.x < 0.0f)
            {
                RB.MoveRotation(RB.rotation * Quaternion.Euler(0.0f, -100.0f * Time.fixedDeltaTime, 0.0f));
            }

            //RB.MovePosition(RB.position + Mov * moveSpeed * Time.fixedDeltaTime); // Movimiento en XY.    
        }

    }
    public void Stun(int segundos)
    {
        canmove = false;
        StartCoroutine(stun(segundos));
    }
    IEnumerator stun(float s)
    {
        yield return new WaitForSeconds(3);//VER COMO HACER SIN HARDCODE
        canmove = true;
    }
    public void DMG(float dmg)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Alquitran>() != null)
        {

            a = other.gameObject;
            moveSpeed = other.gameObject.GetComponent<Alquitran>().slow;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Alquitran>() != null)
        {

            moveSpeed =5.0f;
        }
    }
    public void ChangeSpeed(float _newSpeed)
    {
        moveSpeed = _newSpeed;
    }
}
