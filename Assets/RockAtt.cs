using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAtt : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerArena")
        {
            Destroy(other.gameObject);
        }
    }
}
