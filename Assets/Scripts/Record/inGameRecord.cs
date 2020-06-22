using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameRecord : MonoBehaviour
{
    public int FSP;
    public int SSP;
    public int TSP;

    public int FMP;
    public int SMP;
    public int TMP;

    public int FA;
    public int SA;
    public int TA;

    public int newSScore;
    public int newMScore;
    public int newAScore;

    public int Gamemode;
    public int CARID;
    public int PlayerID;
    // Start is called before the first frame update
    void Start()
    {
       if( GameObject.FindObjectsOfType<inGameRecord>().Length>1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        PlayerData Data = RecordHolder.LoadRecord();
        if (Data != null)
        {
            FSP = Data.FSP;
            SSP = Data.SSP;
            TSP = Data.TSP;

            FMP = Data.FMP;
            SMP = Data.SMP;
            TMP = Data.TMP;

            FA = Data.FA;
            SA = Data.SA;
            TA = Data.TA;
        }
    }
    public void SaveME()
    {
        RecordHolder.SaveRecord(this);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
