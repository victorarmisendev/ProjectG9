﻿using System.Collections;
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
    private int aux = 3, aux2 = 1, aux3Controles = 1, aux4Options = 1;
    private float timer = 3.5f;
    private bool activeTimer = false;
    public TextMeshProUGUI[] textosMenu;
    //public GameObject[] carteles;

    public GameObject indicatorPlay;

    public Transform[] camera_positions, selectorPosition;
    float actualRotY = 0.0f;

    public GameObject infiniteControls, arenaControls;

    public TextMeshProUGUI[] options;
    public TextMeshProUGUI modeControls;
    public int resolution = 1;
    public int graphics = 1;
    public int volume = 1;

    public AudioSource AS;
    public AudioSource ClickA, ClickB, MoveJoystick;
    public AudioSource music;

    public bool FULL = false;


    private void Start()
    {
        pad = Gamepad.all[0]; //El primer jugador lleva el menu.
        //actualRotY = controlsCartel.transform.eulerAngles.y;
        //Reset
        //foreach(var s in sections)
        //{
        //    s.SetActive(false);
        //}
        music.Play();

        sections[0].SetActive(true);

        options[2].text = "Volume: 1";
        options[1].text = "Graphics: Ultra";
        options[3].text = "Fullscreen: ON";

        //ClickA = GetComponent<AudioSource>();
        //ClickB = GetComponent<AudioSource>();
        
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
                new Vector3(camera_positions[0].position.x, camera_positions[0].position.y, camera_positions[0].position.z), step);
        }

        if (state == 2)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[1].position.x, camera_positions[1].position.y, camera_positions[1].position.z), step);
        }

        if (state == 3)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[2].position.x, camera_positions[2].position.y, camera_positions[2].position.z), step);
        }

        if (state == 4)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[3].position.x, camera_positions[3].position.y, camera_positions[3].position.z), step);
        }

        if (state == 5)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[4].position.x, camera_positions[4].position.y, camera_positions[4].position.z), step);
        }

        if (state == 6)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[5].position.x, camera_positions[5].position.y, camera_positions[5].position.z), step);
        }

        if (state == 7)
        {
            float step = 1.5f * Time.deltaTime;
            Vector3 camera_pos = cam.transform.position;

            cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(camera_positions[6].position.x, camera_positions[6].position.y, camera_positions[6].position.z), step);
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
                    ClickA.Play();
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
                {
     stateMenu = aux; //Confirmacion de a donde vamos.  
                    ClickA.Play();
                }
               
            if (pad.bButton.wasPressedThisFrame)
                {
                    ClickB.Play();
                    stateMenu = 1;
                }
                

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
                aux2 = Mathf.Clamp(aux2, 1, 4);
                if (pad.leftStick.right.wasPressedThisFrame)
                    aux2++;
                if (pad.leftStick.left.wasPressedThisFrame)
                    aux2--;
                if(aux2 == 1)
                    indicatorPlay.transform.position = selectorPosition[0].position;
                if(aux2 == 2)
                    indicatorPlay.transform.position = selectorPosition[1].position;
                if (aux2 == 3)
                    indicatorPlay.transform.position = selectorPosition[2].position;
                if (aux2 == 4)
                    indicatorPlay.transform.position = selectorPosition[3].position;
                if (pad.aButton.wasPressedThisFrame)
                {
                    //stateMenu = aux; //Confirmacion de a donde vamos. 
                    //Change scene to mode selected. 
                    Color metal = new Color(204, 169, 90);
                    ClickA.Play();
                    switch (aux2)
                    {
                        case 1:
                            //Change: 
                            SceneManager.LoadScene("SPSelector"); //Solo 
                            break;
                        case 2:
                            SceneManager.LoadScene("MPSelector"); // Multi
                            break;
                        case 3:
                            //Change: 
                            SceneManager.LoadScene("ArenaSelector"); //Arena 
                            break;
                        case 4:
                            //Change: 
                            SceneManager.LoadScene("Tutorial"); //Tutorial
                            break;
                    }
                }
                if (pad.bButton.wasPressedThisFrame)
                {
                    ClickB.Play();
                    stateMenu = 2;
                }
                
                break;

            case 4: // Controls

                aux3Controles = Mathf.Clamp(aux3Controles, 1, 2);
                if (pad.leftStick.right.wasPressedThisFrame)
                    aux3Controles++;
                if (pad.leftStick.left.wasPressedThisFrame)
                    aux3Controles--;
                if (aux3Controles == 1)
                {
                    infiniteControls.SetActive(true);
                    arenaControls.SetActive(false);
                    modeControls.text = "Infinite";
                }
                if (aux3Controles == 2)
                {
                    infiniteControls.SetActive(false);
                    arenaControls.SetActive(true);
                    modeControls.text = "Arena";
                }

                if (pad.bButton.wasPressedThisFrame)
                {
                    ClickB.Play();
                    stateMenu = 2;
                }
                
                break;

            case 5: // Options: Put the controls to modify the menu. 
                    //Change the buttons, volume and graphics by input. 
                aux4Options = Mathf.Clamp(aux4Options, 1, 4);
                if (pad.leftStick.down.wasPressedThisFrame)
                    aux4Options++;
                if (pad.leftStick.up.wasPressedThisFrame)
                    aux4Options--;



                switch(aux4Options)
                {
                    case 1:
                        //Resolution

                        foreach (var b in options)
                        {
                            b.color = Color.white;
                        }
                        options[0].color = Color.green;

                        resolution = Mathf.Clamp(resolution, 1, 4);

                        if (pad.aButton.wasPressedThisFrame)
                        {
                            resolution++;
                            ClickA.Play();
                            if (resolution > 4)
                                resolution = 1;
                        }


                        switch (resolution)
                        {
                            case 1:
                                SetResolution(1920, 1080);
                                options[0].text = "Resolution: 1920 x 1080";
                                break;
                            case 2:
                                SetResolution(1280, 1024);
                                options[0].text = "Resolution: 1280 x 1024";
                                break;
                            case 3:
                                SetResolution(1280, 720);
                                options[0].text = "Resolution: 1280 x 720";
                                break;
                            case 4:
                                SetResolution(800, 640);
                                options[0].text = "Resolution: 800 x 640";
                                break;
                        }
        
                        break;
                    case 2:


                        foreach (var b in options)
                        {
                            b.color = Color.white;
                        }
                        options[1].color = Color.green;


                        graphics = Mathf.Clamp(graphics, 1, 4);

                        if (pad.aButton.wasPressedThisFrame)
                        {
                            graphics++;
                            ClickA.Play();
                            if (graphics > 4)
                                graphics = 1;
                        }


                        switch (graphics)
                        {
                            case 1:

                                options[1].text = "Graphics: Ultra";
                                SetQuality(1);
                                break;
                            case 2:
    
                                options[1].text = "Graphics: High";
                                SetQuality(2);
                                break;
                            case 3:
 
                                options[1].text = "Graphics: Medium";
                                SetQuality(3);
                                break;
                            case 4:

                                options[1].text = "Graphics: Low";
                                SetQuality(4);
                                break;
                        }



                        //Graphics
                        break;
                    case 3:

                        foreach (var b in options)
                        {
                            b.color = Color.white;
                        }
                        options[2].color = Color.green;


                        volume = Mathf.Clamp(volume, 1, 4);

                        if (pad.aButton.wasPressedThisFrame)
                        {
                            volume++;
                            ClickA.Play();
                            if (volume > 4)
                                volume = 1;
                        }


                        //switch (volume)
                        //{
                        //    case 1:

                        //        options[2].text = "Volume: 1";
                        //        SetVolum(1.25f);
                        //        break;
                        //    case 2:
                        //        options[2].text = "Volume: 1";
                        //        SetVolum(1.5f);
                        //        break;
                        //    case 3:
                        //        options[2].text = "Volume: 3";
                        //        SetVolum(1.75f);
                        //        break;
                        //    case 4:
                        //        SetVolum(1.0f);
                        //        options[2].text = "Volume: 4";
   
                        //        break;
                        //}

                        //Volume
                        break;
                    case 4:
                        foreach (var b in options)
                        {
                            b.color = Color.white;
                        }
                        options[3].color = Color.green;

                        if(FULL)
                        {
                            options[3].text = "Fullscreen: ON";
                        } 
                        else
                        {
                            options[3].text = "Fullscreen: OFF";
                        }
                      
                        if (pad.aButton.wasPressedThisFrame)
                        {
                            FULL = !FULL;
                            ClickA.Play();
                            Screen.fullScreen = FULL;
                        }
        
                        //Fullscreen
                        break;
                }


                if (pad.bButton.wasPressedThisFrame)
                {
                    ClickB.Play();
                    stateMenu = 2;
                }
                   
                break;

            case 6: // Credits
                if (pad.bButton.wasPressedThisFrame)
                {
                    ClickB.Play();stateMenu = 2;
                }
                    
                break;

            case 7: // Exit 
                if (pad.bButton.wasPressedThisFrame)
                {
 stateMenu = 2; ClickB.Play();
                }
                   
                if (pad.aButton.wasPressedThisFrame)
                {
                    ClickA.Play();
                    Application.Quit();
                }
                    
                break;
        }
            MoveTo(stateMenu);
    }


    public void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void SetVolum(float volum)
    {
        AS.volume = volum / 10;
    }

}
