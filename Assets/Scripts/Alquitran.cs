using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alquitran : MonoBehaviour
{
    public float slow;
    GameObject a;
    public float slowDuration;
    public bool IsPinchos;
    // Start is called before the first frame update
    void Start()
    {
        if (!IsPinchos)
        {
            Destroy(gameObject, 7);
        }
    }

}
