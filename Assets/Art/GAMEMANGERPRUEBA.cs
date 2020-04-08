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
    public GameObject player;

    private void Start()
    {
        NumPlayers = Gamepad.all.Count;
        pad = Gamepad.all.ToArray();

        mando = pad[0];

        player.GetComponent<PlayerControler>().PlayerNum = 1;
        player.GetComponent<PlayerControler>().name = "None";
        player.GetComponent<PlayerControler>().gamepad_current = mando;
    }

}
