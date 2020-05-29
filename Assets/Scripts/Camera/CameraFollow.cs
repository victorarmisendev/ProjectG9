using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    private GameObject[] players;
    private Vector3 velocity;
    private float smoothTime = .5f;
    public float speed;
    public static bool start = false;

    private IEnumerator coroutine;


    private void Start()
    {
        coroutine = ExecuteAfterTime();
        StartCoroutine(coroutine);
        //players = GameObject.FindGameObjectsWithTag("Base");
    }
    void FixedUpdate() 
    //Para evitar la vibración de los objetos mientras la camara se mueve: BUG raro. 
    //Si utilizamos FixedUpdate para mover los personajes, usar lo mismo para el movimiento de la camara. IDK WHY. 
    //Almenos reducimos esta vibracion bastante. 
    {
        //SetPos();
        if(start == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
            transform.position.z + speed * Time.fixedDeltaTime);
        }

    }
    void SetPos()
    {
        //Vector3 posFrame = Vector3.zero;
        //for (int i = 0; i < players.Length; i++)
        //{
        //    posFrame += players[i].transform.position;
        //}
        ////Camera
        //posFrame /= players.Length;
        //Vector3 newPos = new Vector3(posFrame.x, 31, -24);
        //transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(3);
        start = true;
        // Code to execute after the delay
    }
}
