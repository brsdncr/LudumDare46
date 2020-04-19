using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thymine : MonoBehaviour, INucleoAcid
{
    private readonly int nucleoAcid = 0100;

    public int GetNucleoAcid()
    {
        return nucleoAcid;
    }
}
