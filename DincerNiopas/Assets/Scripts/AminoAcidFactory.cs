using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AminoAcidFactory : MonoBehaviour
{
    private int currentNucleoAcid;
    private int temp;

    private void Start()
    {
        InitializeNucleoAcid();
    }
    public int AddNucleoAcid(int newNucleoAcid)
    {

        if (currentNucleoAcid % (newNucleoAcid*10) == 0 || newNucleoAcid > currentNucleoAcid)
        {
            currentNucleoAcid += newNucleoAcid;
        }
        return (currentNucleoAcid);
    }

    public int SendAminoAcid()
    {
        temp = currentNucleoAcid;
        InitializeNucleoAcid();
        return temp;
    }

    public int GetNucleoAcid()
    {
        return currentNucleoAcid;
    }

    public void InitializeNucleoAcid()
    {
        currentNucleoAcid = 0;
    }
}
