using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    GameObject go;
    DNA dna;
    AminoAcidFactory aminoAcidFactory;
    // Start is called before the first frame update
    void Start()
    {
        aminoAcidFactory = GameObject.FindGameObjectWithTag("AminoAcidFactory").GetComponent<AminoAcidFactory>();
        go = GameObject.Find("DNA");
        dna = (DNA)go.GetComponent(typeof(DNA));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent(typeof(INucleoAcid)) is INucleoAcid nucleoAcid)
                {
                    aminoAcidFactory.AddNucleoAcid(nucleoAcid.GetNucleoAcid());
                    dna.UpdateSprite(aminoAcidFactory.GetNucleoAcid());
                }
                if (hit.collider.gameObject.GetComponent(typeof(IKillable)) is IKillable bacteria)
                {
                    bacteria.Kill(aminoAcidFactory.SendAminoAcid());
                    dna.UpdateSprite(aminoAcidFactory.GetNucleoAcid());
                }

            }
        }
    }
}
