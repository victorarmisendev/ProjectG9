using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlweyRotate : MonoBehaviour
{
    private float velocity = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, velocity));
    }
}
