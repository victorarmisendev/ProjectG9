using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gragas : MonoBehaviour
{

    public int force;
    public int minimumDistance;
    GameObject[] players;
    

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    

    void explode()
    {
        for (int i = 0; i < players.Length; i++)
        {
            Vector3 distance = gameObject.transform.position - players[i].transform.position;

            if(distance.magnitude < minimumDistance)
            {
                players[i].GetComponent<Rigidbody>().AddForce(distance * force);
            }
        }
    }
}
