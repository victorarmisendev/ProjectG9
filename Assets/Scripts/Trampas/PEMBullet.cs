using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEMBullet : MonoBehaviour
{
    public float Speed;
    public float stundur;
    public GameObject areaEfec;
    public bool rear = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Speed != 0)
        {
            
            if (rear)
            {
               Quaternion targetRotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
               transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f * Time.deltaTime);
                Debug.Log("HEY");
            }
            Destroy(gameObject, 1.5f);
        }
        else
        {
            Destroy(gameObject, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Speed != 0)
        {
            if(rear)
            {
                transform.Translate(Vector3.back * Time.deltaTime * 30.0f,Space.World);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 20.0f);
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {

            collision.gameObject.GetComponent<PlayerControler>().Stun(stundur);

        }
        else if (collision.gameObject.GetComponentInParent<PlayerControler>() != null)
        {
            collision.gameObject.GetComponentInParent<PlayerControler>().Stun(stundur);
        }
        else
        {
            Debug.Log(collision.gameObject.name);
        }
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (Speed != 0)
        {
            Instantiate(areaEfec.transform, new Vector3(gameObject.transform.position.x, 7.39f, gameObject.transform.position.z), Quaternion.identity);
        }
       
    }

}
