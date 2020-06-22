using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        GameObject info = GameObject.FindGameObjectWithTag("BScenes");
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
            GameObject player = (GameObject)Instantiate(playerTypes[info.GetComponent<infotoopass_script>().carID[i] - 1], my, Quaternion.identity);
            player.GetComponent<MPPlayerRail>().pad = pads[i];
            player.GetComponent<MPPlayerRail>().rails = rails;
            player.GetComponent<MPPlayerRail>().playerNum = i + 1;
            player.GetComponent<MPPlayerRail>().pauseMenu = PMenu;
            player.GetComponent<MPPlayerRail>().main = Mycamera;
            player.GetComponent<MPPlayerRail>().CarID = info.GetComponent<infotoopass_script>().carID[i] - 1;
            switch (i)
            {
                case 0:
                    player.GetComponent<MPPlayerRail>().count = i;
                    player.GetComponent<MPPlayerRail>().SetPosition();
                  
                    HUD.GetComponent<MPStats>().player[i] = player;
                    HUD.GetComponent<MPStats>().T1.SetActive(true);
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial = colores[i];
                    break;
                case 1:
                    player.GetComponent<MPPlayerRail>().count = i;
                    player.GetComponent<MPPlayerRail>().SetPosition();
                    HUD.GetComponent<MPStats>().player[i] = player;
                    HUD.GetComponent<MPStats>().T2.SetActive(true);
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial = colores[i];
                    break;
                case 2:
                    player.GetComponent<MPPlayerRail>().count = 4;
                    player.GetComponent<MPPlayerRail>().SetPosition();
                    HUD.GetComponent<MPStats>().player[i] = player;
                    HUD.GetComponent<MPStats>().T3.SetActive(true);
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial = colores[i];
                    break;
                case 3:
                    player.GetComponent<MPPlayerRail>().count = 5;
                    player.GetComponent<MPPlayerRail>().SetPosition();
                    HUD.GetComponent<MPStats>().player[i] = player;
                    HUD.GetComponent<MPStats>().T4.SetActive(true);
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                    player.transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial = colores[i];
                    break;
            }
         
        }
        Destroy(GameObject.FindGameObjectWithTag("BScenes"));
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            Time.timeScale = 0;
            GameObject Record = GameObject.FindGameObjectWithTag("Save");
            Record.GetComponent<inGameRecord>().newAScore = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<MPPlayerRail>().points;
            Record.GetComponent<inGameRecord>().CARID = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<MPPlayerRail>().CarID;
            Record.GetComponent<inGameRecord>().Gamemode = 3;
            Record.GetComponent<inGameRecord>().PlayerID = 1;
            SceneManager.LoadScene("End");
        }
    }

}
