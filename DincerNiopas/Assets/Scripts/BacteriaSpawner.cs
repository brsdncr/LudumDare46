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

	int numberOfBacteriasInQueue;
	int numberOfColors;

    GameObject bacteriaHolder;

    private void Start()
    {
        InitializeParams();
        bacteriaHolder = GameObject.FindGameObjectWithTag("BacteriaHolder");
    }

    private void InitializeParams()
    {
        startAfterTime = 3f;
        repeatingTime = 3f;
        newCellSpeed = 0;
        difficultyLevel = 0;
        numberOfBacteriasInQueue = 0;
        numberOfColors = 4;
    }

    private int GenerateNucleusSequence()
	{
		int nucleusSequenceForNewBacteria = 0;
		for (int i = 0; i < numberOfColors; i++)
		{
            //From Black to Red
            int colorSetter = Random.Range(0, 2);

            if(colorSetter == 1)
			{
				nucleusSequenceForNewBacteria += (int)Mathf.Pow(10f, i);
			}

		}

        if (nucleusSequenceForNewBacteria == 0)
            nucleusSequenceForNewBacteria = 1001;
        
        return nucleusSequenceForNewBacteria;
    }

	private void Update()
	{
        if(numberOfBacteriasInQueue > 0)
		{
			if (Time.timeSinceLevelLoad > startAfterTime)
			{
                startAfterTime += repeatingTime;
                var bacteria = Instantiate(bacteriaPrefab, transform.position, Quaternion.identity);
                Bacteria bac = bacteria.GetComponent<Bacteria>();
                bac.SetNucleusSequence(GenerateNucleusSequence());
                bac.SetSpeed(newCellSpeed);
                bac.transform.parent = bacteriaHolder.transform;

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
            Debug.Log("Difficulty Increased to: " + difficultyLevel);

            repeatingTime -= difficultyIncreaseRate;
        }
    }
    
}
