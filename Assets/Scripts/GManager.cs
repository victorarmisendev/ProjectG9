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
    public GameObject Canvas;
    public GameObject CameraKill;
    public PasueMenu PMenu;
    Vector3 RandomPosCar()
    {
        //Cambiar valores segun la pista. 
        return new Vector3(1, 15.0f, Random.Range(-15, 15));
    }
    Vector3 PosCar(int i)
    {
        float x=0;
        switch(i)
        {
            case 0:
                x = -12;
                break;
            case 1:
                x = -2;
                break;
            case 2:
                x = 2;
                break;
            case 3:
                x = 12;
                break;
            default:
                break;
        }
        return new Vector3(x,1, CameraKill.transform.position.z + 80);

    }
    void Start()
    {       
        NumPlayers = Gamepad.all.Count;
        pads = Gamepad.all.ToArray();

        Vector3 my = new Vector3(0, 0, 0);
        GameObject afg = (GameObject)Instantiate(Canvas, my , Quaternion.identity);
        Debug.Log("Number of gamepads: " + NumPlayers);
        CharacterSelection a = FindObjectOfType<CharacterSelection>();
        List<int> Personajes = a.Lista;
        //Create and Spawn players in random position and assign pads. 
        for (int i = 0; i < NumPlayers; i++)
        {
            Debug.Log("YOUR NUMBER IS" +Personajes[i]);
            GameObject player = (GameObject)Instantiate(playerTypes[Personajes[i]], PosCar(i), Quaternion.identity);
     
            player.GetComponent<PlayerControler>().gamepad_current = pads[i];
            player.GetComponent<PlayerControler>().PlayerNum = i + 1;
            player.GetComponent<PlayerControler>().CameraKill = CameraKill;
            player.GetComponent<PlayerControler>().respawnX = i;
            player.GetComponent<PlayerControler>().pause = PMenu;
            switch (i)
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
                case 1:
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
            players.Add(player); //Usamos esta lista para dibujar el nombre, imagen y vidas de los jugadores. 
        }



    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            //SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
