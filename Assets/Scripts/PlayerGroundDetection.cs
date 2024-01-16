using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetection : MonoBehaviour
{
	public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
		if (collision.gameObject.tag == "Ground")
		{
			playerMovement.isGrounded = true;
			playerMovement.normalJumped = false;
			playerMovement.doubleJumped = false;
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
