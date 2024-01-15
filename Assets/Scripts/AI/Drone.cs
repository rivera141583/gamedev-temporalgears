using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drone : MonoBehaviour
{
	public bool alerted = false;
	public bool isAttacking = false;

	public float playerPos;
	public float playerPosY;
	public bool playerDirection;


	private Rigidbody2D body;
	//private BoxCollider2D collider;

	public GameObject sprite;
	public Drone_Gun gun;

	public float flyY;
	public float maxY;
	public float minY;

	public double health = 20;
	public double maxHealth = 20;

	public double attack = 10;

	public GameObject pickup_bullet;
	public GameObject pickup_health;
	public GameObject pickup_steam;

	// Start is called before the first frame update
	void Start()
    {
		flyY = transform.position.y;
		maxY = flyY + 1;
		minY = flyY + 3;
		body = GetComponent<Rigidbody2D>();
		isAttacking = false;
	}

    // Update is called once per frame
    void Update()
	{
		if (health <= 0)
		{
			Die();
			this.gameObject.SetActive(false);
		}
		else if (health > maxHealth)
		{
			health = maxHealth;
		}
	}

	void FixedUpdate()
	{/*
		else if (body.velocity.y > maxY)
		{

		}*/
		if (body.position.y < minY)
		{
			body.AddForce(new Vector2(0, 15));
		}

		if (alerted)
		{
			gun.playerPos = new Vector3(playerPos, playerPosY, transform.position.z);
			if (transform.position.x < playerPos)
			{
				body.velocity = new Vector2(5, body.velocity.y);
				playerDirection = false;
			}
			else if (transform.position.x > playerPos)
			{
				playerDirection = true;
				body.velocity = new Vector2(-5, body.velocity.y);
			}
			if (!isAttacking)
			{
				isAttacking = true;
				StartCoroutine(Attack());
			}
		}
		else
		{
			body.velocity = new Vector2(0, body.velocity.y);
		}

		if (playerDirection)
		{
			sprite.transform.localScale = new Vector3(1, 1, 1);
		}
		else
		{
			sprite.transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	IEnumerator Attack ()
	{
		int counter = 3;
		if (counter > 0)
		{
			yield return new WaitForSeconds(1);
			counter--;
		}
		gun.attack = true;
		isAttacking = false;
	}
	public void Die()
	{
		int roll = (int)Random.Range(0, 10);
		if (roll < 2)
		{

		}
		else if (roll >= 2 && roll < 6)
		{
			GameObject instance = Instantiate(
									pickup_bullet,
									body.transform.position,
									Quaternion.identity
								  );
		}
		else if (roll >= 6 && roll < 8)
		{

			GameObject instance = Instantiate(
									pickup_steam,
									body.transform.position,
									Quaternion.identity
								  );
		}
		else if (roll >= 8)
		{

			GameObject instance = Instantiate(
									pickup_health,
									body.transform.position,
									Quaternion.identity
								  );
		}
	}
}
