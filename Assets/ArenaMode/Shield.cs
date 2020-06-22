using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
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
            if (other.gameObject.GetComponent<PlayerArena>().shield == false)
            {
                other.gameObject.GetComponent<PlayerArena>().shield = true;
            }
        }
        Destroy(this.gameObject);
    }
    void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
    }
}
