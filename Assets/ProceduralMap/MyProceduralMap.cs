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

    private void Start()
    {
        //InvokeRepeating("renewChunks", 5.0f, 5.0f);
        spawnedChunks[0] = currentChunk;
    }



    GameObject pickChunk(GameObject currentChunk)
    {
            int rand = Random.Range(0, 4);
            return chunks[rand];
    }



    void spawnChunk()
    {
        spawnPos = currentChunk.transform.position;
        spawnRot = currentChunk.transform.rotation;
        GameObject chunkToSpawn = pickChunk(currentChunk);
        spawnPos = currentChunk.transform.position + new Vector3(0, 0, 30 * counter);
            
        Instantiate(chunkToSpawn, spawnPos, spawnRot);
        //spawnedChunks[counter] = chunkToSpawn;
        counter++;
        if(currentChunk == null)
        {
            print("porque no furula?");
        }
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            spawnChunk();
        }
    }

    //void renewChunks()
    //{
    //    Destroy(spawnedChunks[counterRemove]);
    //    counterRemove++;
    //}

}
