using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LeftExitTrigger : MonoBehaviour
{
	public GameObject LoadThis;

	public float setCameraFreezeXPos;
	public float setCameraFreezeYPos;

	public bool setCameraFreezeX;
	public bool setCameraFreezeY;

	public float setCameraMaxLeftX;
	public float setCameraMaxRightX;
	public float setCameraMaxDownY;
	public float setCameraMaxUpY;

	public CameraFollow camera;

	public LeftExitTrigger Pair;
	public bool PairPassed = false;

	//public GameObject Blackout;
	//public SpriteRenderer BlackoutColour;
	//public GameObject UnloadThis;

	//bool blackoutactive = false;

	// Start is called before the first frame update
	void Start()
	{
		/*if (LoadThis != null)
		{
			if (LoadThis.activeInHierarchy)
			{
				blackoutactive = true;
			}
		}*/
	}

	// Update is called once per frame
	void Update()
	{
		/*
		if (Blackout != null)
		{
			if (blackoutactive)
			{
				Blackout.SetActive(true);
				if (BlackoutColour.color.a != 255)
				{
					BlackoutColour.color = new Color(0,0,0, BlackoutColour.color.a + 1);
				}
				else if (BlackoutColour.color.a == 255)
				{
				}
			}
			else
			{
				if (BlackoutColour.color.a != 0)
				{
					BlackoutColour.color = new Color(0, 0, 0, BlackoutColour.color.a - 1);
				}
				else if (BlackoutColour.color.a == 0)
				{
					Blackout.SetActive(false);
				}
			}
		}*/
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Debug.Log("bap");
			Debug.Log(LoadThis.ToString());

			camera.FreezeX = setCameraFreezeX;
			camera.FreezeY = setCameraFreezeY;

			camera.FixedHorizontal = setCameraFreezeXPos;
			camera.FixedHeight = setCameraFreezeYPos;

			camera.maxLeftX = setCameraMaxLeftX;
			camera.maxRightX = setCameraMaxRightX;
			camera.maxDownY = setCameraMaxDownY;
			camera.maxUpY = setCameraMaxUpY;
			if (LoadThis != null)
			{
				if (LoadThis.activeInHierarchy)
				{
					LoadThis.SetActive(false);
					//blackoutactive = true;
				}
				else
				{
					LoadThis.SetActive(true);
					//blackoutactive = false;
				}
			}
			if (Pair != null)
			{
				Pair.PairPassed = true;
			}
			/*
			if (UnloadThis != null)
			{
				if (UnloadThis.activeInHierarchy)
				{
					UnloadThis.SetActive(false);
				}
				else
				{
					UnloadThis.SetActive(true);
				}
			}*/
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (!PairPassed)
			{
				if (LoadThis != null)
				{
					if (LoadThis.activeInHierarchy)
					{
						LoadThis.SetActive(false);
						//blackoutactive = true;
					}
				}
			}
			else
			{
				Pair.PairPassed = false;
			}
		}
	}
}
