using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject[] players;
    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Base");
    }
    void Update()
    {
        Vector3 posFrame = new Vector3();
        for (int i = 0; i < players.Length; i++)
        {
            posFrame += players[i].transform.position;
        }
        //Camera
        transform.position = posFrame / players.Length;
    }


}
