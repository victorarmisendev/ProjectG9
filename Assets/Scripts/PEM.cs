using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEM : MonoBehaviour
{
    public float Speed;
    public float dmg;
    public float stundur;
    public bool CanMove;
    // Start is called before the first frame update
    void Start()
    {
        if (CanMove)
        {
            Destroy(gameObject, 7);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerControler>()!=null)
        {

            collision.gameObject.GetComponent<PlayerControler>().Stun(stundur);

        }
        else if(collision.gameObject.GetComponentInParent<PlayerControler>() != null)
        {
            collision.gameObject.GetComponentInParent<PlayerControler>().Stun(stundur);
        }
        else
        {
            Debug.Log(collision.gameObject.name);
        }
        Destroy(gameObject);
    }
}
