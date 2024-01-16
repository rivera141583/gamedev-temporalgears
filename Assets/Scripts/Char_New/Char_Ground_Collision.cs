using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Ground_Collision : MonoBehaviour
{
	public Char_Movement playerMovement;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			playerMovement.isGrounded = true;
			playerMovement.normalJumped = false;
			playerMovement.doubleJumped = false;
		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		//Debug.Log(collision.gameObject.ToString());
		if (collision.gameObject.tag == "Ground")
		{
			playerMovement.isGrounded = true;
			//playerMovement.normalJumped = false;
			//playerMovement.doubleJumped = false;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			playerMovement.isGrounded = false;
		}
	}
}
