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

        initialPos = currentChunk.transform.position;
        spawnRot = currentChunk.transform.rotation;
    }



    GameObject pickChunk(int counter)
    {
        if (counter < 30)
        {
            int rand = Random.Range(0, 14);
            return chunks[rand];
        }

        else if (counter < 60 && counter >= 30)
        {
            int rand = Random.Range(0, 14);
            return chunks[rand];
        }

        else if (counter < 90 && counter >= 60)
        {
            int rand = Random.Range(0, 14);
            return chunks[rand];
        }

        else
        {
            int rand = Random.Range(0, 14);
            return chunks[rand];
        }
    }



    public void spawnChunk()
    {
        GameObject chunkToSpawn = pickChunk(counter);
        
        spawnPos = initialPos + new Vector3(0, 0, chunkLength * counter);
            
        GameObject newChunk = Instantiate(chunkToSpawn, spawnPos, spawnRot);
        counter++;

        myQueue.Enqueue(newChunk);
        if(counter > 14)
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
