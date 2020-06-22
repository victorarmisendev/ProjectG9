using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActiveMenuPause : MonoBehaviour
{
    public Gamepad pad;
    public GameObject pauseMenu;
    public bool isPaused = false;
    public Text[] text;

    public int state = 0;

    private void Start()
    {
        pad = Gamepad.all[0];
    }
    void Update()
    {
        if(pad.startButton.wasPressedThisFrame)
        {
            Change();
        }

        if(isPaused)
        {

            if (pad.leftStick.up.wasPressedThisFrame)
            {
                state--;
                if (state < 0)
                {
                    state = 0;
                }
            }
            else if (pad.leftStick.down.wasPressedThisFrame)
            {
                state++;
                if (state > 1)
                {
                    state = 1;
                }
            }

            if (state == 0)
            {
                text[0].GetComponent<Text>().color = Color.green;
                text[1].GetComponent<Text>().color = Color.grey;
            }
            if (state == 1)
            {
                text[0].GetComponent<Text>().color = Color.grey;
                text[1].GetComponent<Text>().color = Color.green;
            }

            if (pad.aButton.wasPressedThisFrame && state == 0)
            {
                Change();
            }

            Time.timeScale = 0;

            if (pad.aButton.wasPressedThisFrame && state == 1)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Splash");
            }

            



        } 
        else
        {
            Time.timeScale = 1;
        }
      
    }

    void Change()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
    }

}
