using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerArm : MonoBehaviour
{
	//private Rigidbody2D body;
	[SerializeField] GameObject b;
	[SerializeField] GameObject bullet;

	Vector3 mousePos;

	public Char_AnimationHandler animationHandler;

	public ResourceHandler resource;
	public GameObject sword;
	public PlayerMovement player;

	bool IsSword = false;
	bool IsGun = false;

	// Start is called before the first frame update
	void Start()
	{
		//body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 lookDirection = (mousePos - transform.position);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
		//body.transform.position = new Vector2(b.transform.position.x, b.transform.position.y);

		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("butt");
			if (resource.bullets > 0 && resource.gun && player.currentweapon == 1 && !IsGun)
			{
				IsGun = true;
				animationHandler.isShooting = true;
				StartCoroutine(ShootFalse());
				resource.bullets -= 1;
				GameObject instance = Instantiate(
										bullet,
										transform.position,
										Quaternion.identity
									  );
				instance.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
				Rigidbody2D bulletrg = instance.GetComponent<Rigidbody2D>();
				bulletrg.AddForce(lookDirection.normalized * 3000);
				Destroy(instance, 5);


				if (transform.rotation.z < 180 ||
					transform.rotation.z >= 66)
				{
					animationHandler.shootDirection = 0;
				}
				else if (transform.rotation.z < 66 ||
					transform.rotation.z >= 25)
				{
					animationHandler.shootDirection = 1;
				}
				else if (transform.rotation.z < 25 ||
					transform.rotation.z >= 0)
				{
					animationHandler.shootDirection = 2;
				}
				else if (transform.rotation.z > -180 ||
					transform.rotation.z <= -66)
				{
					animationHandler.shootDirection = 0;
				}
				else if (transform.rotation.z > -66 ||
					transform.rotation.z <= -25)
				{
					animationHandler.shootDirection = 1;
				}
				else if (transform.rotation.z > -25 ||
					transform.rotation.z <= 0)
				{
					animationHandler.shootDirection = 2;
				}

			}
			else if (resource.sword && player.currentweapon == 2 && !IsSword)
			{
				sword.SetActive(true);
				IsSword = true;
				StartCoroutine(SwordAttack());
			}
		}

	}

	IEnumerator ShootFalse ()
	{
		int counter = 1;
		while (counter != 0)
		{
			yield return new WaitForSeconds(0.5f);
			counter--;
		}
		animationHandler.isShooting = false;
		IsGun = false;
	}

	IEnumerator SwordAttack()
	{
		int counter = 1;
		while (counter != 0)
		{
			yield return new WaitForSeconds(0.25f);
			counter--;
		}
		sword.SetActive(false);
		IsSword = false;
	}
}
