using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManagerSP : MonoBehaviour
{
    public GameObject[] playerTypes;
    public GameObject[] rails;

    public Camera main;
    public GameObject finishCanvas;
    public GameObject scoreCanvas;
    // Start is called before the first frame update
    void Start()
    {
        GameObject info = GameObject.FindGameObjectWithTag("BScenes");
        for (int i = 0; i < info.GetComponent<infotoopass_script>().carID.Length; i++)
        {
            if (info.GetComponent<infotoopass_script>().carID[i] > 0)
            {
                GameObject player = (GameObject)Instantiate(playerTypes[info.GetComponent<infotoopass_script>().carID[i]-1], Vector3.zero, Quaternion.identity);
                player.GetComponent<PlayerRails>().rails = rails;
                player.GetComponent<PlayerRails>().main = main;
                player.GetComponent<PlayerRails>().finishCanvas = finishCanvas;
                scoreCanvas.GetComponent<Stats>().player = player;
                finishCanvas.GetComponent<Finish>().player = player;

            }
        }
        Destroy(GameObject.FindGameObjectWithTag("BScenes"));
    }


}
