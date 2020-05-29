using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    //Procedural variant of the procedural scripts: MyProceduralMap
    public GameObject[] fields;
    private Vector3 newPos = Vector3.zero;
    public GameObject lastField;
    
    void Start()
    {
        newPos = lastField.transform.position;
        InvokeRepeating("Instance", 1.0f, 1.5f);
    }

    GameObject RandomFunction(GameObject[] fields)
    {
        return fields[Random.Range(0, fields.Length)];
    }

    void Instance()
    {
        newPos = lastField.transform.position + Vector3.forward * 83.1f;
        GameObject fieldInstanced = Instantiate(RandomFunction(fields), newPos, Quaternion.identity);
        lastField = fieldInstanced;
    }

}
