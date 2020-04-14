using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEMBullet : MonoBehaviour
{
    public float Speed;
    public float stundur;
    public GameObject areaEfec;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 7.0f);
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
        areaEfec.SetActive(true);
        
    }
}
