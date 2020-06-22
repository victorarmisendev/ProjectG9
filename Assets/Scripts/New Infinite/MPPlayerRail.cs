using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MPPlayerRail : MonoBehaviour
{
    //Objects   
    public GameObject toSpawn = null;
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
    public int points= 500;
    //Speeds    
    private int speed = 50; //Constant speed player
    private float speedChangeRail = 3.0f;
    public bool isDead = false;

    public int CarID;
    // Start is called before the first frame update
    void Start()
    {
        //The position with the player starts. 
        //SINGLER PLAYER: MODE. 
       
        rb = GetComponent<Rigidbody>();
        initialRot = rb.rotation;
        InvokeRepeating("accelerate", 8.0f, 8.0f);
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



    private void accelerate()
    {
        speed += 10;
        if (speedChangeRail <= 6.0f)
        {
            speedChangeRail += 0.5f;
        }
        else if (speedChangeRail > 6.0f)
        {
            speedChangeRail = 6.0f;
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
            
            if (partOfTheCar.GetComponent<Renderer>().isVisible == false)
            {
                lives--;
                //Change pos. Change pos in a place without collision or walls. 
                //Get a visibles fields seen in the camera.
                transform.position = toSpawn.GetComponent<GetRespawn>().toSpawn.transform.position;

            }

            if(pad.yButton.wasPressedThisFrame)
            {
                GameObject Record = GameObject.FindGameObjectWithTag("Save");
                Record.GetComponent<inGameRecord>().newAScore = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<MPPlayerRail>().points;
                Record.GetComponent<inGameRecord>().CARID = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<MPPlayerRail>().CarID;
                Record.GetComponent<inGameRecord>().Gamemode = 3;
                Record.GetComponent<inGameRecord>().PlayerID = 1;
                SceneManager.LoadScene("End");
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
