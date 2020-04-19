using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adenine : MonoBehaviour, INucleoAcid
{
    private readonly int nucleoAcid = 1000;

    public int GetNucleoAcid()
    {
        return nucleoAcid;
    }
}
