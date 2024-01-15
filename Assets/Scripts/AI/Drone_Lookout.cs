using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Lookout : MonoBehaviour
{
	public Drone drone;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			drone.alerted = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			drone.alerted = false;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			drone.playerPos = collision.gameObject.transform.position.x;
			drone.playerPosY = collision.gameObject.transform.position.y;
		}
	}
}
