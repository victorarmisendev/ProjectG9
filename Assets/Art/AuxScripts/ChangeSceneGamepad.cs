using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeSceneGamepad : MonoBehaviour
{
    public Gamepad[] pad;
    private bool pressedOnce = false;
    void Start()
    {
        pad = Gamepad.all.ToArray();
    }

    void Update()
    {
        if(pad[0].aButton.isPressed && pressedOnce == false)
        {
            //Change scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            pressedOnce = true;
        }
    }
}
