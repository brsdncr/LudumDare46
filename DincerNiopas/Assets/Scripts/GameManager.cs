using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numberOfBacteriasForLevel;
    int numberOfDeadBacterias;
    List<BacteriaSpawner> bacteriaSpawners;
    int noTracker = 0;

    // Start is called before the first frame update
    void Start()
    {
        numberOfDeadBacterias = 0;
        noTracker = numberOfDeadBacterias;
        //Debug.Log("numberOfDeadBacterias Start1: " + numberOfDeadBacterias);
        SetBacteriaSpawners();
        //Debug.Log("numberOfDeadBacterias Start2: " + numberOfDeadBacterias);
        SendRequestToSpawnANewBacteria();
        //Debug.Log("numberOfDeadBacterias Start3: " + numberOfDeadBacterias);
    }

    private void Update()
    {
        if (noTracker != numberOfDeadBacterias)
        {
            //Debug.Log("I changed to: " + numberOfDeadBacterias);
            noTracker = numberOfDeadBacterias;
        }
    }



    private void SendRequestToSpawnANewBacteria()
    {
        if (numberOfDeadBacterias < numberOfBacteriasForLevel)
        {
            int randomSpawnerIndex = Random.Range(0, bacteriaSpawners.Count - 1);
            bacteriaSpawners[randomSpawnerIndex].SpawnBacteria();
        }
        else
        {
            //Debug.Log("Game ended");
        }
    }

    private void SetBacteriaSpawners()
    {
        bacteriaSpawners = new List<BacteriaSpawner>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("BacteriaSpawner"))
        {
            bacteriaSpawners.Add(go.GetComponent<BacteriaSpawner>());
        }
        //Debug.Log("numberOfDeadBacterias Set Bacteria Spawners: " + numberOfDeadBacterias);
    }


    public void AnnounceNewBacteriaSpawn()
    {
        //Debug.Log("I was born");
        ////Debug.Log("Number of bacterias spawned: " + numberOfBacteriasSpawned);

    }

    public void AnnounceBacteriaDeath()
    {
        //Debug.Log("numberOfDeadBacterias Before: " + numberOfDeadBacterias);
        //numberOfDeadBacterias++;
        //Debug.Log("numberOfDeadBacterias After: " + numberOfDeadBacterias);
        
        SendRequestToSpawnANewBacteria();
    }
}
