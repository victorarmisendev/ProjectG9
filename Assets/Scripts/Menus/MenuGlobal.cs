using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuGlobal : MonoBehaviour
{
    public GameObject[] sections;
    public int state = 1;
    public int stateMenu = 1;
    public Gamepad pad;

    public GameObject cam;
    public Text text, text2;
    private int aux = 3, aux2 = 1;
    private float timer = 3.5f;
    private bool activeTimer = false;
    public TextMeshProUGUI[] textosMenu;

    public Transform[] camera_positions;

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
        //if (stateMenu < 2)
        //{
        //    if (pad.aButton.wasPressedThisFrame)
        //    {
        //        //Cambio de section. 
        //        stateMenu++;
        //    }
        //    //if (pad.bButton.wasPressedThisFrame)
        //    //{
        //    //    //Cambio de section. 
        //    //    stateMenu--;
        //    //}
        //}
        //else
        //{
        //    //if (pad.bButton.wasPressedThisFrame)
        //    //{
        //    //    //Cambio de section. 
        //    //    stateMenu = 2;
        //    //}
        //}
      
    }

    void MoveTo(int state)
    {

        if (state == 1)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[0].position.x, camera_positions[0].position.y, camera_pos.z), step);
        }

        if (state == 2)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[1].position.x, camera_positions[1].position.y, camera_pos.z), step);
        }

        if (state == 3)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[2].position.x, camera_positions[2].position.y, camera_pos.z), step);
        }

        if (state == 4)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[3].position.x, camera_positions[3].position.y, camera_pos.z), step);
        }

        if (state == 5)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[4].position.x, camera_positions[4].position.y, camera_pos.z), step);
        }

        if (state == 6)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[5].position.x, camera_positions[5].position.y, camera_pos.z), step);
        }

        if (state == 7)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[6].position.x, camera_positions[6].position.y, camera_pos.z), step);
        }

    }
    void MainMenu()
    {
        switch (stateMenu)
        {
            case 1:
                //sections[0].SetActive(true);
                //sections[1].SetActive(false);
                //sections[2].SetActive(false);
                if (pad.aButton.wasPressedThisFrame)
                {
                    //Cambio de section. 
                    stateMenu = 2;
                }
                break;
            case 2:
                //sections[0].SetActive(false);
                //sections[1].SetActive(true);
                //sections[2].SetActive(false);
            text2.text = "The menu contador is: " + aux.ToString();
            if (pad.leftStick.up.wasPressedThisFrame)
                aux--;
            if (pad.leftStick.down.wasPressedThisFrame)
                aux++;
            if (pad.aButton.wasPressedThisFrame)
                stateMenu = aux; //Confirmacion de a donde vamos.      
            if (pad.bButton.wasPressedThisFrame)
                stateMenu = 1;

            aux = Mathf.Clamp(aux, 3, 7);

            switch (aux)
            {
                case 3:
                    foreach(var b in textosMenu)
                    {
                        b.color = Color.white;
                    }
                    textosMenu[0].color = Color.green;
                    break;
                case 4:
                    foreach (var b in textosMenu)
                    {
                        b.color = Color.white;
                    }
                    textosMenu[1].color = Color.green;
                    break;
                case 5:
                    foreach (var b in textosMenu)
                    {
                        b.color = Color.white;
                    }
                    textosMenu[2].color = Color.green;
                    break;
                case 6:
                    foreach (var b in textosMenu)
                    {
                        b.color = Color.white;
                    }
                    textosMenu[3].color = Color.green;
                    break;
                case 7:
                    foreach (var b in textosMenu)
                    {
                        b.color = Color.white;
                    }
                    textosMenu[4].color = Color.green;
                    break;
            }


                break;
            case 3:
                // Play: GO TO SELECTION MENU. 
                // Go to the position.
                //sections[0].SetActive(false);
                //sections[1].SetActive(false);
                //sections[2].SetActive(true);
                aux2 = Mathf.Clamp(aux2, 1, 3);
                if (pad.leftStick.right.wasPressedThisFrame)
                    aux2++;
                if (pad.leftStick.left.wasPressedThisFrame)
                    aux2--;
                if (pad.aButton.wasPressedThisFrame)
                {
                    //stateMenu = aux; //Confirmacion de a donde vamos. 
                    //Change scene to mode selected. 
                    switch(aux2)
                    {
                        case 1:
                            //Change: 
                            //SceneManager.LoadScene("Runner");
                            break;
                        case 2:
                            //Change: 
                            //SceneManager.LoadScene("Arena");
                            break;
                        case 3:
                            //Change: 
                            //SceneManager.LoadScene("Tutorial");
                            break;
                    }
                }
                if (pad.bButton.wasPressedThisFrame)
                stateMenu = 2;
                break;

            case 4: // Controls
                if (pad.bButton.wasPressedThisFrame)
                    stateMenu = 2;
                break;

            case 5: // Options: Put the controls to modify the menu. 
                //Change the buttons, volume and graphics by input. 
                if (pad.bButton.wasPressedThisFrame)
                    stateMenu = 2;
                break;

            case 6: // Credits
                if (pad.bButton.wasPressedThisFrame)
                    stateMenu = 2;
                break;

            case 7: // Exit 
                if (pad.bButton.wasPressedThisFrame)
                    stateMenu = 2;
                break;
        }
            MoveTo(stateMenu);
    }




}
