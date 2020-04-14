using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectGameModes : MonoBehaviour
{
    public Gamepad[] pad;
    //Basic states: 1 Tutorial 2 Infinite 3 Arena. 
    private bool detect = false;
    private float state = 1;
    public Image[] images_modes;
    //Inestable AButton: ERROR. Pressed long time 
    //in scene MenuPrincipal makes pass double scene not in purpose. 
    //Timer to correct this. Working. 
    private float timer = 1.0f;
    private bool ACTIVATE_INPUT = false;
    void Start()
    {
        pad = Gamepad.all.ToArray();
    }

    void Update()
    {
        //Change between these 3 states and change color images.. 
        //to give feedback on selection player. 
        //Move the joy left or right to select the game mode and press A to enter. 
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            ACTIVATE_INPUT = true;
        }
        if (pad[0].leftStick.right.isPressed && detect == false)
        {
            Debug.Log("Right");
            detect = true;
            state++;
        } 
        else if(pad[0].leftStick.left.isPressed && detect == false)
        {
            Debug.Log("Left");
            detect = true;
            state--;
        }
        if(pad[0].leftStick.ReadValue().x == 0.0f)
        {
            detect = false;
            Debug.Log("Released");
        }
        state = Mathf.Clamp(state, 1, 3);
        Debug.Log("The value is: " + state);
        //Feedback:
        if(state == 1)
        {
            images_modes[0].GetComponent<Image>().color = Color.green;
            images_modes[1].GetComponent<Image>().color = Color.grey;
            images_modes[2].GetComponent<Image>().color = Color.grey;
        }     
        else if(state == 2)
        {
            images_modes[0].GetComponent<Image>().color = Color.grey;
            images_modes[1].GetComponent<Image>().color = Color.green;
            images_modes[2].GetComponent<Image>().color = Color.grey;         
        }
        else if (state == 3)
        {
            images_modes[0].GetComponent<Image>().color = Color.grey;
            images_modes[1].GetComponent<Image>().color = Color.grey;
            images_modes[2].GetComponent<Image>().color = Color.green;
        }
        if(pad[0].aButton.isPressed && ACTIVATE_INPUT == true)
        {
            switch(state)
            {
                case 1:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    break;
                case 2:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                    break;
                case 3:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
                    break;
            }
        }
    }
}
