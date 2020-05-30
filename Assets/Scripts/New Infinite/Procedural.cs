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
        InvokeRepeating("Instance", 0.5f, 1.1f);
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
        //Destroy(fieldInstanced, 10.0f);
        //Borrar todas aquellas fields que ya se han creado y no se vean en pantalla y que esten por detras
        //del jugador. 
    }

}
