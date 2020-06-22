using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArenaManager_script : MonoBehaviour
{
    public GameObject InfoTopass;
    private int NumPlayers;
    public Gamepad[] pads;
    public Text texto;
    public int num = 1;
    public GameObject[] artCars;
    public bool SP = false, Arena = false;
    // Start is called before the first frame update
    void Start()
    {
        NumPlayers = Gamepad.all.Count;
        pads = Gamepad.all.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (pads[0].leftStick.left.wasPressedThisFrame)
        {
            num--;
            if (num < 1)
            {
                num = 7;
            }
            texto.text = " " + num;
        }
        else if (pads[0].leftStick.right.wasPressedThisFrame)
        {
            num++;
            if (num > 7)
            {
                num = 1;
            }
            texto.text = " " + num;
        }
        else if (pads[0].aButton.wasPressedThisFrame)
        {
            GameObject player = (GameObject)Instantiate(InfoTopass, Vector3.zero, Quaternion.identity);
            player.GetComponent<infotoopass_script>().carID[0] = num;
            if(SP && Arena == false)
                SceneManager.LoadScene("NewInfinite");
            if (SP == false && Arena)
                SceneManager.LoadScene("Arena");
        }
        else if (pads[0].bButton.wasPressedThisFrame)
        {

                SceneManager.LoadScene("Splash");
        }

        switch(num)
        {
            case 1:
                for (int i = 0; i < artCars.Length; i++)
                {
                    artCars[i].SetActive(false);
                }
                artCars[0].SetActive(true);
                break;
            case 2:
                for (int i = 0; i < artCars.Length; i++)
                {
                    artCars[i].SetActive(false);
                }
                artCars[1].SetActive(true);
                break;
            case 3:
                for (int i = 0; i < artCars.Length; i++)
                {
                    artCars[i].SetActive(false);
                }
                artCars[2].SetActive(true);
                break;
            case 4:
                for (int i = 0; i < artCars.Length; i++)
                {
                    artCars[i].SetActive(false);
                }
                artCars[3].SetActive(true);
                break;
            case 5:
                for (int i = 0; i < artCars.Length; i++)
                {
                    artCars[i].SetActive(false);
                }
                artCars[4].SetActive(true);
                break;
            case 6:
                for (int i = 0; i < artCars.Length; i++)
                {
                    artCars[i].SetActive(false);
                }
                artCars[5].SetActive(true);
                break;
            case 7:
                for (int i = 0; i < artCars.Length; i++)
                {
                    artCars[i].SetActive(false);
                }
                artCars[6].SetActive(true);
                break;
        }

    }
}
