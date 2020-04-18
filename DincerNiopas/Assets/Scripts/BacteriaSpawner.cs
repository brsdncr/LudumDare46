using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
	[SerializeField] Bacteria bacteriaPrefab;
    // Start is called before the first frame update
    float startAfterTime = 2.0f;
    float repeatingTime = 2.0f;

    private void Start()
    {
        InvokeRepeating("Spawn", startAfterTime, repeatingTime);
    }

    void Spawn () {
        var bacteria = Instantiate(bacteriaPrefab, transform.position, Quaternion.identity);
    }



}
