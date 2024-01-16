using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Health : MonoBehaviour
{
	[SerializeField] public ResourceHandler resourceHandler;
	public int giveAmount = 10;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			resourceHandler.health += giveAmount;
			Destroy(this.gameObject, 0);
		}
	}
}
