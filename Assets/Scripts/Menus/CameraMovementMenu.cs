using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementMenu : MonoBehaviour
{

    public GameObject menuGlobal;
    private MenuGlobal menu_;
    private float [] sectionsPos; //Altura de movimiento de las secciones. 

    void Start()
    {

        menu_ = menuGlobal.GetComponent<MenuGlobal>();

        sectionsPos = new float[3];
        sectionsPos[0] = menu_.sections[0].transform.position.y + 8;
        sectionsPos[1] = menu_.sections[1].transform.position.y - 30;
        sectionsPos[2] = menu_.sections[2].transform.position.y;
    }

    void Update()
    {
        
        //if(menu_.stateMenu == 1)
        //{
        //    //Mover hasta punto indicado. 
        //    float step = 1.5f * Time.deltaTime; // calculate distance to move
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, sectionsPos[0], transform.position.z), step);
        //}
        //if (menu_.stateMenu == 2)
        //{
        //    float step = 1.5f * Time.deltaTime; // calculate distance to move
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, sectionsPos[1], transform.position.z), step);
        //}
        //if (menu_.stateMenu == 3)
        //{
        //    float step = 1.5f * Time.deltaTime; // calculate distance to move
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, sectionsPos[2], transform.position.z), step);
        //}
    }

   

}
