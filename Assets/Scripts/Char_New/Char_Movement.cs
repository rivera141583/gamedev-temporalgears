using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Movement : MonoBehaviour
{
	[SerializeField] private float Speed;
	private float actualSpeed;
	[SerializeField] private float JumpHeight;
	private Rigidbody2D body;
	private Collider2D collider;
	Vector2 movement;
	public int currentweapon = 1;
	int maxweapons = 3;

	[SerializeField] GameObject Gun;
	[SerializeField] GameObject BroadSword;
	[SerializeField] GameObject ShortSword;

	[SerializeField] Char_Broad_Attack BroadScript;
	[SerializeField] Char_Short_Attack ShortScript;

	public Char_Animation animationHandler;

	public ResourceHandler resource;
	const float velocityThreshold = 0.12f;

	public bool normalJumped = false;
	public bool doubleJumped = false;

	public bool isGrounded;

	public bool isAttacking = false;

	// Start is called before the first frame update
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();

		BroadSword.SetActive(true);
		ShortSword.SetActive(false);
		Gun.SetActive(false);
	}

	private void FixedUpdate()
	{
		actualSpeed = Speed;

		if (!isAttacking)
		{
			body.velocity = new Vector2((Input.GetAxis("Horizontal")) * actualSpeed, body.velocity.y);
		}

		movement.x = Input.GetAxisRaw("Horizontal");

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//if (body.velocity.y > -1 * velocityThreshold && body.velocity.y < velocityThreshold && isGrounded)
			if (isGrounded && !normalJumped)
			{
				body.velocity = new Vector2(body.velocity.x, JumpHeight);
				normalJumped = true;
			}
			else if (!isGrounded && normalJumped && !doubleJumped && resource.steamboots)
			{
				body.velocity = new Vector2(body.velocity.x, JumpHeight);
				resource.steam -= 5;
				doubleJumped = true;
			}
		}
		if (movement.x != 0 && !isAttacking)
		{
			body.AddForce(new Vector2(movement.x * actualSpeed, 0f));
		}

		if (body.velocity.y > velocityThreshold)
		{
			animationHandler.isJumping = true;
			animationHandler.isFalling = false;
			animationHandler.isGrounded = false;
		}
		if (body.velocity.y < 0)
		{
			animationHandler.isJumping = false;
			animationHandler.isFalling = true;
			animationHandler.isGrounded = false;
		}

		if ((body.velocity.y > 0 && body.velocity.y < velocityThreshold) || body.velocity.y == 0 || isGrounded)
		{
			animationHandler.isJumping = false;
			animationHandler.isFalling = false;
			animationHandler.isGrounded = true;
		}

		if (body.velocity.x > 0 && !isAttacking)
		{
			animationHandler.direction = true;
			animationHandler.isRunning = true;
			BroadScript.direction = true;
			ShortScript.direction = true;
		}
		else if (body.velocity.x < 0 && !isAttacking)
		{
			animationHandler.direction = false;
			animationHandler.isRunning = true;
			BroadScript.direction = false;
			ShortScript.direction = false;
		}
		else if (body.velocity.x == 0)
		{
			animationHandler.isRunning = false;
		}
	}

	void Update()
	{
        if (Input.GetKey(KeyCode.Alpha1) && !isAttacking)
        {
			currentweapon = 1;
			BroadSword.SetActive(true);
			ShortSword.SetActive(false);
			Gun.SetActive(false);

			animationHandler.weapon = 0;
		}
		if (Input.GetKey(KeyCode.Alpha2) && !isAttacking)
		{
			currentweapon = 2;
			BroadSword.SetActive(false);
			ShortSword.SetActive(true);
			Gun.SetActive(false);

			animationHandler.weapon = 1;
		}
		if (Input.GetKey(KeyCode.Alpha3) && !isAttacking)
		{
			currentweapon = 3;
			BroadSword.SetActive(false);
			ShortSword.SetActive(false);
			Gun.SetActive(true);

			animationHandler.weapon = 2;
		}

		/*if (resource.health <= 0)
		{
			this.gameObject.SetActive(false);
		}

		*/
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Guard")
		{
			resource.health -= 10;
			if (transform.position.x < collision.gameObject.transform.position.x)
			{
				body.velocity = new Vector2(-20, 13);
			}
			if (transform.position.y < collision.gameObject.transform.position.x)
			{
				body.velocity = new Vector2(20, 13);
			}
		}
	}
}
