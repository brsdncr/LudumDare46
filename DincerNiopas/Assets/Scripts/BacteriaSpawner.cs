using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
	[SerializeField] GameObject bacteriaPrefab;
    // Start is called before the first frame update
    [SerializeField] float startAfterTime;
    [SerializeField] float repeatingTime;

	int numberOfBacteriasInQueue = 0;


	private int GenerateNucleusSequence()
	{
		int nucleusSequenceForNewBacteria = 0;

		int redColor = Random.Range(0, 2);
		int greenColor = Random.Range(0, 2);
		int blueColor = Random.Range(0, 2);
		int blackColor = Random.Range(0, 2);

		if (redColor == 1)
		{
			nucleusSequenceForNewBacteria += 1000;
		}
		if (greenColor == 1)
		{
			nucleusSequenceForNewBacteria += 100;
		}
		if (blueColor == 1)
		{
			nucleusSequenceForNewBacteria += 10;
		}
		if (blackColor == 1)
		{
			nucleusSequenceForNewBacteria += 1;
		}

		Debug.Log("nucleusSequenceForNewBacteria: " + nucleusSequenceForNewBacteria);
		return nucleusSequenceForNewBacteria;
	}

	public void SpawnBacteria () {
		
		numberOfBacteriasInQueue++;

	}

	void Update()
	{
        if(numberOfBacteriasInQueue > 0)
		{
			if (Time.time > startAfterTime)
			{
                startAfterTime += repeatingTime;
				var bacteria = Instantiate(bacteriaPrefab, transform.position, Quaternion.identity);
                bacteria.GetComponent<Bacteria>().SetNucleusSequence(GenerateNucleusSequence());
                numberOfBacteriasInQueue--;
		    }
		}
	}
}
