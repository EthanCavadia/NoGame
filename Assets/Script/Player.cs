using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] private float playerSpeed;
	[SerializeField] private float playerJumpforce;
    
	private Rigidbody2D _rigidbody2D;
	private bool grounded = false;
	private float horizontalMove;
	private SpriteRenderer playerSprite;
	public Animator playerAnimator;
	private float move;
	private bool facingRight = false;
	private bool isMoving = false;
	private Collider2D sword;
	
	private void Awake()
	{
		playerSprite = GetComponent<SpriteRenderer>();
		playerAnimator = GetComponent<Animator>();
	}

	void Start ()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		playerSprite = GetComponent<SpriteRenderer>();
		sword = GameObject.Find("Sword").GetComponent<Collider2D>();
	}

	private void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");
		_rigidbody2D.velocity = new Vector2(move * playerSpeed,_rigidbody2D.velocity.y);

		if (move < 0 && !facingRight)
		{
			Flip();
			facingRight = true;
			isMoving = true;
		}

		if (move > 0 && facingRight)
		{
			Flip();
			facingRight = false;
			isMoving = true;
		}

		if (move == 0) isMoving = false;
		
		if (Input.GetButtonDown("Jump") && grounded == false)
		{
			_rigidbody2D.AddForce(Vector2.up * playerJumpforce,ForceMode2D.Impulse);
			grounded = true;
		}
		
		playerAnimator.SetBool ("grounded", grounded);
		playerAnimator.SetBool("Moving", isMoving);
		
	}
	void Flip()
	{
		// Switch the way the player is labelled as facing
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Ground")
		{
			grounded = false;
		}
		if (collision.gameObject.tag == "Spike")
		{
			Destroy(gameObject);
			SceneManager.LoadScene("Scenes/GameOver");
		}

		if (collision.gameObject.tag == "EndGame")
		{
			SceneManager.LoadScene("Scenes/Victory");
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			playerAnimator.SetTrigger("Attack");
		}
	}

	void Attack()
	{
		sword.enabled = true;
		
	}

	void NoAttack()
	{
		sword.enabled = false;
	}
}
