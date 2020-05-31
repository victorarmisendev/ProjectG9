using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleFollowing : MonoBehaviour
{
    public GameObject myMesh;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = myMesh.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
