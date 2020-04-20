using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Sounds
    [SerializeField] AudioClip bacteriaDeath;
    [SerializeField] AudioClip bacteriaBuzz;
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioClip nucleoAcidSelect;


    private static AudioManager _instance = null;
    
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            this.transform.parent = null;
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void NucleoAcidSelect()
    {
        AudioSource.PlayClipAtPoint(nucleoAcidSelect, Vector3.zero, 0.2f);
    }

    public void BacteriaDeath()
    {
        AudioSource.PlayClipAtPoint(bacteriaDeath, Vector3.zero);
    }

    public void BacteriaBuzz()
    {
        AudioSource.PlayClipAtPoint(bacteriaBuzz, Vector3.zero);
    }

    public void GameOver()
    {
        AudioSource.PlayClipAtPoint(gameOver, Vector3.zero);
    }
}
