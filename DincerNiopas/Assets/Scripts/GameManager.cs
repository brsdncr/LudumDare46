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
    LevelManager levelManager;

    bool isGameOver;
	float difficultyIncreaseRate;

    GameObject bacteriaHolder;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
		numberOfBacteriasForLevel = 1000000;
        CleanUpScene();
        SetSubManagers();
        SetBacteriaSpawners();
        AssignBacterias();
        StartTimer();
    }

    private void CleanUpScene()
    {
        bacteriaHolder = GameObject.FindGameObjectWithTag("BacteriaHolder");
        foreach (Transform child in bacteriaHolder.transform)
        {
            Destroy(child.gameObject);
        }
        Time.timeScale = 1f;
        difficultyIncreaseRate = 0.1f;
        numberOfDeadBacterias = 0;
    }

    private void SetSubManagers()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

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
        Debug.Log("Number of spawners: " + bacteriaSpawners.Count);
    }

    private void AssignBacterias()
    {
        for (int i = 0; i < numberOfBacteriasForLevel; i++)
        {
            SendRequestToSpawnANewBacteria();
        }
    }

    private void EndGame()
    {
        levelManager.LoadMainMenu();
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
            Time.timeScale = 0.1f;
            Debug.Log("Level Ended");
            Invoke("EndGame", 0.5f);//this will happen after 2 seconds
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
