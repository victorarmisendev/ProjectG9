using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    private bool active = false, colision = false;
    public Rigidbody rb;
    public GameObject explosion;
    public GameObject pos1, pos2;
    float counter = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bool ran = (Random.value > 0.5f);
        if (ran)
            transform.position = pos1.transform.position;
        else
            transform.position = pos2.transform.position;
    }

    void FixedUpdate()
    {
        if(active && colision)
        {
            counter += 0.02f;
            rb.MovePosition(rb.position - (Vector3.forward * counter));
        }
    }

    void Update()
    {
        Debug.Log("Active is: " + active.ToString() + "and colision is: " + colision);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerRails>() != null)
            {
                collision.gameObject.GetComponent<PlayerRails>().lives--;
            }
            else
            {
                collision.gameObject.GetComponent<MPPlayerRail>().lives--;
            }
            GameObject par = Instantiate(explosion, rb.position, explosion.transform.rotation);
            Destroy(par, 3.0f);
            Destroy(gameObject, 0.5f);
        }
        colision = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = true;
        }
    }


}
