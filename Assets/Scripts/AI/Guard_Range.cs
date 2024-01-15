using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Range : MonoBehaviour
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
			guard.withinRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			guard.withinRange = false;
		}
	}
}
