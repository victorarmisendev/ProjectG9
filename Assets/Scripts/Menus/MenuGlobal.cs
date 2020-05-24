using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuGlobal : MonoBehaviour
{
    public GameObject[] sections;
    public int state = 1;
    public int stateMenu = 1;
    public Gamepad pad;
    public bool PRESSED_A = false;
    public GameObject cam;
    public Text text, text2;
    private int aux = 3;
    private float timer = 3.5f;


    private void Start()
    {
        pad = Gamepad.all[0]; //El primer jugador lleva el menu.

        //Reset
        //foreach(var s in sections)
        //{
        //    s.SetActive(false);
        //}

        sections[0].SetActive(true);

    }

    void Update()
    {
        //state = Mathf.Clamp(state, 1, 2); // Min y max por las secciones del menu global. 
        stateMenu = Mathf.Clamp(stateMenu, 1, 7);

        InputMovement();

        //ChangeSections(state); //Basic Splash -> mainMenu.

        MainMenu();

        //Debug.Log("The state menu contador is: " + stateMenu);
        //Movements: 

        text.text = "The state menu contador is: " + stateMenu.ToString();

    }

    void InputMovement()
    {
        if (stateMenu < 2)
        {
            if (pad.aButton.wasPressedThisFrame)
            {
                //Cambio de section. 
                stateMenu++;
            }

            if (pad.bButton.wasPressedThisFrame)
            {
                //Cambio de section. 
                stateMenu--;
            }

        }
        else
        {
            if (pad.bButton.wasPressedThisFrame)
            {
                //Cambio de section. 
                stateMenu = 2;
            }
        }

        //if (stateMenu <= 3)
        //{           
        //    if (pad.bButton.wasPressedThisFrame)
        //    {
        //        //Cambio de section. 
        //        stateMenu--;
        //    }
        //}
      
    }

    void JoyStickMainMenu()
    {
        timer -= Time.deltaTime;
        aux = Mathf.Clamp(aux, 3, 7);

        if (stateMenu == 2)
        {
            text2.text = "The menu contador is: " + aux.ToString();
            if (pad.leftStick.up.wasPressedThisFrame)
            {
                //Cambio de section. 
                aux++;
                Debug.Log("HA ENTRADO JOYSTICK IZQUIERDO");
            }

            if (pad.leftStick.down.wasPressedThisFrame)
            {
                //Cambio de section. 
                aux--;
                Debug.Log("HA ENTRADO JOYSTICK IZQUIERDO");
            }
            if (pad.aButton.wasPressedThisFrame && timer <= 0.0f)
            {
                    stateMenu = aux; //Confirmacion de a donde vamos.                
            }
        }
    }

    //void ChangeSections(int state)
    //{
    //    switch(state)
    //    {
    //        case 1:
    //            //Active section one. 
    //            sections[0].SetActive(true);
    //            sections[1].SetActive(false);
    //            sections[2].SetActive(false);
    //            break;
    //        case 2:
    //            sections[0].SetActive(false);
    //            sections[1].SetActive(true);
    //            sections[2].SetActive(false);
    //            break;
    //        //case 3:
    //        //    sections[0].SetActive(false);
    //        //    sections[1].SetActive(false);
    //        //    sections[2].SetActive(true);
    //        //    break;
    //        default: //Nothing for now.
    //            break;
    //    }
    //}
    void MoveTo(int state)
    {

        if (state == 1)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(sections[0].transform.position.x, sections[0].transform.position.y, camera_pos.z), step);
        }

        if (state == 2)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(sections[1].transform.position.x, sections[1].transform.position.y, camera_pos.z), step);
        }

        if (state == 3)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_pos.x, sections[2].transform.position.y, camera_pos.z), step);
        }

        if (state == 4)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(sections[3].transform.position.x, sections[3].transform.position.y, camera_pos.z), step);
        }

        if (state == 5)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(sections[4].transform.position.x, sections[4].transform.position.y, camera_pos.z), step);
        }

        if (state == 6)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(sections[5].transform.position.x, sections[5].transform.position.y, camera_pos.z), step);
        }

        if (state == 7)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(sections[6].transform.position.x, sections[6].transform.position.y, camera_pos.z), step);
        }

    }
    void MainMenu()
    {
        //if (state > 2)
        //{
            //Do the move in the main menu. 
            JoyStickMainMenu();
            //if (pad.aButton.wasPressedThisFrame)
            //{ 
            //} FAIL 
            switch (stateMenu)
            {
                case 1:
                    sections[0].SetActive(true);
                    sections[1].SetActive(false);
                    sections[2].SetActive(false);                       
                    break;
                case 2:
                    sections[0].SetActive(false);
                    sections[1].SetActive(true);
                    sections[2].SetActive(false);
                    Debug.Log("ENTRA EN EL 2");
                    break;
                case 3:
                    //Play: GO TO SELECTION MENU. 
                    //Go to the position.
                    sections[0].SetActive(false);
                    sections[1].SetActive(false);
                    sections[2].SetActive(true);
                    break;
                case 4: // Controls
                    break;
                case 5: // Options 
                    break;
                case 6: // Credits
                    break;
                case 7: // Exit 
                    break;

            }
            if (pad.bButton.wasPressedThisFrame)
            {
                ////Return to splash menu.
                if (stateMenu == 3 || stateMenu == 4 || stateMenu == 5 || stateMenu == 6 || stateMenu == 7)
                {
                    stateMenu = 2;
                    aux = 3;
                    Debug.Log("The state menu contador is: " + stateMenu);
                }



        }


            MoveTo(stateMenu);

        //}
    }




}
