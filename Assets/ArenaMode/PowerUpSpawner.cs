using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 8.0f, 8.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPowerUp()
    {
        int choose = Random.Range(0,2);
        Instantiate(powerUps[choose], new Vector3(Random.Range(-20.0f, 20.0f), 2.0f, Random.Range(-15.0f, 15.0f)), new Quaternion(0,3.1416f,0,1));
        print("spawned");
    }
}
