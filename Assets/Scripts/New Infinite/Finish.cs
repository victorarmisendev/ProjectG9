using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Text points;
    public GameObject player;

    void Update()
    {
        points.text = "Points: " + player.GetComponent<PlayerRails>().points.ToString();
    }

}
