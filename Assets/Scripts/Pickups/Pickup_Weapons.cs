using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Weapons : MonoBehaviour
{
	[SerializeField] public ResourceHandler resourceHandler;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			resourceHandler.gun = true;
			resourceHandler.bullets = resourceHandler.maxbullets;
			resourceHandler.sword = true;
			resourceHandler.DisplayMessage("Got gun and sword", 3);
			Destroy(this.gameObject, 0);
		}
	}
}
