using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerArena : MonoBehaviour
{
    public Gamepad pad;
    float speed = 0.0f;
    float direction = 0.0f;
    public Rigidbody rb;
    public GameObject particle;

    public AudioSource engineSound;
    public float audioVolume;

    public int lives = 3;

    public bool shield = false;
    public int score = 0;

    public int CarID;
    public int PlayerID = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pad = Gamepad.all[0]; //El primer jugador lleva el menu.
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score++;
        if (pad.rightTrigger.isPressed)
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
        else if(!pad.rightTrigger.isPressed)
        {
            
            if(!pad.leftTrigger.isPressed)
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

        }
        if(speed > 0.003f)
        {
            engineSound.volume = speed;
            if (!engineSound.isPlaying)
            {
                engineSound.Play();
            }
        }
        else
        {

            if (engineSound.isPlaying)
            {
                engineSound.Stop();
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
    public void Respwan()
    {
        lives--;
        if(lives <=0)
        {
            GameObject Record = GameObject.FindGameObjectWithTag("Save");
            Record.GetComponent<inGameRecord>().newAScore = score;
            Record.GetComponent<inGameRecord>().CARID = CarID;
            Record.GetComponent<inGameRecord>().Gamemode = 3;
            Record.GetComponent<inGameRecord>().PlayerID = 1;
            SceneManager.LoadScene("End");
        }
        else
        {
            gameObject.transform.position = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cliff")
        {
            speed = 0;
        }
    }
}
