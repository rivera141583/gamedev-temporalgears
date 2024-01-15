using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Char_Damage_Collision : MonoBehaviour
{
	public ResourceHandler resource;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy_Melee")
		{
			if (collision.gameObject.name == "Enemy_Halberd")
			{
				resource.health -= 10;
			}
		}
		if (collision.gameObject.tag == "Enemy_Bullet")
		{
			resource.health -= 10;
			
		}
	}
}
