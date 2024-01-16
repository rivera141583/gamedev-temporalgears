using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D collision)
	{
		Debug.Log("bam: " + collision.name);
		if (collision.gameObject.tag == "Enemy")
		{
		}
	}
}
