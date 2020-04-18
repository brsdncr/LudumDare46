using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
	[SerializeField] GameObject bacteriaPrefab;
    // Start is called before the first frame update
    float startAfterTime = 2.0f;
    float repeatingTime = 2.0f;

    //private void Start()
    //{
    //    InvokeRepeating("Spawn", startAfterTime, repeatingTime);
    //}

    public void SpawnBacteria () {
        var bacteria = Instantiate(bacteriaPrefab, transform.position, Quaternion.identity);
    }



}
