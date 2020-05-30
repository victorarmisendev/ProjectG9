using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stats : MonoBehaviour
{

    public Text lives;
    public Text points;
    public GameObject player;


    void Update()
    {
        lives.text = "Lives: " + player.GetComponent<PlayerRails>().lives.ToString();
        points.text = "Points: " + player.GetComponent<PlayerRails>().points.ToString();
    }


}
