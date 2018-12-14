using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	
	[SerializeField] private float minDist;
	[SerializeField] private float maxDist;
	[SerializeField] private float movingSpeed;
	[SerializeField] private int health = 20;
	private Vector2 initialPosition;
    private int direction;
	private Animator enemyAnimator;
	
	private void Awake()
	{
		enemyAnimator = GetComponent<Animator>();
	}

	void Start ()
	{
		initialPosition = transform.position;
		direction = -1;
		maxDist += transform.position.x;
		minDist -= transform.position.x;
	}
   
	// Update is called once per frame
	void Update ()
	{
		switch (direction)
		{
			case -1:
				// Moving Left
				if( transform.position.x > minDist)
				{
					GetComponent <Rigidbody2D>().velocity = new Vector2(-movingSpeed,GetComponent<Rigidbody2D>().velocity.y);
				}
				else
				{
					direction = 1;
					enemyAnimator.SetFloat("Moving_Right", direction);
				}
				break;
			case 1:
				//Moving Right
				if(transform.position.x < maxDist)
				{
					GetComponent <Rigidbody2D>().velocity = new Vector2(movingSpeed,GetComponent<Rigidbody2D>().velocity.y);
				}
				else
				{
					direction = -1;
					enemyAnimator.SetFloat("Moving_Left", direction);
					
				}
				break;
		}
		if (health<=0)
		{
			Destroy(gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D player)
	{
		if (player.gameObject.name == "Player")
		{
			GameManager.lives -= 1;
		}   
	}
	public void TakeDamage(int damage)
	{
		health -= damage;
	}
}
