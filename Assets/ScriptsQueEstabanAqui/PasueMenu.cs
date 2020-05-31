using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PasueMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public Text[] text_modes;
    
    public Gamepad[] pad;
    private bool detect = false;
    public GameObject PauseMenuUI;
    public static int state = 0;
    void Start()
    {
        pad = Gamepad.all.ToArray();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused)
        {
            if (pad[0].leftStick.up.isPressed && detect == false)
            {
                Debug.Log("up");
                detect = true;
                state--;
                if (state < 0)
                {
                    state = 0;
                }
            }
            else if (pad[0].leftStick.down.isPressed && detect == false)
            {
                Debug.Log("down");
                detect = true;
                state++;
                if (state > 1)
                {
                    state = 1;
                }
            }
            if (pad[0].leftStick.ReadValue().y == 0.0f)
            {
                detect = false;
                Debug.Log("Released");
            }
            //Feedback:
            if (state == 0)
            {
                text_modes[0].GetComponent<Text>().color = Color.green;
                text_modes[1].GetComponent<Text>().color = Color.grey;
            }
            if (state == 1)
            {
                text_modes[0].GetComponent<Text>().color = Color.grey;
                text_modes[1].GetComponent<Text>().color = Color.green;
            }
            if (pad[0].aButton.isPressed && state == 0)
            {
                Resume();
            }
            else if(pad[0].aButton.isPressed && state == 1)
            {
                SceneManager.LoadScene("MenuPrincipal");
            }
        }
    }
    public void ActivatePause()
    {
        if(gameIsPaused)
        {
            Pause();        
        }
        else
        {
            Resume();
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        //Time.timeScale = 1;
        gameIsPaused = false;
    }
    public void Exit()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
   void Pause()
    {
        PauseMenuUI.SetActive(true);
        //Time.timeScale = 0;
        gameIsPaused = true;
    }
}
