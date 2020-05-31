using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class GManager : MonoBehaviour
{ 
    public GameObject[] playerTypes;
    private int NumPlayers;
    public Gamepad[] pads;
    public List<GameObject> players = new List<GameObject>();
    public GameObject EndCanvas;
    public PasueMenu PMenu;
    public string winnerPlayer = "";
    public Text winner;
    public GameObject[] rails;
    public Camera Mycamera;
    public GameObject HUD;
    public Material[] colores;
    void Start()
    {       
        NumPlayers = Gamepad.all.Count;
        pads = Gamepad.all.ToArray();

        Vector3 my = new Vector3(0, 0, 0);
        Debug.Log("Number of gamepads: " + NumPlayers);
        //CharacterSelection a = FindObjectOfType<CharacterSelection>();
        //List<int> Personajes = a.Lista;
        //Create and Spawn players in random position and assign pads. 
        for (int i = 0; i < NumPlayers; i++)
        {
            Debug.Log("YOUR NUMBER IS" +i);
            GameObject player = (GameObject)Instantiate(playerTypes[i], my, Quaternion.identity);
            player.GetComponent<MPPlayerRail>().pad = pads[i];
            player.GetComponent<MPPlayerRail>().rails = rails;
            player.GetComponent<MPPlayerRail>().playerNum = i + 1;
            player.GetComponent<MPPlayerRail>().pauseMenu = PMenu;
            player.GetComponent<MPPlayerRail>().count = i;
            player.GetComponent<MPPlayerRail>().main = Mycamera;
            player.GetComponent<MPPlayerRail>().SetPosition();
            switch (i)
            {
                case 0:
                    HUD.GetComponent<MPStats>().player[i] = player;
                    HUD.GetComponent<MPStats>().T1.SetActive(true);
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial = colores[i];
                    break;
                case 1:
                    HUD.GetComponent<MPStats>().player[i] = player;
                    HUD.GetComponent<MPStats>().T2.SetActive(true);
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial = colores[i];
                    break;
                case 2:
                    HUD.GetComponent<MPStats>().player[i] = player;
                    HUD.GetComponent<MPStats>().T3.SetActive(true);
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial = colores[i];
                    break;
                case 3:
                    HUD.GetComponent<MPStats>().player[i] = player;
                    HUD.GetComponent<MPStats>().T4.SetActive(true);
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial = colores[i];
                    break;
            }
         
        }
    }

    void Update()
    {
        /*if(GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            Time.timeScale = 0;
            EndCanvas.SetActive(true);
            EndCanvas.GetComponent<MPFINISH>().player = FindObjectOfType<MPPlayerRail>();
            HUD.SetActive( false);
        }*/
    }

}
