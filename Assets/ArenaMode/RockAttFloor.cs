using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RockAttFloor : MonoBehaviour
{
    private bool onFloor = false;
    public GameObject boulder;
    public GameObject particle;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerArena")
        {
            Destroy(other.gameObject);
            Destroy(boulder.gameObject);
            particle.SetActive(true);
        }
        else if(other.gameObject.tag == "field")
        {
            print("Floooooor");
            onFloor = true;
        }
        else if (other.gameObject.tag == "Cliff")
        {
            Destroy(boulder.gameObject);
            particle.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onFloor == true)
        {
            transform.position += new Vector3(0, 0, -0.045f);
            transform.Rotate (-1.0f, 0.0f, 0.0f, Space.Self);
        }
    }
}
