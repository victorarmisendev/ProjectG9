using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;

    void start()
    {
        InvokeRepeating("spawnPowerUp", 10.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnPowerUP()
    {
        int choose = Random.Range(0,2);
        Instantiate(powerUps[choose], new Vector3(Random.Range(-20.0f, 20.0f), 0.5f, Random.Range(-15.0f, 15.0f)), new Quaternion(1,1,1,1));
    }
}
