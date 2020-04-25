using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour, IKillable
{
    GameObject targetCell;
    [SerializeField] float moveSpeed;
    private float rotateSpeed = 20f;
    Rigidbody2D rb;
    //Vector2 targetPosition;
    Vector2 nextTargetPos;
    List<Vector3> bacteriaWayPoints;
    int currentIndexForWaypoint = 0;
    
    GameManager gameManager;
    AudioManager audioManager;

    DNA dna;

    int nucleusSequence = 9999;

    private void Awake()
    {
        //targetCell = GameObject.FindGameObjectWithTag("Cell");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        bacteriaWayPoints = new List<Vector3>();
    }

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        dna = gameObject.transform.GetChild(0).GetComponent<DNA>();
        //targetPosition = new Vector2(targetCell.transform.position.x, targetCell.transform.position.y);
    }

    private void FixedUpdate()
    {
        //if (targetCell != null)
        if(bacteriaWayPoints[currentIndexForWaypoint].GetType() != null)
        {
            rb.velocity = transform.forward * moveSpeed;
            Quaternion targetRotation = Quaternion.LookRotation(bacteriaWayPoints[currentIndexForWaypoint] - transform.position);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed));
            transform.position = Vector3.MoveTowards(transform.position, nextTargetPos, moveSpeed * Time.fixedDeltaTime);

            if (Vector2.Distance(bacteriaWayPoints[currentIndexForWaypoint], new Vector2(transform.position.x, transform.position.y)) < 0.2)
            {
                if (currentIndexForWaypoint < bacteriaWayPoints.Count - 1)
                {
                    currentIndexForWaypoint++;
                    nextTargetPos = bacteriaWayPoints[currentIndexForWaypoint];
                }
            }
        }
        
        
    }

/*    public void DestroyBacteria(int sequenceFromUser)
    {
        if(nucleusSequence == sequenceFromUser)
        {
            gameManager.AnnounceBacteriaDeath();
            Destroy(gameObject);
        }
    }
*/

    public void Kill(int aminoAcid)
    {
        if (nucleusSequence == aminoAcid)
        {
            gameManager.AnnounceBacteriaDeath();
            audioManager.BacteriaDeath();
            Destroy(gameObject);
        }
        else
        {
            audioManager.BacteriaBuzz();
        }
    }

    public void SetNucleusSequence(int nucleusSequenceByUser)
    {
		nucleusSequence = nucleusSequenceByUser;
        SetSprite();
	}

    public void SetSprite()
    {
        //dna.UpdateSprite(nucleusSequence);
        gameObject.transform.GetComponentsInChildren<DNA>(true)[0].UpdateSprite(nucleusSequence);
    }

    public void SetSpeed(float speed)
    {
        moveSpeed += speed;
    }

    public void SetWaypoints(List<GameObject> waypoints)
    {
        foreach (var point in waypoints)
        {
            bacteriaWayPoints.Add(new Vector2(point.transform.position.x, point.transform.position.y));
        }
        nextTargetPos = bacteriaWayPoints[0];
    }
}
