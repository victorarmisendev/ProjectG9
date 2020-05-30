using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private bool active = false;
    public Rigidbody rb;
    public GameObject explosion;
    public float speed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (active)
        {
            rb.MovePosition(rb.position - Vector3.forward * speed * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + Vector3.up *
                Mathf.Sin(Time.fixedDeltaTime * speed));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = true;
        }
    }


}
