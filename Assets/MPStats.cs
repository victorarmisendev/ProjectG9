using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPStats : MonoBehaviour
{

    public GameObject T1;
    public GameObject T2;
    public GameObject T3;
    public GameObject T4;
    public GameObject[] player;


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i] != null)
            {
                T1.transform.GetChild(0).GetComponent<Text>().text = "Lives: " + player[i].GetComponent<MPPlayerRail>().lives;
                T1.transform.GetChild(1).GetComponent<Text>().text = "Points: " + player[i].GetComponent<MPPlayerRail>().points;
            }
        }
    }
}
