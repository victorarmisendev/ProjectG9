using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    //Procedural variant of the procedural scripts: MyProceduralMap
    public GameObject[] fields;
    public GameObject[] fields2;
    public GameObject[] fields3;
    public GameObject[] fields4;
    private Vector3 newPos = Vector3.zero;
    public GameObject lastField;
    public float timeSpawn = 1.5f;
    GameObject fieldInstanced;

    int counter = 1;
    int numChunks = 1;
    Queue<GameObject> myQueue = new Queue<GameObject>();

    void Start()
    {
        myQueue.Enqueue(lastField);
        newPos = lastField.transform.position;
        //InvokeRepeating("Instance", 0.5f, timeSpawn);
        Instance();
        Instance();
        Instance();
        Instance();
        Instance();
        Instance();
        Instance();
        Instance();
    }

    GameObject RandomFunction(GameObject[] fields)
    {
        return fields[Random.Range(0, fields.Length)];
    }
    GameObject RandomFunction2(GameObject[] fields2)
    {
        return fields2[Random.Range(0, fields2.Length)];
    }
    GameObject RandomFunction3(GameObject[] fields3)
    {
        return fields3[Random.Range(0, fields3.Length)];
    }
    GameObject RandomFunction4(GameObject[] fields4)
    {
        return fields4[Random.Range(0, fields4.Length)];
    }

    public void Instance()
    {
        newPos = lastField.transform.position + Vector3.forward * 83.1f;
        if (numChunks < 13)
        {
            fieldInstanced = Instantiate(RandomFunction3(fields3), newPos, Quaternion.identity);
        }
        else if(numChunks >=13 && numChunks < 27)
        {
            fieldInstanced = Instantiate(RandomFunction2(fields2), newPos, Quaternion.identity);
        }
        else
        {
            fieldInstanced = Instantiate(RandomFunction(fields), newPos, Quaternion.identity);
        }

        
        
        lastField = fieldInstanced;
        myQueue.Enqueue(lastField);
        counter++;
        numChunks++;

        if(counter >= 17)
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
