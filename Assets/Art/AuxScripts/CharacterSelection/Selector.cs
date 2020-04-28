using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Selector : MonoBehaviour
{

    public Gamepad currentPad;
    private float state = 1;
    private bool detect = false;
    public GameObject[] selector_types;

    void Start()
    {
        currentPad = Gamepad.all.ToArray()[0];
        if (currentPad == null)
        {
            Debug.LogError("Gamepad not initialize");
            return;
        }
    }

    void Update()
    {
        //Handle the controls for selection. 
        //Change player and confirm. 
        state = Mathf.Clamp(state, 1, 4);
        if (currentPad.leftStick.right.isPressed && detect == false)
        {
            Debug.Log("Right");
            detect = true;
            state++;
        }
        else if (currentPad.leftStick.left.isPressed && detect == false)
        {
            Debug.Log("Left");
            detect = true;
            state--;
        }
        if (currentPad.leftStick.ReadValue().x == 0.0f)
        {
            detect = false;
            Debug.Log("Released");
        }

        switch(state)
        {
            case 1:
                selector_types[0].SetActive(true);
                selector_types[1].SetActive(false);
                selector_types[2].SetActive(false);
                selector_types[3].SetActive(false);
                break;
            case 2:
                selector_types[0].SetActive(false);
                selector_types[1].SetActive(true);
                selector_types[2].SetActive(false);
                selector_types[3].SetActive(false);
                break;
            case 3:
                selector_types[0].SetActive(false);
                selector_types[1].SetActive(false);
                selector_types[2].SetActive(true);
                selector_types[3].SetActive(false);
                break;
            case 4:
                selector_types[0].SetActive(false);
                selector_types[1].SetActive(false);
                selector_types[2].SetActive(false);
                selector_types[3].SetActive(true);
                break;         
        }


    }
}
