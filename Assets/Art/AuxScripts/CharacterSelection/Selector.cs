using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Selector : MonoBehaviour
{

    public Gamepad currentPad;
    private float state = 1;
    private bool detect = false;
    public GameObject[] selector_types;
    public TextMeshPro ready;
    public bool READY_CONFIRM = false;
    public Color[] colors;

    void Start()
    {
        colors = new Color[2];
        colors[0] = Color.grey;
        colors[1] = Color.green;

        ready.color = colors[0];

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
        //Confirm player selection: 
        if (currentPad.aButton.isPressed)
        {
            //feedback color. 
            if (ready.color == colors[0])
                ready.color = colors[1];
            if (ready.color == colors[1])
                ready.color = colors[0];

            //Invert confirmation: 
            READY_CONFIRM = !READY_CONFIRM;
        }

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
