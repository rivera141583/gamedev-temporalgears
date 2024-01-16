using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Rigidbody2D body;
	private BoxCollider2D coll;
	// Start is called before the first frame update
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		coll = GetComponent<BoxCollider2D>();
		//body.velocity = new Vector2(100, 0);
	}

	// Update is called once per frame
	void Update()
	{
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Door")
		{
			Destroy(this.gameObject, 0);
			Debug.Log("hit: " + DateTime.Now.ToString("HH:mm:ss"));
		}
	}
}
