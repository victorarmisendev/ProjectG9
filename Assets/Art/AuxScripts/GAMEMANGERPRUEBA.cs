using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GAMEMANGERPRUEBA : MonoBehaviour
{
    //public GameObject[] playerTypes;
    private int NumPlayers;
    public Gamepad[] pad;
    Gamepad mando;
    //public List<GameObject> players = new List<GameObject>();
    public GameObject[] types_player;
    public Transform[] salidas;

    private void Start()
    {
        NumPlayers = Gamepad.all.Count;
        pad = Gamepad.all.ToArray();

        for (int i = 0; i < NumPlayers; i++)
        {
            GameObject p = Instantiate(types_player[i], salidas[i].position, types_player[i].transform.rotation);

            p.GetComponent<PlayerControler>().PlayerNum = 1;
            p.GetComponent<PlayerControler>().name = "Player" + p.GetComponent<PlayerControler>().PlayerNum;
            p.GetComponent<PlayerControler>().gamepad_current = pad[i];
        }
    }

}
