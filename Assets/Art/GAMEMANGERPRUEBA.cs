using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANGERPRUEBA : MonoBehaviour
{


     //Create and Spawn players in random position and assign pads. 
        for (int i = 0; i<NumPlayers; i++)
        {
            GameObject player = (GameObject)Instantiate(playerTypes[Random.Range(0, playerTypes.Length)], PosCar(i), Quaternion.identity);

            player.GetComponent<PlayerControler>().gamepad_current = pads[i];
            player.GetComponent<PlayerControler>().PlayerNum = i + 1;
            player.GetComponent<PlayerControler>().CameraKill = CameraKill;
            player.GetComponent<PlayerControler>().respawnX = i;
        }

}
