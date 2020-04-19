using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    AminoAcidFactory aminoAcidFactory;
    // Start is called before the first frame update
    void Start()
    {
        aminoAcidFactory = new AminoAcidFactory();
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
                }
                if (hit.collider.gameObject.GetComponent(typeof(IKillable)) is IKillable bacteria)
                {
                    Debug.Log(aminoAcidFactory.GetNucleoAcid());
                    bacteria.Kill(aminoAcidFactory.SendAminoAcid());
                }
                Debug.Log(hit.collider.gameObject.name);
                //hit.collider.gameObject.GetComponent<Bacteria>().DestroyBacteria(9999);
            }
        }
    }
}
