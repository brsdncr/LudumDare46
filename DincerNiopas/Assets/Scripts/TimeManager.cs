using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Text timer;
	[SerializeField] float difficultyTimer;
	bool ifTimerStarted = false;
    private float startTime;
    GameManager gameManager;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void StartTimer()
    {
        startTime = 0f;
        timer.text = "0";
        ifTimerStarted = true;
        InvokeRepeating("UpdateDifficulty", 0f, difficultyTimer);

    }

    private void UpdateDifficulty()
    {
        gameManager.IncreaseGameDifficulty();
    }

    private void Update()
    {
        if (ifTimerStarted)
        {
            float diffTime = Time.time - startTime;
            string minutes = ((int)diffTime / 60).ToString();
            string seconds = (diffTime % 60).ToString("f2");

            timer.text = minutes + ":" + seconds;
        }
    }

    public void StopTimer()
    {
        ifTimerStarted = false;
        CancelInvoke("UpdateDifficulty");
    }

    public void ShowCurrentScore()
    {
        timer.text = "Your score: " + timer.text;
    }
}
