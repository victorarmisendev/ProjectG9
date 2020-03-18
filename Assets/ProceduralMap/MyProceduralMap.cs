using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyProceduralMap : MonoBehaviour
{

    public GameObject[] chunks;
    public GameObject currentChunk;

    private Vector3 spawnPos;
    private Quaternion spawnRot;




    GameObject pickChunk(GameObject currentChunk)
    {
        if (currentChunk.tag == "ForwardRoad")
        {
            int rand = Random.Range(2, 3);
            return chunks[rand];
        }
        else if (currentChunk.tag == "LeftTurn")
        {
            int rand = Random.Range(1, 2);
            return chunks[rand];
        }
        else
        {
            int rand = Random.Range(1, 3);
            return chunks[rand];
        }
    }

    void spawnChunk()
    {
        spawnPos = currentChunk.transform.position;
        spawnRot = currentChunk.transform.rotation;
        print(currentChunk.transform.position);
        GameObject chunkToSpawn = pickChunk(currentChunk);
        if(currentChunk.tag == "ForwardRoad")
        {
            if (chunkToSpawn.tag == "ForwardRoad")
            {
                spawnPos = currentChunk.transform.position + new Vector3(0, 0, 30);
            }
            else if (chunkToSpawn.tag == "LeftTurn")
            {
                spawnRot = currentChunk.transform.rotation * Quaternion.Euler(0, 180, 0);

            }
            else
            {
                spawnPos = currentChunk.transform.position + new Vector3(20, 0, 20);
                spawnRot = currentChunk.transform.rotation * Quaternion.Euler(0, 90, 0);
            }
        }
        else if(currentChunk.tag == "LeftTurn")
        {
            if (chunkToSpawn.tag == "ForwardRoad")
            {
                spawnPos = currentChunk.transform.position + new Vector3(-50, 0, 20);
                spawnRot = currentChunk.transform.rotation * Quaternion.Euler(0, 90, 0);
            }
            else
            {
                spawnPos = currentChunk.transform.position + new Vector3(20, 0, 20);
                spawnRot = currentChunk.transform.rotation * Quaternion.Euler(0, 90, 0);
            }
        }


        Instantiate(chunkToSpawn, spawnPos, spawnRot);
        currentChunk = chunkToSpawn;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            spawnChunk();
        }
    }

}
