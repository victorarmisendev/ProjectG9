using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    private GameObject tutManager;
    private void Start()
    {
        tutManager = GameObject.FindGameObjectWithTag("canvMan");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tutTrig")
        {
            print("collision");
            tutManager.GetComponent<canvasManager>().CanvasChange();
        }
    }
}
