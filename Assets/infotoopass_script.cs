using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infotoopass_script : MonoBehaviour
{
    public int[] carID;
    public int Maxscore;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        carID[1] = 1;
        carID[2] = 1;
        carID[3] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
