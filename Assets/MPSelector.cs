using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MPSelector : MonoBehaviour
{
    public GameObject InfoTopass;
    private int NumPlayers;
    public Gamepad[] pads;

    public Text texto;
    public Text texto2;
    public Text texto3;
    public Text texto4;

    public int num = 1;
    public int num2 = 1;
    public int num3 = 1;
    public int num4 = 1;

    private bool p1locked = false;
    private bool p2locked = false;
    private bool p3locked = false;
    private bool p4locked = false;

    public GameObject[] player1Car, player2Car, player3Car, player4Car;

    // Start is called before the first frame update
    void Start()
    {
        NumPlayers = Gamepad.all.Count;
        pads = Gamepad.all.ToArray();
        for(int i =0; i<pads.Length;i++)
        {
            switch (i)
            {
                case 0:
                    texto.enabled = true;
                    p2locked = true;
                    p3locked = true;
                    p4locked = true;
                    break;
                case 1:
                    texto2.enabled = true;
                    p2locked = false;
                    p3locked = true;
                    p4locked = true;
                    break;
                case 2:
                    texto3.enabled = true;
                    p3locked = false;
                    p4locked = true;
                    break;
                case 3:
                    texto4.enabled = true;
                    p4locked = false;
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(p1locked && p2locked && p3locked && p4locked)
        {
            GameObject player = (GameObject)Instantiate(InfoTopass, Vector3.zero, Quaternion.identity);
            player.GetComponent<infotoopass_script>().carID[0] = num;
            player.GetComponent<infotoopass_script>().carID[1] = num2;
            player.GetComponent<infotoopass_script>().carID[2] = num3;
            player.GetComponent<infotoopass_script>().carID[3] = num4;
            SceneManager.LoadScene("MultiInfinite");
        }
        //jugador 1
        if (pads.Length > 0)
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
                p1locked = true;
                /**/
            }
            else if (pads[0].bButton.wasPressedThisFrame)
            {
                if (p1locked)
                {
                    p1locked = false;
                }
                else
                {
                    SceneManager.LoadScene("Splash");
                }
            }


            switch (num)
            {
                case 1:
                    for (int i = 0; i < player1Car.Length; i++)
                    {
                        player1Car[i].SetActive(false);
                    }
                    player1Car[0].SetActive(true);
                    break;
                case 2:
                    for (int i = 0; i < player1Car.Length; i++)
                    {
                        player1Car[i].SetActive(false);
                    }
                    player1Car[1].SetActive(true);
                    break;
                case 3:
                    for (int i = 0; i < player1Car.Length; i++)
                    {
                        player1Car[i].SetActive(false);
                    }
                    player1Car[2].SetActive(true);
                    break;
                case 4:
                    for (int i = 0; i < player1Car.Length; i++)
                    {
                        player1Car[i].SetActive(false);
                    }
                    player1Car[3].SetActive(true);
                    break;
                case 5:
                    for (int i = 0; i < player1Car.Length; i++)
                    {
                        player1Car[i].SetActive(false);
                    }
                    player1Car[4].SetActive(true);
                    break;
                case 6:
                    for (int i = 0; i < player1Car.Length; i++)
                    {
                        player1Car[i].SetActive(false);
                    }
                    player1Car[5].SetActive(true);
                    break;
                case 7:
                    for (int i = 0; i < player1Car.Length; i++)
                    {
                        player1Car[i].SetActive(false);
                    }
                    player1Car[6].SetActive(true);
                    break;
            }
        }

        //jugador 2
        if (pads.Length > 1)
        {
            if (pads[1].leftStick.left.wasPressedThisFrame)
            {
                num2--;
                if (num2 < 1)
                {
                    num2 = 7;
                }
                texto2.text = " " + num2;
            }
            else if (pads[1].leftStick.right.wasPressedThisFrame)
            {
                num2++;
                if (num2 > 7)
                {
                    num2 = 1;
                }
                texto2.text = " " + num2;
            }
            else if (pads[1].aButton.wasPressedThisFrame)
            {
                p2locked = true;
                /**/
            }
            else if (pads[1].bButton.wasPressedThisFrame)
            {
                if (p2locked)
                {
                    p2locked = false;
                }
                else
                {
                    SceneManager.LoadScene("Splash");
                }
            }


            switch (num2)
            {
                case 1:
                    for (int i = 0; i < player2Car.Length; i++)
                    {
                        player2Car[i].SetActive(false);
                    }
                    player2Car[0].SetActive(true);
                    break;
                case 2:
                    for (int i = 0; i < player2Car.Length; i++)
                    {
                        player2Car[i].SetActive(false);
                    }
                    player2Car[1].SetActive(true);
                    break;
                case 3:
                    for (int i = 0; i < player2Car.Length; i++)
                    {
                        player2Car[i].SetActive(false);
                    }
                    player2Car[2].SetActive(true);
                    break;
                case 4:
                    for (int i = 0; i < player2Car.Length; i++)
                    {
                        player2Car[i].SetActive(false);
                    }
                    player2Car[3].SetActive(true);
                    break;
                case 5:
                    for (int i = 0; i < player2Car.Length; i++)
                    {
                        player2Car[i].SetActive(false);
                    }
                    player2Car[4].SetActive(true);
                    break;
                case 6:
                    for (int i = 0; i < player2Car.Length; i++)
                    {
                        player2Car[i].SetActive(false);
                    }
                    player2Car[5].SetActive(true);
                    break;
                case 7:
                    for (int i = 0; i < player2Car.Length; i++)
                    {
                        player2Car[i].SetActive(false);
                    }
                    player2Car[6].SetActive(true);
                    break;
            }
        }

        //player 3
        if (pads.Length > 2)
        {
            if (pads[2].leftStick.left.wasPressedThisFrame)
            {
                num3--;
                if (num3 < 1)
                {
                    num3 = 7;
                }
                texto3.text = " " + num3;
            }
            else if (pads[2].leftStick.right.wasPressedThisFrame)
            {
                num3++;
                if (num3 > 7)
                {
                    num3 = 1;
                }
                texto3.text = " " + num3;
            }
            else if (pads[2].aButton.wasPressedThisFrame)
            {
                p3locked = true;
                /**/
            }
            else if (pads[2].bButton.wasPressedThisFrame)
            {
                if (p3locked)
                {
                    p3locked = false;
                }
                else
                {
                    SceneManager.LoadScene("Splash");
                }
            }


            switch (num3)
            {
                case 1:
                    for (int i = 0; i < player3Car.Length; i++)
                    {
                        player3Car[i].SetActive(false);
                    }
                    player3Car[0].SetActive(true);
                    break;
                case 2:
                    for (int i = 0; i < player3Car.Length; i++)
                    {
                        player3Car[i].SetActive(false);
                    }
                    player3Car[1].SetActive(true);
                    break;
                case 3:
                    for (int i = 0; i < player3Car.Length; i++)
                    {
                        player3Car[i].SetActive(false);
                    }
                    player3Car[2].SetActive(true);
                    break;
                case 4:
                    for (int i = 0; i < player3Car.Length; i++)
                    {
                        player3Car[i].SetActive(false);
                    }
                    player3Car[3].SetActive(true);
                    break;
                case 5:
                    for (int i = 0; i < player3Car.Length; i++)
                    {
                        player3Car[i].SetActive(false);
                    }
                    player3Car[4].SetActive(true);
                    break;
                case 6:
                    for (int i = 0; i < player3Car.Length; i++)
                    {
                        player3Car[i].SetActive(false);
                    }
                    player3Car[5].SetActive(true);
                    break;
                case 7:
                    for (int i = 0; i < player3Car.Length; i++)
                    {
                        player3Car[i].SetActive(false);
                    }
                    player3Car[6].SetActive(true);
                    break;
            }
        }

        //player 4
        if (pads.Length > 3)
        {
            if (pads[3].leftStick.left.wasPressedThisFrame)
            {
                num4--;
                if (num4 < 1)
                {
                    num4 = 7;
                }
                texto4.text = " " + num4;
            }
            else if (pads[3].leftStick.right.wasPressedThisFrame)
            {
                num4++;
                if (num4 > 7)
                {
                    num4 = 1;
                }
                texto4.text = " " + num4;
            }
            else if (pads[3].aButton.wasPressedThisFrame)
            {
                p4locked = true;
                /**/
            }
            else if (pads[3].bButton.wasPressedThisFrame)
            {
                if (p4locked)
                {
                    p4locked = false;
                }
                else
                {
                    SceneManager.LoadScene("Splash");
                }
            }


            switch (num4)
            {
                case 1:
                    for (int i = 0; i < player4Car.Length; i++)
                    {
                        player4Car[i].SetActive(false);
                    }
                    player4Car[0].SetActive(true);
                    break;
                case 2:
                    for (int i = 0; i < player4Car.Length; i++)
                    {
                        player4Car[i].SetActive(false);
                    }
                    player4Car[1].SetActive(true);
                    break;
                case 3:
                    for (int i = 0; i < player4Car.Length; i++)
                    {
                        player4Car[i].SetActive(false);
                    }
                    player4Car[2].SetActive(true);
                    break;
                case 4:
                    for (int i = 0; i < player4Car.Length; i++)
                    {
                        player4Car[i].SetActive(false);
                    }
                    player4Car[3].SetActive(true);
                    break;
                case 5:
                    for (int i = 0; i < player4Car.Length; i++)
                    {
                        player4Car[i].SetActive(false);
                    }
                    player4Car[4].SetActive(true);
                    break;
                case 6:
                    for (int i = 0; i < player4Car.Length; i++)
                    {
                        player4Car[i].SetActive(false);
                    }
                    player4Car[5].SetActive(true);
                    break;
                case 7:
                    for (int i = 0; i < player4Car.Length; i++)
                    {
                        player4Car[i].SetActive(false);
                    }
                    player4Car[6].SetActive(true);
                    break;
            }
        }


    }
}
