using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    //Procedural variant of the procedural scripts: MyProceduralMap
    public GameObject[] fields;
    private Vector3 newPos = Vector3.zero;
    public GameObject lastField;
    public float timeSpawn = 1.5f;

    int counter = 1;
    Queue<GameObject> myQueue = new Queue<GameObject>();

    void Start()
    {
        myQueue.Enqueue(lastField);
        newPos = lastField.transform.position;
        InvokeRepeating("Instance", 0.5f, timeSpawn);
        Instance();
        Instance();
        Instance();
        Instance();
    }

    GameObject RandomFunction(GameObject[] fields)
    {
        return fields[Random.Range(0, fields.Length)];
    }

    void Instance()
    {
        newPos = lastField.transform.position + Vector3.forward * 83.1f;
        GameObject fieldInstanced = Instantiate(RandomFunction(fields), newPos, Quaternion.identity);
        lastField = fieldInstanced;
        myQueue.Enqueue(lastField);
        counter++;

        if(counter >= 11)
        {
            removeChunk();
        }

        //Destroy(fieldInstanced, 10.0f);
        //Borrar todas aquellas fields que ya se han creado y no se vean en pantalla y que esten por detras
        //del jugador. 
    }
    void removeChunk()
    {
        GameObject chunkToDestroy;
        chunkToDestroy = myQueue.Dequeue();
        Destroy(chunkToDestroy);
        counter--;
    }

}
