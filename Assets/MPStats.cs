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
                if (player[i].GetComponent<MPPlayerRail>())
                {
                    if (i == 0)
                    {
                        T1.transform.GetChild(0).GetComponent<Text>().text = "Lives: " + player[i].GetComponent<MPPlayerRail>().lives;
                        T1.transform.GetChild(1).GetComponent<Text>().text = "Points: " + player[i].GetComponent<MPPlayerRail>().points;
                    }
                    if(i==1)
                    {
                        T2.transform.GetChild(0).GetComponent<Text>().text = "Lives: " + player[i].GetComponent<MPPlayerRail>().lives;
                        T2.transform.GetChild(1).GetComponent<Text>().text = "Points: " + player[i].GetComponent<MPPlayerRail>().points;
                    }
                    if(i==2)
                    {
                        T3.transform.GetChild(0).GetComponent<Text>().text = "Lives: " + player[i].GetComponent<MPPlayerRail>().lives;
                        T3.transform.GetChild(1).GetComponent<Text>().text = "Points: " + player[i].GetComponent<MPPlayerRail>().points;
                    }
                else if (player[i].GetComponent<PlayerArena>())
                {
                    T1.transform.GetChild(0).GetComponent<Text>().text = "Lives: " + player[i].GetComponent<PlayerArena>().lives;
                    T1.transform.GetChild(1).GetComponent<Text>().text = "Points: " + player[i].GetComponent<PlayerArena>().score;
                }
            }
        }
    }
}
