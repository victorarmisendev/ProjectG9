using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RockAttFloor : MonoBehaviour
{
    private bool onFloor = false;
    public GameObject boulder;
    public GameObject particle;
    private float speed;

    public AudioSource explosion;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerArena")
        {
            other.gameObject.GetComponentInParent<PlayerArena>().Respwan();
            if (other.gameObject.GetComponentInParent<PlayerArena>())
            {
                Debug.Log("HEY");
            }
            Destroy(boulder.gameObject);
            explosion.Play();
            particle.SetActive(true);
        }
        else if(other.gameObject.tag == "field")
        {
            onFloor = true;
        }
        else if (other.gameObject.tag == "Cliff")
        {
            Destroy(boulder.gameObject);
            explosion.Play();
            particle.SetActive(true);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.05f, 0.09f);
    }

    // Update is called once per frame
    void Update()
    {
        if (onFloor == true)
        {
            transform.position += new Vector3(0, 0, -speed);
            transform.Rotate (-1.0f, 0.0f, 0.0f, Space.Self);
        }
    }
}
