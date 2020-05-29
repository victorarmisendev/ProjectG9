using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public GameObject player;
    public static bool start = false;

    private IEnumerator coroutine;
    void Start()
    {
        coroutine = ExecuteAfterTime();
        StartCoroutine(coroutine);
    }

    void FixedUpdate()
    {
        //transform.position = 
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(3);
        start = true;
        // Code to execute after the delay
    }


}
