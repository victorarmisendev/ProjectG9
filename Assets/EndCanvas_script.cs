using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class EndCanvas_script : MonoBehaviour
{
    public Gamepad[] pads;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        pads = Gamepad.all.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (pads[0].aButton.isPressed)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
