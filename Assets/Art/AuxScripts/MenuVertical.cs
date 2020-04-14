using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuVertical : MonoBehaviour
{
    public Gamepad[] pad;
    //Basic states: 1 Settings 2 Controls 3 Credits. 
    private bool detect = false;
    private float state = 1;
    public Text[] text_modes;
    void Start()
    {
        pad = Gamepad.all.ToArray();
    }
    void Update()
    {
        if (pad[0].leftStick.up.isPressed && detect == false)
        {
            Debug.Log("up");
            detect = true;
            state--;
        }
        else if (pad[0].leftStick.down.isPressed && detect == false)
        {
            Debug.Log("down");
            detect = true;
            state++;
        }
        if (pad[0].leftStick.ReadValue().y == 0.0f)
        {
            detect = false;
            Debug.Log("Released");
        }
        state = Mathf.Clamp(state, 1, 3);
        Debug.Log("The value is: " + state);
        //Feedback:
        if (state == 1)
        {
            text_modes[0].GetComponent<Text>().color = Color.green;
            text_modes[1].GetComponent<Text>().color = Color.grey;
            text_modes[2].GetComponent<Text>().color = Color.grey;
        }
        else if (state == 2)
        {
            text_modes[0].GetComponent<Text>().color = Color.grey;
            text_modes[1].GetComponent<Text>().color = Color.green;
            text_modes[2].GetComponent<Text>().color = Color.grey;
        }
        else if (state == 3)
        {
            text_modes[0].GetComponent<Text>().color = Color.grey;
            text_modes[1].GetComponent<Text>().color = Color.grey;
            text_modes[2].GetComponent<Text>().color = Color.green;
        }
    }
}
