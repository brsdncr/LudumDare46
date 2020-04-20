using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numberOfBacteriasForLevel;
    int numberOfDeadBacterias;
    List<BacteriaSpawner> bacteriaSpawners;

    //Sound control
	AudioManager audioManager;
	TimeManager timeManager;

    bool isGameOver = false;
	float difficultyIncreaseRate = 0.2f;

	// Start is called before the first frame update
	void Start()
    {
        SetSubManagers();
        numberOfDeadBacterias = 0;
        SetBacteriaSpawners();
        AssignBacterias();
        StartTimer();
    }

    private void SetSubManagers()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();

    }

    private void StartTimer()
    {
        timeManager.StartTimer();
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
        /*if (numberOfDeadBacterias == numberOfBacteriasForLevel)
        {
			audioManager.GameOver();
			Debug.Log("Level Ended");
        }*/
    }

    public void InformCellCollusion()
    {
        if (!isGameOver)
        {
            timeManager.StopTimer();
            audioManager.GameOver();
            timeManager.ShowCurrentScore();
            isGameOver = true;
            Debug.Log("Level Ended");
        }
    }

    public void IncreaseGameDifficulty()
	{
		for (int i = 0; i < bacteriaSpawners.Count; i++)
		{
            bacteriaSpawners[i].IncreaseSpawnerDifficulty(difficultyIncreaseRate);
        }
	}
}
