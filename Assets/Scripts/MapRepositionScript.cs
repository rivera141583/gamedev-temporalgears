using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRepositionScript : MonoBehaviour
{
	public int x;
	public int y;

	public bool isRevealed;

	public GameObject mapPointer;

	const float multiples = 1.6f;

	float mapx;
	float mapy;
	// Start is called before the first frame update
	void Start()
    {
		mapx = x * multiples;
		mapy = y * multiples;
	}

    // Update is called once per frame
    void Update()
    {

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			mapPointer.transform.localPosition = new Vector3(mapx, mapy, 1);
		}
	}
}
