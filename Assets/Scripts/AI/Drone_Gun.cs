using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Gun : MonoBehaviour
{
	private Rigidbody2D body;
	[SerializeField] GameObject bullet;

	public bool attack = false;

	public Vector3 playerPos;


	// Start is called before the first frame update
	void Start()
	{
		//body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 lookDirection = (playerPos - transform.position);
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

		Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 80 * Time.deltaTime);

		if (attack)
		{
			Debug.Log("dok");
			attack = false;
			GameObject instance = Instantiate(
									bullet,
									transform.position,
									Quaternion.identity
								  );
			instance.transform.rotation = transform.rotation * Quaternion.Euler(0,0,90f);//Quaternion.LookRotation(Vector3.forward, playerPos - transform.position);


			Rigidbody2D bulletrg = instance.GetComponent<Rigidbody2D>();
			bulletrg.AddForce(transform.right.normalized * 3000);
			//bulletrg.AddForce(lookDirection.normalized * 3000);
			Destroy(instance, 5);
		}
	}
}