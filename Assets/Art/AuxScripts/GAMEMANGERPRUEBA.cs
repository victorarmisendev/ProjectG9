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
    public Transform salida;

    private void Start()
    {
        NumPlayers = Gamepad.all.Count;
        pad = Gamepad.all.ToArray();

        mando = pad[0];

        GameObject p = Instantiate(player, salida.position, player.transform.rotation);

        p.GetComponent<PlayerControler>().PlayerNum = 1;
        p.GetComponent<PlayerControler>().name = "None";
        p.GetComponent<PlayerControler>().gamepad_current = mando;
    }

}
