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
    Vector3 toPos;
    public int speedChangeRail;
    Quaternion initialRot;
    public GameObject partOfTheCar;
    public int lives;
    public Camera main;
    GameObject toSpawn = null;

    void Start()
    {
        //The position with the player starts. 
        //SINGLER PLAYER: MODE. 
        pad = Gamepad.all[0];
        transform.position = rails[0].transform.position;
        rb = GetComponent<Rigidbody>();
        initialRot = rb.rotation;

    }

    private void FixedUpdate()
    {
        if (CameraFollow.start)
        {
            toPos = new Vector3(rails[count].transform.position.x,
                        transform.position.y,
                        transform.position.z);
            rb.position = Vector3.Lerp(transform.position, toPos, Time.fixedDeltaTime * speedChangeRail);
            rb.rotation = Quaternion.Lerp(rb.rotation, initialRot, Time.fixedDeltaTime * speedChangeRail);
            rb.MovePosition(rb.position + (Vector3.forward * speed) * Time.fixedDeltaTime);            
        }
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
            }

            if (pad.leftStick.right.wasPressedThisFrame)
            {
                //Go to rail of his right. 
                count++;
                count = Mathf.Clamp(count, 0, rails.Length - 1);
            }

            //speed
            RaycastHit hit;
            if (Physics.Raycast(main.transform.position,
                main.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "field")
                {
                    var boneChild = hit.transform.Find("Reset");
                    toSpawn = boneChild.gameObject;
                    Debug.Log("Enter" + " :" + hit.transform.name);
                }
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }


            if (partOfTheCar.GetComponent<Renderer>().isVisible == false)
            {
                lives--;
                //Change pos. Change pos in a place without collision or walls. 
                //Get a visibles fields seen in the camera.
                transform.position = toSpawn.transform.position;

            }

        }    
    }


  
}
