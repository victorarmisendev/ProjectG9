using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gstart : MonoBehaviour
{
    public GameObject HUD;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerArena");
        HUD.GetComponent<MPStats>().player[0] = player;
        HUD.GetComponent<MPStats>().T1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
