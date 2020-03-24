using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaAlquitran : MonoBehaviour
{
    public float Speed;
    public float dmg;
    public GameObject ObjSuleo;
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
            Instantiate(ObjSuleo.transform, new Vector3( gameObject.transform.position.x,7.39f, gameObject.transform.position.z), Quaternion.identity);
        }
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        Instantiate(ObjSuleo.transform, new Vector3(gameObject.transform.position.x, 7.39f, gameObject.transform.position.z), Quaternion.identity);
    }
}
