using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour, IKillable
{
    [SerializeField] GameObject targetCell;
    [SerializeField] float moveSpeed;
    private float rotateSpeed = 20f;
    Rigidbody2D rb;
    Vector2 targetPosition;
    
    GameManager gameManager;
    AudioManager audioManager;

    DNA dna;

    int nucleusSequence = 9999;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        dna = gameObject.transform.GetChild(0).GetComponent<DNA>();
        Debug.Log(gameObject.transform.GetChild(0).name);
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
}
