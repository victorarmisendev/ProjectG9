using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEM : MonoBehaviour
{
    public float Speed;
    public float dmg;
    public int stundur;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 7.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerControler>()!=null)
        {

            collision.gameObject.GetComponent<PlayerControler>().Stun(stundur);
            collision.gameObject.GetComponent<PlayerControler>().DMG(dmg);
        }
        Destroy(gameObject);
    }
}
