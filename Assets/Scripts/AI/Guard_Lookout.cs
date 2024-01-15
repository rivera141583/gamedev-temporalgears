using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Lookout : MonoBehaviour
{
	public Guard guard;
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
		if (collision.gameObject.tag == "Player")
		{
			guard.alerted = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			guard.alerted = false;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			guard.playerPos = collision.gameObject.transform.position.x;
		}
	}
}
