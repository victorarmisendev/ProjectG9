using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    GameObject spawner;

    private void Start()
    {

        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "camera")
        {
            
            spawner.gameObject.GetComponent<Procedural>().Instance();
        }
    }
}
