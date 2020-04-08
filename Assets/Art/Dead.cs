using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Lava")
        {
            //Reset the position when the player collides lava. 

            GameObject[] puentes = GameObject.FindGameObjectsWithTag("Puente");

            //Get the last post before die. 

            Vector3 position_player = transform.position;

            //Conseguir un puente de mayor distancia en z que el player
            //con un rango min and max. 

            List<GameObject> PUENTES = new List<GameObject>();

            foreach(var b in puentes)
            {
                if(b.transform.position.z > position_player.z)
                {
                    PUENTES.Add(b);
                }
            }

            GameObject bridge = PUENTES[Random.Range(0, PUENTES.Capacity)];
            Transform bTransform = bridge.transform;

            gameObject.transform.position = new Vector3(bTransform.position.x, 2.0f, bTransform.position.z);
        }

    }

}
