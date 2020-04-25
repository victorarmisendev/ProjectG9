using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject[] chunks;
    public float timer = 0.1f, originalTimer = 0.0f;
    Vector3 currentChunkPos = Vector3.zero;
    public Transform firstChunk;
    public Vector3 offsetZ;
    private int first = 0;
    private float normal_spawn = 0.0f;
    private int fase = 0;

    public string[] helperTexts;
    public Text helper;

    float timerPhase = 10.0f;

    private GameObject chunkToSpawn;

    private void Start()
    {
        //Camera speed and timer. 
        normal_spawn = 90.0f / Camera.main.gameObject.GetComponent<CameraFollow>().speed; //SPAWNER
        //print(timer);
        originalTimer = normal_spawn;

        //TUTORIAL:
        currentChunkPos = firstChunk.position;
        Vector3 newPosAux = currentChunkPos + Vector3.forward * 84;
        Instantiate(chunks[0], newPosAux, chunks[fase].transform.rotation);
        currentChunkPos = newPosAux;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            //Spawn a random chunk. 
            InvokeChunk(offsetZ, fase); //All the chunks are the same size. In z. 
            timer = originalTimer;
            first++;
        }
        if (first >= 1)
        {
            originalTimer = normal_spawn;
        }

        //TIMER FASE CHANGE: EVERY MIN.
        timerPhase -= Time.deltaTime;
        if(timerPhase <= 0.0f && fase < 4)
        {
            timerPhase = 10.0f;
            fase++;
        }
        //FEEDBACK TUTORIAL IN THESE MINUTES: 
        //TEXT! 
        if(fase > 3)
            helper.text = helperTexts[fase];
        Debug.Log(fase);
        if (fase > 3)
        {
            Destroy(this);
            //Instanciar meta y finalizar tutorial. 
        }
            
    }


    void InvokeChunk(Vector3 offset, int phase) //INVOKE THE CHUNKS.
    {
        Vector3 newPos = currentChunkPos + offset;
        GameObject c = Instantiate(chunks[phase], newPos, chunks[fase].transform.rotation);
        //Destroy(c, 32.0f); //Los elimina antes idk, DANGER.
        currentChunkPos = newPos;
    }
}
