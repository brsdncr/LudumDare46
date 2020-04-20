using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
	[SerializeField] GameObject bacteriaPrefab;
    [SerializeField] float startAfterTime;
    [SerializeField] float repeatingTime;

    //public float startAfterTime;
    //public float repeatingTime;

    int difficultyLevel;
    float newCellSpeed;
    bool startGenerating;

	int numberOfBacteriasInQueue;
	int numberOfColors;

    //GameObject bacteriaHolder;

    private void Start()
    {
        InitializeParams();
        //bacteriaHolder = GameObject.FindGameObjectWithTag("BacteriaHolder");
    }

    private void InitializeParams()
    {
        startAfterTime = 3f;
        repeatingTime = 3f;
        newCellSpeed = 0;
        difficultyLevel = 0;
        numberOfBacteriasInQueue = 0;
        numberOfColors = 4;
        startGenerating = false;
    }

    private int GenerateNucleusSequence(int levelDifficulty)
	{
        int[] nucleusArray = new int[4];
        int nucleusSequenceForNewBacteria = 0;

        if(levelDifficulty > numberOfColors)
        {
            levelDifficulty = numberOfColors;
        }

        for (int i = 0; i < levelDifficulty; i++)
        {
            int arrayIndex = Random.Range(0, numberOfColors);
            nucleusArray[arrayIndex] = 1;
        }

        for (int i = 0; i < nucleusArray.Length; i++)
        {
            int currentIndex = nucleusArray.Length - i - 1;
            nucleusSequenceForNewBacteria += nucleusArray[i]* (int)Mathf.Pow(10f, (currentIndex));
        }

        //Checking if missed a case
        if(nucleusSequenceForNewBacteria > 1111 || nucleusSequenceForNewBacteria == 0)
        {
            nucleusSequenceForNewBacteria = 1000;
        }
        return nucleusSequenceForNewBacteria;
    }

	private void Update()
	{

        //Debug.Log("numberOfBacteriasInQueue: " + numberOfBacteriasInQueue);
        //Debug.Log("startGenerating: " + startGenerating);
        if (numberOfBacteriasInQueue > 0 && startGenerating)
		{
            if (Time.timeSinceLevelLoad > startAfterTime)
			{
                startAfterTime += repeatingTime;
                var bacteria = Instantiate(bacteriaPrefab, transform.position, Quaternion.identity);
                //var bacteria = Instantiate(Resources.Load("Bacteria/Bacteria") as GameObject, transform.position, Quaternion.identity);
                Bacteria bac = bacteria.GetComponent<Bacteria>();
                bac.SetNucleusSequence(GenerateNucleusSequence(difficultyLevel));
                bac.SetSpeed(newCellSpeed);
                //bac.transform.parent = bacteriaHolder.transform;
                if(numberOfBacteriasInQueue > 0)
                    numberOfBacteriasInQueue--;
		    }
		}
	}

	public void SpawnBacteria () {
		
		numberOfBacteriasInQueue++;
    }

    public void IncreaseSpawnerDifficulty(float difficultyIncreaseRate){

        if(repeatingTime - difficultyIncreaseRate > 0)
        {
            difficultyLevel++;
            newCellSpeed += difficultyIncreaseRate;

            repeatingTime -= difficultyIncreaseRate;
        }
    }

    public void StartGenerating()
    {
        this.startGenerating = true;
    }

}
