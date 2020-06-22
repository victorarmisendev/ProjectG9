using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
public class TutorialRunner : MonoBehaviour
{
    public Gamepad pad;
    public bool ARENA = false;
    ///MODO INFINITE:
    public GameObject[] rails;
    //Pos   
    Vector3 toPos;
    Quaternion initialRot;
    private int count = 0;
    private Rigidbody rb;
    //MODO ARENA:
    float speed = 0.0f;
    float direction = 0.0f;
    //public GameObject particle;

    //public AudioSource engineSound;
    //public float audioVolume;

    public int lives = 3;

    public bool shield = false;
    public int score = 0;
    public GameObject altura;
    public TextMeshProUGUI mode;
    public GameObject infinite, arena;

    void Start()
    {
        pad = Gamepad.all[0];
        //transform.position = rails[0].transform.position;
        rb = GetComponent<Rigidbody>();
        initialRot = rb.rotation;
    }

    private void FixedUpdate()
    {
        if(ARENA)
        {
            //if (pad.rightTrigger.isPressed)
            //{
            //    if (speed < 0.8f)
            //    {
            //        speed += 0.003f;
            //    }
            //    else if (speed >= 0.08f)
            //    {
            //        speed = 0.8f;
            //    }

            //}
            //else if (pad.leftTrigger.isPressed)
            //{
            //    print("left");
            //    if (speed > -0.3f)
            //    {
            //        speed -= 0.003f;
            //    }
            //    else if (speed <= -0.3f)
            //    {
            //        speed = -0.3f;
            //    }
            //}
            //else if (!pad.rightTrigger.isPressed)
            //{

            //    if (!pad.leftTrigger.isPressed)
            //    {
            //        if (speed > 0.0f)
            //        {
            //            speed -= 0.005f;
            //        }
            //        else
            //        {
            //            speed = 0.0f;
            //        }
            //    }

            //}
            //if (speed > 0.003f)
            //{
            //    engineSound.volume = speed;
            //    if (!engineSound.isPlaying)
            //    {
            //        engineSound.Play();
            //    }
            //}
            //else
            //{

            //    if (engineSound.isPlaying)
            //    {
            //        engineSound.Stop();
            //    }
            //}
            if (pad.leftStick.left.isPressed)
            {
                direction = -2.5f;
            }
            else if (pad.leftStick.right.isPressed)
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
            if (pad.rightTrigger.isPressed)
            {
                rb.MovePosition(rb.position + transform.forward * 3.0f);
            }

            if (pad.leftTrigger.isPressed)
            {
                rb.MovePosition(rb.position + transform.forward * -3.0f);
            }

            Quaternion deltaRot = Quaternion.Euler(0.0f, direction, 0.0f);
            rb.MoveRotation(rb.rotation * deltaRot);
        } 
        else
        {
            toPos = new Vector3(rails[count].transform.position.x,
                       altura.transform.position.y,
                       transform.position.z);
            rb.position = Vector3.Lerp(transform.position, toPos, Time.fixedDeltaTime * 3.0f);
            rb.rotation = Quaternion.Lerp(rb.rotation, initialRot, Time.fixedDeltaTime * 3.0f);
            //rb.MovePosition(rb.position + (Vector3.forward * 7.0f * Time.fixedDeltaTime));
        }
    }

    void Update()
    {
        if(pad.aButton.wasPressedThisFrame)
        {
            ARENA = !ARENA;
        }
        if(ARENA)
        {
            mode.text = "Arena";
            infinite.SetActive(false);
            arena.SetActive(true);
        } 
        else
        {
            mode.text = "Infinite";
            infinite.SetActive(true);
            arena.SetActive(false);
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
        }
    }
}
