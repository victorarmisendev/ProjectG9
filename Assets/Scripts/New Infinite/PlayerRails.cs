using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRails : MonoBehaviour
{

    public GameObject[] rails;
    public Gamepad pad;
    private int count = 0;
    private Rigidbody rb;
    public int speed; //Constant speed player
    public float timerChangeRail;

    void Start()
    {
        //The position with the player starts. 
        //SINGLER PLAYER: MODE. 
        pad = Gamepad.all[0];
        transform.position = rails[0].transform.position;
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        //if (CameraFollow.start)
        //{
        //    rb.MovePosition(rb.position + Vector3.forward * speed * Time.fixedDeltaTime);

        //    //LERP ON: 
            

        //}



    }

    void Update()
    {
        if (CameraFollow.start)
        {
            //Move the player in Update to change the rail. JOYSTICK LEFT. 
            if (pad.leftStick.left.wasPressedThisFrame)
            {
                //Go to rail of his left. 
                count--;
                count = Mathf.Clamp(count, 0, rails.Length - 1);
                //transform.position = rails[count].transform.position;
                //transform.position = new Vector3(rails[count].transform.position.x,
                //                                transform.position.y,
                //                                transform.position.z);
                timerChangeRail = 0.0f;
            }

            if (pad.leftStick.right.wasPressedThisFrame)
            {
                //Go to rail of his right. 
                count++;
                count = Mathf.Clamp(count, 0, rails.Length - 1);
                //transform.position = new Vector3(rails[count].transform.position.x,
                //                    transform.position.y,
                //                    transform.position.z);
                timerChangeRail = 0.0f;
            }
            if (timerChangeRail <= 0.0f)
                timerChangeRail += 0.1f;

            Vector3 toPos = new Vector3(rails[count].transform.position.x,
                                    transform.position.y,
                                    transform.position.z);

            timerChangeRail = Mathf.Clamp(timerChangeRail, 0, 1.0f);
            transform.position = Vector3.Lerp(transform.position, toPos, timerChangeRail);
            transform.position += Vector3.forward * speed * Time.deltaTime;

        }
       

       



    }
}
