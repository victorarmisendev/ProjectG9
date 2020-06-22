using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAtt : MonoBehaviour
{
    public GameObject[] elements1;
    public GameObject particles;
    public GameObject floorMark;

    public AudioSource explosion;

    private void Start()
    {
        Invoke("destroyMark", 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        particles.SetActive(true);
        explosion.Play();
        if (other.gameObject.tag == "PlayerArena")
        {
            if (!other.gameObject.GetComponent<PlayerArena>().shield)
            {
                other.gameObject.GetComponentInParent<PlayerArena>().Respwan();
            }
            else if(other.gameObject.GetComponent<PlayerArena>().shield)
            {
                other.gameObject.GetComponent<PlayerArena>().shield = false;
            }
            for (int i = 0; i < elements1.Length; i++)
            {
                Destroy(elements1[i]);
            }
        }
        else if(other.gameObject.tag == "field")
        {
            for (int i = 0; i < elements1.Length; i++)
            {
                Destroy(elements1[i]);
            }
        }
        else if (other.gameObject.tag == "Cliff")
        {
            for (int i = 0; i < elements1.Length; i++)
            {
                Destroy(elements1[i]);
            }
        }


    }
    void destroyMark()
    {
        Destroy(floorMark.gameObject);
    }
}
