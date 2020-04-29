using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class atopass : MonoBehaviour
{
    // Start is called before the first frame update
    public Gamepad[] pads;
    void Start()
    {
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
