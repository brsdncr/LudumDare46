using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INucleoAcid
{
    int GetNucleoAcid();
}

public interface IKillable
{
    void Kill(int aminoAcid);
}
