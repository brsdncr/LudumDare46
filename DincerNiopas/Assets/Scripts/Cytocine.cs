using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cytocine : MonoBehaviour, INucleoAcid
{
    private readonly int nucleoAcid = 0001;

    public int GetNucleoAcid()
    {
        return nucleoAcid;
    }
}
