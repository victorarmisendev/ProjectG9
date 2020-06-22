using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
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

    public PlayerData(inGameRecord ir)
    {
        FSP = ir.FSP;
        SSP = ir.SSP;
        TSP = ir.TSP;

        FMP = ir.FMP;
        SMP = ir.SMP;
        TMP = ir.TMP;

        FA = ir.FA;
        SA = ir.SA;
        TA = ir.TA;
    }
}
