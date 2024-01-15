using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
	public bool alerted = false;
	public bool withinRange = false;
	private bool isAttacking = false;

	public float playerPos;
	public bool playerDirection;

	public GameObject halberd;
	public GameObject attackRange;
	public Guard_AnimationHandler animationHandler;

	private Rigidbody2D body;
	private BoxCollider2D collider;

	public WeaponHandler weaponHandler;

	public GameObject pickup_bullet;
	public GameObject pickup_health;
	public GameObject pickup_steam;

	//[SerializeField] public GameObject[] pickups;

	private float attackX;
	private float attackY; 
	private float attackZ;

	public double health = 100;
	public double maxHealth = 100;

	public double attack = 10;

	// Start is called before the first frame update
	void Start()
    {
        body = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D>();
		attackX = attackRange.transform.localScale.x;
		attackY = attackRange.transform.localScale.y;
		attackZ = attackRange.transform.localScale.z;
	}

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
		{
			Die();
			this.gameObject.SetActive(false);
		} else if (health > maxHealth)
		{
			health = maxHealth;
		}
    }

	private void FixedUpdate()
	{
		if (playerPos < transform.position.x)
		{
			playerDirection = true;
		}
		else if (playerPos > transform.position.x)
		{
			playerDirection = false;
		}

		if (alerted && !withinRange && !isAttacking)
		{
			animationHandler.isWalking = true;
			if (playerDirection) // left
			{
				animationHandler.playerDirection = true;

				body.velocity = new Vector2(-2, 0);
			}
			else // right
			{
				animationHandler.playerDirection = false;

				body.velocity = new Vector2(2, 0);
			}
		}

		if (withinRange)
		{
			animationHandler.isWalking = false;
			body.velocity = new Vector2(0, 0);
			if (!isAttacking)
			{
				if (playerDirection) // left
				{
					animationHandler.playerDirection = true;
					attackRange.transform.localScale = new Vector3(attackX, attackY, attackZ);
				}
				else // right
				{
					animationHandler.playerDirection = false;
					attackRange.transform.localScale = new Vector3(-attackX, attackY, attackZ);
				}
				Attack();
			}
		}

		if (body.velocity.x == 0)
		{
			animationHandler.isWalking = false;
		}
	}

	private void Attack ()
	{
		isAttacking = true;
		animationHandler.isAttacking = true;
		halberd.SetActive(true);
		StartCoroutine(StopAttack());
	}

	private IEnumerator StopAttack()
	{
		int counter = 1;
		while (counter > 0)
		{
			yield return new WaitForSeconds(1);
			counter--;
		}
		animationHandler.isAttacking = false;
		isAttacking = false;
		halberd.SetActive(false);
	}

	public void Die()
	{
		int roll = (int)Random.Range(0, 10);
		if (roll < 4)
		{

		}
		else if (roll >= 4 && roll < 6)
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
	/*
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "PlayerBullet")
		{
			health -= weaponHandler.gunDamage;
		} else if (collision.gameObject.tag == "Player_Melee")
		{
			health -= weaponHandler.swordDamage;
		}
	}*/
}
