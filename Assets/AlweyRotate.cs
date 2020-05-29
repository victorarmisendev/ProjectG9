using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlweyRotate : MonoBehaviour
{
    private float velocity = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, velocity));
    }

}
