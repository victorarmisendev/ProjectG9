using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Base")
        {
            spawner.GetComponent<MyProceduralMap>().spawnChunk();
            Destroy(gameObject.GetComponent<BoxCollider>());

            
        }
    }

}
