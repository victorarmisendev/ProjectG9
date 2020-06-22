using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;

    public GameObject S1;
    public GameObject S2;
    public GameObject S3;

    public Text First;
    public Text Second;
    public Text Third;

    public GameObject[] playerTypes;

    public GameObject Record;
    // Start is called before the first frame update
    void Start()
    {
        Record = GameObject.FindGameObjectWithTag("Save");
        Debug.Log(Record.GetComponent<inGameRecord>().CARID - 1);
        GameObject player = (GameObject)Instantiate(playerTypes[Record.GetComponent<inGameRecord>().CARID], Vector3.zero, Quaternion.identity);
        Vector3 Scale = new Vector3();
        Scale.x = 4.307811f;
        Scale.y = 4.307811f;
        Scale.z = 4.307811f;
        player.transform.localScale = Scale;
        Scale.x = 0.93f;
        Scale.y = -1.115638e-17f;
        Scale.z = 2.42f;
        player.transform.position = Scale;
        Quaternion Rot = new Quaternion();
        Scale.x = 0;
        Scale.y = -115.481f;
        Scale.z = 0;
        player.transform.rotation = Rot;
        if (Record.GetComponent<inGameRecord>().PlayerID == 1)
        {
            t1.SetActive(true);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(false);
            if(Record.GetComponent<inGameRecord>().Gamemode==1)
            {
                t1.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newSScore;
            }
            else if(Record.GetComponent<inGameRecord>().Gamemode==2)
            {
                t1.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newMScore;
            }
            else if(Record.GetComponent<inGameRecord>().Gamemode==3)
            {
                t1.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newAScore;
            }
            
        }
        else if (Record.GetComponent<inGameRecord>().PlayerID == 2)
        {
            t1.SetActive(false);
            t2.SetActive(true);
            t3.SetActive(false);
            t4.SetActive(false);
            if (Record.GetComponent<inGameRecord>().Gamemode == 1)
            {
                t2.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newSScore;
            }
            else if (Record.GetComponent<inGameRecord>().Gamemode == 2)
            {
                t2.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newMScore;
            }
            else if (Record.GetComponent<inGameRecord>().Gamemode == 3)
            {
                t2.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newAScore;
            }
        }
        else if (Record.GetComponent<inGameRecord>().PlayerID == 3)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(true);
            t4.SetActive(false);
            if (Record.GetComponent<inGameRecord>().Gamemode == 1)
            {
                t3.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newSScore;
            }
            else if (Record.GetComponent<inGameRecord>().Gamemode == 2)
            {
                t3.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newMScore;
            }
            else if (Record.GetComponent<inGameRecord>().Gamemode == 3)
            {
                t3.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newAScore;
            }
        }
        else if(Record.GetComponent<inGameRecord>().PlayerID==4)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(true);
            if (Record.GetComponent<inGameRecord>().Gamemode == 1)
            {
                t4.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newSScore;
            }
            else if (Record.GetComponent<inGameRecord>().Gamemode == 2)
            {
                t4.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newMScore;
            }
            else if (Record.GetComponent<inGameRecord>().Gamemode == 3)
            {
                t4.transform.GetChild(0).GetComponent<Text>().text = "Points: " + Record.GetComponent<inGameRecord>().newAScore;
            }
        }
        if (Record.GetComponent<inGameRecord>().Gamemode == 1)
        {
            if(Record.GetComponent<inGameRecord>().newSScore > Record.GetComponent<inGameRecord>().FSP)
            {
                Record.GetComponent<inGameRecord>().TSP = Record.GetComponent<inGameRecord>().SSP;
                Record.GetComponent<inGameRecord>().SSP = Record.GetComponent<inGameRecord>().FSP;
                Record.GetComponent<inGameRecord>().FSP = Record.GetComponent<inGameRecord>().newSScore;

                S1.SetActive(true);
            }
            else if (Record.GetComponent<inGameRecord>().newSScore > Record.GetComponent<inGameRecord>().SSP)
            {
                Record.GetComponent<inGameRecord>().TSP = Record.GetComponent<inGameRecord>().SSP;
                Record.GetComponent<inGameRecord>().SSP = Record.GetComponent<inGameRecord>().newSScore;


                S2.SetActive(true);
            }
            else if (Record.GetComponent<inGameRecord>().newSScore > Record.GetComponent<inGameRecord>().SSP)
            {
                Record.GetComponent<inGameRecord>().TSP = Record.GetComponent<inGameRecord>().newSScore;

                S3.SetActive(true);
            }

            First.text = "" + Record.GetComponent<inGameRecord>().FSP;
            Second.text = "" + Record.GetComponent<inGameRecord>().SSP;
            Third.text = "" + Record.GetComponent<inGameRecord>().TSP;
        }
        else if (Record.GetComponent<inGameRecord>().Gamemode == 2)
        {
            if (Record.GetComponent<inGameRecord>().newMScore > Record.GetComponent<inGameRecord>().FMP)
            {
                Record.GetComponent<inGameRecord>().TMP = Record.GetComponent<inGameRecord>().SMP;
                Record.GetComponent<inGameRecord>().SMP = Record.GetComponent<inGameRecord>().FMP;
                Record.GetComponent<inGameRecord>().FMP = Record.GetComponent<inGameRecord>().newMScore;


                S1.SetActive(true);
            }
            else if (Record.GetComponent<inGameRecord>().newMScore > Record.GetComponent<inGameRecord>().SMP)
            {
                Record.GetComponent<inGameRecord>().TMP = Record.GetComponent<inGameRecord>().SMP;
                Record.GetComponent<inGameRecord>().SMP = Record.GetComponent<inGameRecord>().newMScore;


                S2.SetActive(true);
            }
            else if (Record.GetComponent<inGameRecord>().newMScore > Record.GetComponent<inGameRecord>().SMP)
            {
                Record.GetComponent<inGameRecord>().TMP = Record.GetComponent<inGameRecord>().newMScore;

                S3.SetActive(true);
            }

            First.text = "" + Record.GetComponent<inGameRecord>().FMP;
            Second.text = "" + Record.GetComponent<inGameRecord>().SMP;
            Third.text = "" + Record.GetComponent<inGameRecord>().TMP;
        }
        else if (Record.GetComponent<inGameRecord>().Gamemode == 3)
        {
            if (Record.GetComponent<inGameRecord>().newAScore > Record.GetComponent<inGameRecord>().FA)
            {
                Record.GetComponent<inGameRecord>().TA = Record.GetComponent<inGameRecord>().SA;
                Record.GetComponent<inGameRecord>().SA = Record.GetComponent<inGameRecord>().FA;
                Record.GetComponent<inGameRecord>().FA = Record.GetComponent<inGameRecord>().newAScore;


                S1.SetActive(true);
            }
            else if (Record.GetComponent<inGameRecord>().newAScore > Record.GetComponent<inGameRecord>().SA)
            {
                Record.GetComponent<inGameRecord>().TA = Record.GetComponent<inGameRecord>().SA;
                Record.GetComponent<inGameRecord>().SA = Record.GetComponent<inGameRecord>().newAScore;


                S2.SetActive(true);
            }
            else if (Record.GetComponent<inGameRecord>().newAScore > Record.GetComponent<inGameRecord>().SA)
            {
                Record.GetComponent<inGameRecord>().TA = Record.GetComponent<inGameRecord>().newAScore;

                S3.SetActive(true);
            }

            First.text = "" + Record.GetComponent<inGameRecord>().FA;
            Second.text = "" + Record.GetComponent<inGameRecord>().SA;
            Third.text = "" + Record.GetComponent<inGameRecord>().TA;
        }
        //Record.GetComponent<inGameRecord>().SaveME();

    }

    // Update is called once per frame
    void Update()
    {
        //Record.GetComponent<inGameRecord>().SaveME();
        if(Gamepad.all[0].startButton.isPressed)
        {
            SceneManager.LoadScene("Splash");
        }

    }
}
