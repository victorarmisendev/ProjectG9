using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy1 : MonoBehaviour
{
    private bool active = false;
    public float speed;
    Vector3 pos;
    float random, random2;
    public Rigidbody rb;
    public GameObject explosion;

    void Start()
    {
        random = Random.Range(-26, 26);
        random2 = Random.Range(-26, 26);
        pos = new Vector3(transform.position.x + random,
                                transform.position.y,
                                transform.position.z + random2);
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(active)
        {           
            rb.position = Vector3.Lerp(transform.position, pos, Time.fixedDeltaTime * speed);
            if(Vector3.Distance(rb.position, pos) < 3.0f)
            {
                bool forOrNe = (Random.value > 0.5f);
                Vector3 dir = Vector3.forward;
                if (forOrNe)
                    dir = Vector3.forward;
                else
                    dir = -Vector3.forward;
                rb.AddForce(dir * Random.Range(30, 100), ForceMode.Impulse);
                StartCoroutine(waitSeconds(1.0f));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = true;
        }
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
            Destroy(gameObject, 0.5f);
        }
    }

    IEnumerator waitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //Instantiate here
        GameObject par = Instantiate(explosion, rb.position, explosion.transform.rotation);
        Destroy(this.gameObject);
        Destroy(par, 3.0f);
    }

}
