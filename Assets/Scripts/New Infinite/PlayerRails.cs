using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerRails : MonoBehaviour
{

    //Objects   
    GameObject toSpawn = null;
   public GameObject partOfTheCar;
    public GameObject Spawntriger;
    //Arrays   
    public GameObject[] rails;
    //Pos   
    Vector3 toPos;   
    Quaternion initialRot;
    //Var    
    public Gamepad pad;
    private int count = 0;
    private Rigidbody rb;      
    public Camera main;
    public GameObject finishCanvas;
    //
    public int lives = 3;
    public int points;
    //Speeds    
    private int speed = 50; //Constant speed player
    private float speedChangeRail = 3.0f;
    public bool isDead = false;

    public int CarID;

    void Start()
    {
        //The position with the player starts. 
        //SINGLER PLAYER: MODE. 
        pad = Gamepad.all[0];
        transform.position = rails[2].transform.position;
        rb = GetComponent<Rigidbody>();
        initialRot = rb.rotation;
        InvokeRepeating("accelerate", 8.0f, 8.0f);
        toSpawn = Spawntriger.GetComponent<GetRespawn>().toSpawn;

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
        if(speedChangeRail <= 6.0f)
        {
            speedChangeRail += 0.5f;
        }
        else if(speedChangeRail > 6.0f)
        {
            speedChangeRail = 6.0f;
        }
        
    }

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

            if (pad.yButton.wasPressedThisFrame)
            {
                GameObject Record = GameObject.FindGameObjectWithTag("Save");
                Record.GetComponent<inGameRecord>().newAScore = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<MPPlayerRail>().points;
                Record.GetComponent<inGameRecord>().CARID = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<MPPlayerRail>().CarID;
                Record.GetComponent<inGameRecord>().Gamemode = 1;
                Record.GetComponent<inGameRecord>().PlayerID = 1;
                SceneManager.LoadScene("End");
            }

            if (partOfTheCar.GetComponent<Renderer>().isVisible == false)
            {
                lives--;
                //Change pos. Change pos in a place without collision or walls. 
                //Get a visibles fields seen in the camera.
                transform.position = Spawntriger.GetComponent<GetRespawn>().toSpawn.transform.position;
                count = toSpawn.GetComponent<GetRespawn>().toSpawn.GetComponent<Numero>().carril;

            }
         
        }

        if (lives <= 0)
        {
            //Finish the match.
            GameObject Record = GameObject.FindGameObjectWithTag("Save");
            Record.GetComponent<inGameRecord>().newSScore = points;
            Record.GetComponent<inGameRecord>().CARID = CarID;
            Record.GetComponent<inGameRecord>().Gamemode = 1;
            Record.GetComponent<inGameRecord>().PlayerID = 1;
            SceneManager.LoadScene("End");
        }
    }
    IEnumerator Finish(float seconds)
    {
        finishCanvas.SetActive(true);
        yield return new WaitForSeconds(seconds);
        //GameObject par = Instantiate(explosion, rb.position, explosion.transform.rotation);
        //Destroy(this.gameObject);
        //Destroy(par, 3.0f);
        //SceneManager.LoadScene("Splash"); //Deberia ser esto. 
         //Deberia ser esto. 
    }



}
