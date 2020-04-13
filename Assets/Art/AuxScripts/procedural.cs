using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedural : MonoBehaviour
{
    public GameObject[] chunks;
    public float timer = 0.1f, originalTimer = 0.0f;
    Vector3 currentChunkPos = Vector3.zero;
    public Transform firstChunk;
    public Vector3 offsetZ;
    private int first = 0;
    private float normal_spawn = 0.0f;

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            //Spawn a random chunk. 
            InvokeChunk(offsetZ); //All the chunks are the same size. In z. 
            timer = originalTimer;
            first++;
        }
        if (first >= 2)
        {
            originalTimer = normal_spawn;
        }
    }
    private void Start()
    {
        //The first chunk it is already spawnead in scene. 
        //Let's spawn the other owns. 
        //OPTIONAL: Depending on the camera velocity. 
        //InvokeRepeating("InvokeChunk",0.1f, 3.0f); //Easy way. 
        normal_spawn = 40.0f / Camera.main.gameObject.GetComponent<CameraFollow>().speed; 
        print(timer);
        originalTimer = timer;
        currentChunkPos = firstChunk.position; 



    }

    void InvokeChunk(Vector3 offset)
    {
        int ran = Random.Range(0, chunks.Length);
        Vector3 newPos = currentChunkPos + offset;
        GameObject c = Instantiate(chunks[ran], newPos, chunks[ran].transform.rotation);
        //Destroy(c, 32.0f); //Los elimina antes idk, DANGER.
        currentChunkPos = newPos;
    }




 

}
