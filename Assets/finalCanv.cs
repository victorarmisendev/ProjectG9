using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalCanv : MonoBehaviour
{
    public GameObject finalCanvas;
    public GameObject lastcanv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        finalCanvas.SetActive(true);
        lastcanv.SetActive(false);
    }
    public void goMenu()
    {
        
    }
}
