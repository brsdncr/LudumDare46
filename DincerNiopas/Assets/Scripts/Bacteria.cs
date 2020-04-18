using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    [SerializeField] GameObject targetCell;
    private int moveSpeed = 3;
    private float rotateSpeed = 20f;
    Rigidbody2D rb;
    Vector2 targetPosition;
    
    GameManager gameManager;


    int nucleusSequence = 9999;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        targetPosition = new Vector2(targetCell.transform.position.x, targetCell.transform.position.y);
    }

    private void FixedUpdate()
    {
        if (targetCell != null)
        {
            rb.velocity = transform.forward * moveSpeed;
            Quaternion targetRotation = Quaternion.LookRotation(targetCell.transform.position - transform.position);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed));
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), targetPosition, moveSpeed * Time.fixedDeltaTime);
        }
        
    }

    public void DestroyBacteria(int sequenceFromUser)
    {
        if(nucleusSequence == sequenceFromUser)
        {
            gameManager.AnnounceBacteriaDeath();
            Destroy(gameObject);
        }
    }

    public void SetNucleusSequence(int nucleusSequenceByUser)
    {
		nucleusSequence = nucleusSequenceByUser;
	}
}
