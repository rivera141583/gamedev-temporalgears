using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Steam : MonoBehaviour
{
	[SerializeField] public ResourceHandler resourceHandler;
	public int giveAmount = 10;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			resourceHandler.steam += giveAmount;
			Destroy(this.gameObject, 0);
		}
	}
}
