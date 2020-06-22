using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRespawn : MonoBehaviour
{
    public GameObject toSpawn;
    private void OnTriggerEnter(Collider other)
    {
        toSpawn = other.transform.Find("Reset").gameObject;
    }
}
