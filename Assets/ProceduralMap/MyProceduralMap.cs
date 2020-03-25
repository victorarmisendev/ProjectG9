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

    Queue<GameObject> myQueue = new Queue<GameObject>();

    private void Start()
    {
        //InvokeRepeating("spawnChunk", 2.0f, 2.0f);
        spawnChunk();
        spawnChunk();
        spawnChunk();
    }



    GameObject pickChunk()
    {
            int rand = Random.Range(0, 5);
            return chunks[rand];
    }



    public void spawnChunk()
    {
        spawnPos = currentChunk.transform.position;
        spawnRot = currentChunk.transform.rotation;
        GameObject chunkToSpawn = pickChunk();
        
        spawnPos = currentChunk.transform.position + new Vector3(0, 0, 30 * counter);
            
        GameObject newChunk = Instantiate(chunkToSpawn, spawnPos, spawnRot);
        counter++;

        myQueue.Enqueue(newChunk);
        if(counter > 7)
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
