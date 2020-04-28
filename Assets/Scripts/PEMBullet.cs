using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEMBullet : MonoBehaviour
{
    public float Speed;
    public float stundur;
    public GameObject areaEfec;
    public bool rear;
    // Start is called before the first frame update
    void Start()
    {
        if (Speed != 0)
        {
            Destroy(gameObject, 3);
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
                transform.Translate(-Vector3.forward * Time.deltaTime * 20.0f);
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
