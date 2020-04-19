using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
	[SerializeField] GameObject bacteriaPrefab;
    // Start is called before the first frame update
    [SerializeField] float startAfterTime;
    [SerializeField] float repeatingTime;

	int numberOfBacteriasInQueue = 0;
	int numberOfColors = 4;

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
                Bacteria bac = bacteria.GetComponent<Bacteria>();
                bac.SetNucleusSequence(GenerateNucleusSequence());
                bac.SetSprite();

                numberOfBacteriasInQueue--;
		    }
		}
	}
}
