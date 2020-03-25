using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject[] players;
    private Vector3 velocity;
    private float smoothTime = .5f;
    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Base");
    }
    void LateUpdate()
    {
        SetPos();
    }
    void SetPos()
    {
        Vector3 posFrame = Vector3.zero;
        for (int i = 0; i < players.Length; i++)
        {
            posFrame += players[i].transform.position;
        }
        //Camera
        posFrame /= players.Length;
        Vector3 newPos = new Vector3(posFrame.x, 31, -24);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
    }


}
