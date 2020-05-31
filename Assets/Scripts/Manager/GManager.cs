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
           /*switch (i)
            {
                case 0:
                    Transform HUDplayer = afg.transform.GetChild(i);
                    HUDplayer.gameObject.SetActive(true);
                    for(int j=0;j < HUDplayer.childCount;j++)
                    {
                        switch(j)
                        {
                            case 0:
                                HUDplayer.GetChild(j).GetComponent<Text>().text = "Lives " + player.GetComponent<PlayerControler>().Lives;
                                player.GetComponent<PlayerControler>().canvas = HUDplayer.GetChild(j).GetComponent<Text>();
                                break;
                            case 1:
                                player.transform.GetComponent<MovementShoot>().bar=HUDplayer.GetChild(j).GetComponent<GunBar>();
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                /*case 1:
                    Transform HUDplayer2 = afg.transform.GetChild(i);
                    HUDplayer2.gameObject.SetActive(true);
                    for (int j = 0; j < HUDplayer2.childCount; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                HUDplayer2.GetChild(j).GetComponent<Text>().text = "Lives " + player.GetComponent<PlayerControler>().Lives;
                                player.GetComponent<PlayerControler>().canvas = HUDplayer2.GetChild(j).GetComponent<Text>();
                                break;
                            case 1:
                                player.transform.GetComponent<MovementShoot>().bar = HUDplayer2.GetChild(j).GetComponent<GunBar>();
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case 2:
                    Transform HUDplayer3 = afg.transform.GetChild(i);
                    HUDplayer3.gameObject.SetActive(true);
                    for (int j = 0; j < HUDplayer3.childCount; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                HUDplayer3.GetChild(j).GetComponent<Text>().text = "Lives " + player.GetComponent<PlayerControler>().Lives;
                                player.GetComponent<PlayerControler>().canvas = HUDplayer3.GetChild(j).GetComponent<Text>();
                                break;
                            case 1:
                                player.transform.GetComponent<MovementShoot>().bar = HUDplayer3.GetChild(j).GetComponent<GunBar>();
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case 3:
                    Transform HUDplayer4 = afg.transform.GetChild(i);
                    HUDplayer4.gameObject.SetActive(true);
                    for (int j = 0; j < HUDplayer4.childCount; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                HUDplayer4.GetChild(j).GetComponent<Text>().text = "Lives " + player.GetComponent<PlayerControler>().Lives;
                                player.GetComponent<PlayerControler>().canvas = HUDplayer4.GetChild(j).GetComponent<Text>();
                                break;
                            case 1:
                                player.transform.GetComponent<MovementShoot>().bar = HUDplayer4.GetChild(j).GetComponent<GunBar>();
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

            if(player.GetComponentsInChildren<MovementShoot>()!=null)
            {
                
            }
            players.Add(player); //Usamos esta lista para dibujar el nombre, imagen y vidas de los jugadores. */
        }
        


    }

    void Update()
    {
        /*if(GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            EndCanvas.SetActive(true);
            string name = GameObject.FindGameObjectWithTag("Player").gameObject.name;
            string name2 = "";
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == '(')
                    break;
                name2 += name[i];
            }
            winner.text = name2;
            //SceneManager.LoadScene("MenuPrincipal");
        }*/
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
