using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuGlobal : MonoBehaviour
{
    public GameObject[] sections;
    public int state = 1;
    public Gamepad pad;

    private void Start()
    {
        pad = Gamepad.all[0]; //El primer jugador lleva el menu.

        //Reset
        foreach(var s in sections)
        {
            s.SetActive(false);
        }

        sections[0].SetActive(true);

    }

    void Update()
    {
        state = Mathf.Clamp(state, 1, 3); // Min y max por las secciones del menu global. 

        InputMovement();

        ChangeSections(state);

    }

    void InputMovement()
    {
        if (pad.aButton.wasPressedThisFrame)
        {
            //Cambio de section. 
            state++;
        }

        if (pad.bButton.wasPressedThisFrame)
        {
            //Cambio de section. 
            state--;
        }

    }

    void ChangeSections(int state)
    {

        switch(state)
        {
            case 1:
                //Active section one. 
                sections[0].SetActive(true);
                sections[1].SetActive(false);
                sections[2].SetActive(false);
                break;
            case 2:
                sections[0].SetActive(false);
                sections[1].SetActive(true);
                sections[2].SetActive(false);
                break;
            case 3:
                sections[0].SetActive(false);
                sections[1].SetActive(false);
                sections[2].SetActive(true);
                break;
            default: //Nothing for now.
                break;
        }
    }



}
