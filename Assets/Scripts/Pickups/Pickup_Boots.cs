using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Boots : MonoBehaviour
{
	[SerializeField] public ResourceHandler resourceHandler;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			resourceHandler.steamboots = true;
			resourceHandler.steam = resourceHandler.maxsteam;
			resourceHandler.DisplayMessage("Double jump gained", 3);
			Destroy(this.gameObject, 0);
		}
	}
}
