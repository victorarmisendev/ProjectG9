using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class atopass : MonoBehaviour
{
    // Start is called before the first frame update
    public Gamepad[] pads;
    bool press = true;
    void Start()
    {
        pads = Gamepad.all.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (pads[0].aButton.isPressed && !press)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
   /* IEnumerator stun(float s)
    {
        yield return new WaitForSeconds(3);//VER COMO HACER SIN HARDCODE
        SceneManager.LoadScene("MenuPrincipal");
    }*/
}
