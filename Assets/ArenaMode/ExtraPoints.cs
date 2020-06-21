using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ArenaPlayer")
        {
            other.gameObject.GetComponent<PlayerArena>().score += 1000;
        }
        Destroy(this.gameObject);
    }
}