using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
	[SerializeField] GameObject bacteriaPrefab;
    // Start is called before the first frame update
    [SerializeField] float startAfterTime;
    [SerializeField] float repeatingTime;

	int numberOfBacteriasInQueue = 0;

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
                numberOfBacteriasInQueue--;
		    }
		}
	}
}
