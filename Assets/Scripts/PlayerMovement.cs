using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float Speed;
	private float actualSpeed;
	[SerializeField] private float JumpHeight;
	private Rigidbody2D body;
	private Collider2D collider;
	Vector2 movement;
	public int currentweapon = 1;
	int maxweapons = 2;
	GameObject gun;
	//GameObject sword;
	public Char_AnimationHandler animationHandler;
	//public SwordAttack swordHandler;
	public ResourceHandler resource;
	const float velocityThreshold = 0.12f;

	public bool normalJumped = false;
	public bool doubleJumped = false;

	public bool isGrounded;

	// Start is called before the first frame update
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();

		gun = GameObject.Find("Arm");
		//sword = GameObject.Find("SwordJoint");
		gun.SetActive(true);
		//sword.SetActive(false);
	}

    // Update is called once per frame
    void Update()
	{
        if (Input.GetKey(KeyCode.Alpha1))
        {
			currentweapon = 1;
			//gun.SetActive(true);
			//sword.SetActive(false);
		}
		if (Input.GetKey(KeyCode.Alpha2))
		{
			currentweapon = 2;
			//gun.SetActive(false);
			//sword.SetActive(true);
		}
		actualSpeed = Speed;

		if (Input.GetKey(KeyCode.LeftShift))
		{
			actualSpeed = Speed * 2;
		}

		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			actualSpeed = Speed;
		}

		if (resource.health <= 0)
		{
			this.gameObject.SetActive(false);
		}


		body.velocity = new Vector2((Input.GetAxis("Horizontal")) * actualSpeed, body.velocity.y);


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

		if (movement.x != 0)
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
		//if ((body.velocity.y > -1 * velocityThreshold && body.velocity.y < velocityThreshold) || body.velocity.y == 0)
		if ((body.velocity.y > 0 && body.velocity.y < velocityThreshold) || body.velocity.y == 0 || isGrounded)
		{
			animationHandler.isJumping = false;
			animationHandler.isFalling = false;
			animationHandler.isGrounded = true;
			//Debug.Log(body.velocity.y);
		}

		if (body.velocity.x > 0)
		{
			animationHandler.direction = true;
			animationHandler.isRunning = true;
			//swordHandler.direction = true;
		}
		else if (body.velocity.x < 0)
		{
			animationHandler.direction = false;
			animationHandler.isRunning = true;
			//swordHandler.direction = false;
		}
		else if (body.velocity.x == 0)
		{
			animationHandler.isRunning = false;
		}
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
