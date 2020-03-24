using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GManager : MonoBehaviour
{
    public GameObject[] playerTypes;
    private int NumPlayers;
    public Gamepad[] pads;

    Vector3 RandomPosCar()
    {
        //Cambiar valores segun la pista. 
        return new Vector3(1, 10.0f, Random.Range(-15, 15));
    }

    void Start()
    {

        NumPlayers = Gamepad.all.Count;
        pads = Gamepad.all.ToArray();

        Debug.Log("Number of gamepads: " + NumPlayers);

        //Spawn players in random position and assign pads. 
        for (int i = 0; i < NumPlayers; i++)
        {
            GameObject player = Instantiate(playerTypes[Random.Range(0, playerTypes.Length)], RandomPosCar(), Quaternion.identity);
            player.GetComponent<PlayerControler>().gamepad_current = pads[i];
            player.GetComponent<PlayerControler>().PlayerNum = i + 1;
        }
    }

    void Update()
    {
        
    }
}
