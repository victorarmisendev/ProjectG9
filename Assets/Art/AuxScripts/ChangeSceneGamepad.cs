using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeSceneGamepad : MonoBehaviour
{
    public Gamepad[] pad;
    private bool pressedOnce = true;
    public GameObject options;
    void Start()
    {
        pad = Gamepad.all.ToArray();
        
    }

    void Update()
    {
        if(pad[0].aButton.isPressed && pressedOnce == false && MenuVertical.state == 0)
        {
            //Change scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            pressedOnce = true;
        }
        if (pad[0].aButton.isPressed && pressedOnce == false && MenuVertical.state == 1)
        {
            //Change scene.
            options.SetActive(true);
            gameObject.SetActive(false);
            pressedOnce = true;

        }
        if (pad[0].aButton.isPressed && pressedOnce == false && MenuVertical.state == 2)
        {
            //Change scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
            pressedOnce = true;

        }
        if (pad[0].aButton.isPressed && pressedOnce == false && MenuVertical.state == 2)
        {
            //Change scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
            pressedOnce = true;

        }
        if (pad[0].bButton.isPressed)
        {
            Application.Quit();
        }
        Debug.Log(MenuVertical.state);
        if (pressedOnce== true)
        {
            StartCoroutine(InvulCD());
        }
    }
    IEnumerator InvulCD()
    {
        yield return new WaitForSeconds(1);
        pressedOnce = false;
    }
}
