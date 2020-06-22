using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Vector3 initialPos;
    private void Start()
    {
        initialPos = transform.position;
    }
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

    private void Update()
    {
        transform.position += new Vector3(0.0f, Mathf.Sin(Time.deltaTime), 0.0f);
    }
}
