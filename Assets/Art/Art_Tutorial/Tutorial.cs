using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    //public GameObject[] playerTypes;
    private int NumPlayers;
    public Gamepad pad;
    private Gamepad [] allpads;
    Gamepad mando;
    
    public GameObject player;
    public Transform salida;

    private void Start()
    {
        NumPlayers = Gamepad.all.Count;
        allpads = Gamepad.all.ToArray();
        pad = allpads[0];


        GameObject p = Instantiate(player, salida.position, player.transform.rotation);

        /* p.GetComponent<PlayerControler>().PlayerNum = 1;*/ //NONE
        //p.GetComponent<PlayerControler>().name = "Player" + p.GetComponent<PlayerControler>().PlayerNum;
        //p.GetComponent<PlayerControler>().gamepad_current = pad;
        
    }
}
