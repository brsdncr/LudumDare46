using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNA : MonoBehaviour
{
    [SerializeField] public Sprite red, yellow, blue, black;
    [SerializeField] public Sprite darkRed, darkYellow, darkBlue, white;
    [SerializeField] public Sprite orange, green, purple, brown;
    [SerializeField] public Sprite darkOrange, darkGreen, darkPurple, darkBrown;
    SpriteRenderer sr;

    private Image myIMGcomponent;
    // Use this for initialization
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprite(int aminoAcid)
    {
        switch(aminoAcid)
        {
            case 0000: { sr.sprite = white; break; }
            case 0001: { sr.sprite = black; break; }
            case 0010: { sr.sprite = blue; break; }
            case 0011: { sr.sprite = darkBlue; break; }
            case 0100: { sr.sprite = yellow; break; }
            case 0101: { sr.sprite = darkYellow; break; }
            case 0110: { sr.sprite = green; break; }
            case 0111: { sr.sprite = darkGreen; break; }
            case 1000: { sr.sprite = red; break; }
            case 1001: { sr.sprite = darkRed; break; }
            case 1010: { sr.sprite = purple; break; }
            case 1011: { sr.sprite = darkPurple; break; }
            case 1100: { sr.sprite = orange; break; }
            case 1101: { sr.sprite = darkOrange; break; }
            case 1110: { sr.sprite = brown; break; }
            case 1111: { sr.sprite = darkBrown; break; }
            default:   { sr.sprite = white; break; }

        }
    }
}
