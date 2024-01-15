using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
	[SerializeField] LightTest_Environment environment;
	[SerializeField] ResourceHandler resource;
	bool playerNearby = false;

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && playerNearby)
		{
			environment.SteamPowerActivated = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			playerNearby = true;
			resource.DisplayMessage("Press left click to activate valve",5);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
			playerNearby = false;
	}
}
