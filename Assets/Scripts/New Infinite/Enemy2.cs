using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private bool active = false;
    public Rigidbody rb;
    public GameObject explosion;
    public float speed, speedFrenquency;
    public float coef;
    private float count = 0;

    public float amplitud = 10.0f, frenquency = 0.7f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (active)
        {
            //rb.MovePosition(rb.position - Vector3.forward * speed * Time.fixedDeltaTime);
            
            //rb.MovePosition(rb.position + 
            //    Vector3.up *
            //   (coef * Mathf.Abs(Mathf.Sin(Time.time * speedFrenquency))));
            //print(count);
        }
    }

    private void Update()
    {
        if (active)
        {
            float x = transform.position.x;
            float y = 10.0f + Mathf.Sin(Time.time * frenquency) * amplitud;

            transform.position -= (Vector3.forward * speed) * Time.deltaTime;
            float z = transform.position.z;
            transform.position = new Vector3(x, y, z);

            transform.position += Vector3.up * 6.0f * Mathf.Sin(Time.time * 3f) * 1f;
        }
        //print(Time.deltaTime);
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = true;
        }
    }


}
