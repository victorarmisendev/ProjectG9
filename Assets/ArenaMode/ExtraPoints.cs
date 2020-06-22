using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPoints : MonoBehaviour
{
    private Vector3 initialPos;
    private void Start()
    {
        initialPos = transform.position;
        Invoke("DestroyMe", 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerArena")
        {
            other.gameObject.GetComponent<PlayerArena>().score += 1000;
        }
        Destroy(this.gameObject);
    }

    void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}