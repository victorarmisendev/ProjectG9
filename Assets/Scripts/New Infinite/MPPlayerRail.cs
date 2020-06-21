﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MPPlayerRail : MonoBehaviour
{
    //Objects   
    GameObject toSpawn = null;
    public GameObject partOfTheCar;
    //Arrays   
    public GameObject[] rails;
    //Pos   
    Vector3 toPos;
    Quaternion initialRot;
    //Var    
    public Gamepad pad;
    public int count = 0;
    private Rigidbody rb;
    public Camera main;
    public GameObject finishCanvas;
    public PasueMenu pauseMenu;
    public int playerNum;
    //
    public int lives = 3;
    public int points=0;
    //Speeds    
    public int speed; //Constant speed player
    public int speedChangeRail;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        //The position with the player starts. 
        //SINGLER PLAYER: MODE. 
       
        rb = GetComponent<Rigidbody>();
        initialRot = rb.rotation;
    }
    public void SetPosition()
    {
        if (count != 6)
        {
            transform.position = rails[count].transform.position;
        }
    }
    private void FixedUpdate()
    {
        if (CameraFollow.start && !isDead)
        {
            toPos = new Vector3(rails[count].transform.position.x,
                        transform.position.y,
                        transform.position.z);
            rb.position = Vector3.Lerp(transform.position, toPos, Time.fixedDeltaTime * speedChangeRail);
            rb.rotation = Quaternion.Lerp(rb.rotation, initialRot, Time.fixedDeltaTime * speedChangeRail);
            rb.MovePosition(rb.position + (Vector3.forward * speed) * Time.fixedDeltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (CameraFollow.start && !isDead)
        {
            points++;
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
            //speed:
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

        if (lives <= 0)
        {
            //Finish the match.
            Destroy(gameObject);
            isDead = true;
           
        }
    }



}