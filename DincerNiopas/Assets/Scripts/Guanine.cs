using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guanine : MonoBehaviour, INucleoAcid
{
    private readonly int nucleoAcid = 0010;

    public int GetNucleoAcid()
    {
        return nucleoAcid;
    }
}
