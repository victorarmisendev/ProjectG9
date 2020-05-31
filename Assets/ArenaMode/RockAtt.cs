using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAtt : MonoBehaviour
{
    public GameObject[] elements1;
    public GameObject particles;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerArena")
        {
            Destroy(other.gameObject);
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
        particles.SetActive(true);

    }
}
