using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyProceduralMap : MonoBehaviour
{

    public GameObject[] chunks;
    public GameObject currentChunk;

    public GameObject[] spawnedChunks;

    private Vector3 spawnPos;
    private Quaternion spawnRot;

    private int counter = 1;

    int counterRemove = 0;

    public float chunkLength;

    Vector3 initialPos;

    Queue<GameObject> myQueue = new Queue<GameObject>();

    private void Start()
    {
        //InvokeRepeating("spawnChunk", 2.0f, 2.0f);
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();
        spawnChunk();

        initialPos = currentChunk.transform.position;
        spawnRot = currentChunk.transform.rotation;
    }



    GameObject pickChunk()
    {
        if (counter < 10)
        {
            int rand = Random.Range(0, 6);
            return chunks[rand];
        }

        else if (counter < 25 && counter > 10)
        {
            int rand = Random.Range(1, 9);
            return chunks[rand];
        }

        else if (counter > 25)
        {
            int rand = Random.Range(5, 12);
            return chunks[rand];
        }

        else
        {
            return chunks[12];
        }
    }



    public void spawnChunk()
    {
        GameObject chunkToSpawn = pickChunk();
        
        spawnPos = initialPos + new Vector3(0, 0, chunkLength * counter);
        print("spawned");
        GameObject newChunk = Instantiate(chunkToSpawn, spawnPos, spawnRot);
        counter++;

        myQueue.Enqueue(newChunk);
        if(counter > 24)
        {
            removeChunk();
        }


    }

    private void removeChunk()
    {
        GameObject chunkToDestroy;
        chunkToDestroy = myQueue.Dequeue();
        Destroy(chunkToDestroy);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            spawnChunk();
        }
    }

}
