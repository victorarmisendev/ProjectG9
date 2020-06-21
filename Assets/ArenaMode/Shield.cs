using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ArenaPlayer")
        {
            if (other.gameObject.GetComponent<PlayerArena>().shield == false)
            {
                other.gameObject.GetComponent<PlayerArena>().shield = true;
            }
        }
        Destroy(this.gameObject);
    }
}
