using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gstart : MonoBehaviour
{
    public GameObject HUD;
    public GameObject[] playerTypes;
    // Start is called before the first frame update
    void Start()
    {
        GameObject info = GameObject.FindGameObjectWithTag("BScenes");
        if (info != null)
        {
            for (int i = 0; i < info.GetComponent<infotoopass_script>().carID.Length; i++)
            {
                if (info.GetComponent<infotoopass_script>().carID[i] > 0)
                {
                    GameObject player = (GameObject)Instantiate(playerTypes[info.GetComponent<infotoopass_script>().carID[i] - 1], Vector3.zero, Quaternion.identity);
                    HUD.GetComponent<MPStats>().player[0] = player;
                    HUD.GetComponent<MPStats>().T1.SetActive(true);
                }
            }
            Destroy(GameObject.FindGameObjectWithTag("BScenes"));
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("PlayerArena");
            HUD.GetComponent<MPStats>().player[0] = player;
            HUD.GetComponent<MPStats>().T1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
