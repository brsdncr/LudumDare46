using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numberOfBacteriasForLevel;
    int numberOfDeadBacterias;
    List<BacteriaSpawner> bacteriaSpawners;

    // Start is called before the first frame update
    void Start()
    {
        numberOfDeadBacterias = 0;
        SetBacteriaSpawners();
        AssignBacterias();
    }

    private void SendRequestToSpawnANewBacteria()
    {
        int randomSpawnerIndex = Random.Range(0, bacteriaSpawners.Count);
        bacteriaSpawners[randomSpawnerIndex].SpawnBacteria();
    }

    private void SetBacteriaSpawners()
    {
        bacteriaSpawners = new List<BacteriaSpawner>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("BacteriaSpawner"))
        {
            bacteriaSpawners.Add(go.GetComponent<BacteriaSpawner>());
        }
    }

    private void AssignBacterias()
    {
        for (int i = 0; i < numberOfBacteriasForLevel; i++)
        {
            SendRequestToSpawnANewBacteria();
        }
    }

    public void AnnounceBacteriaDeath()
    {
        numberOfDeadBacterias++;
        Debug.Log(numberOfDeadBacterias);
        if (numberOfDeadBacterias == numberOfBacteriasForLevel)
        {
            Debug.Log("Level Ended");
        }
    }
}
