using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AminoAcidFactory : MonoBehaviour
{
    private int currentNucleoAcid;
    private int temp;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        InitializeNucleoAcid();
    }
    public int AddNucleoAcid(int newNucleoAcid)
    {
        int digit = (currentNucleoAcid / newNucleoAcid) % 10;

        if (digit == 0)
        {
            audioManager.NucleoAcidSelect();
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
