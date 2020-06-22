using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectorManagerSP_script : MonoBehaviour
{
    public GameObject InfoTopass;
    private int NumPlayers;
    public Gamepad[] pads;
    public Text texto;
    public int num=1;
    // Start is called before the first frame update
    void Start()
    {
        NumPlayers = Gamepad.all.Count;
        pads = Gamepad.all.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if(pads[0].leftStick.left.wasPressedThisFrame)
        {
            num--;
            if(num<1)
            {
                num = 7;
            }
            texto.text = " "+ num;
        }
        else if(pads[0].leftStick.right.wasPressedThisFrame)
        {
            num++;
            if (num >7)
            {
                num = 1;
            }
            texto.text = " " + num;
        }
        else if (pads[0].aButton.wasPressedThisFrame)
        {
            GameObject player = (GameObject)Instantiate(InfoTopass, Vector3.zero, Quaternion.identity);
            player.GetComponent<infotoopass_script>().carID[0] = num;
            SceneManager.LoadScene("NewInfinite");
        }
        else if (pads[0].bButton.wasPressedThisFrame)
        {

                SceneManager.LoadScene("Splash");

        }
    }
}
